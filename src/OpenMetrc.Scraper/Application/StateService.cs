using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using OpenMetrc.Scraper.Models;

namespace OpenMetrc.Scraper;

/// <summary>
/// Scrapes Metrc's API documentation for each state to generate local reference files and a summary.
/// </summary>
internal static partial class StateService
{
    private const string ReferenceDirectory = "../../../Reference";
    private const string StateSummaryFilePath = "../../../../../state-summaries.json";
    private const string ApiDocUrlTemplate = "https://api-{0}.metrc.com/documentation";
    private const string ApiEndpointUrlTemplate = "{0}://api-{1}.metrc.com/Documentation/Method?key={2}.{3}";
    private static readonly string[] s_apiVersions = { "version-1-collapse", "version-2-collapse" };
    private static readonly object s_summaryLock = new();

    [GeneratedRegex("(?:[^a-z0-9_-]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled)]
    private static partial Regex EndpointCleaningRegex();

    /// <summary>
    /// Deletes the local cache of reference documents to ensure a fresh scrape.
    /// </summary>
    internal static void DeleteReferenceDocuments()
    {
        if (Directory.Exists(ReferenceDirectory))
            Directory.Delete(ReferenceDirectory, true);
    }

    /// <summary>
    /// Processes a single state by scraping its API documentation.
    /// </summary>
    internal static async Task<StateSummary> ProcessState(string state)
    {
        var stateSummary = new StateSummary(state);
        var url = string.Format(ApiDocUrlTemplate, state);
        var content = await GetStringContentAsync(url);

        if (string.IsNullOrWhiteSpace(content)) return stateSummary;

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(content);

        var tasks = s_apiVersions
            .Select(versionId => ProcessApiVersionNodeAsync(htmlDoc, versionId, stateSummary))
            .ToList();

        await Task.WhenAll(tasks);

        return stateSummary;
    }

    /// <summary>
    /// Writes the consolidated list of state summaries to a JSON file.
    /// </summary>
    internal static async Task WriteStateSummariesAsync(IEnumerable<StateSummary> stateSummaries)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonContent = JsonSerializer.Serialize(stateSummaries.OrderBy(s => s.State), options);
        await File.WriteAllTextAsync(StateSummaryFilePath, jsonContent);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"A summary of all METRC states has been written to: {StateSummaryFilePath}");
        Console.ResetColor();
    }

    private static async Task ProcessApiVersionNodeAsync(HtmlDocument htmlDoc, string versionId, StateSummary stateSummary)
    {
        var versionNode = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id='{versionId}']");
        if (versionNode == null)
        {
            Console.WriteLine($"[Debug] Version container '{versionId}' not found for state {stateSummary.State}.");
            return;
        }

        var links = versionNode.Descendants("a").ToList();
        if (!links.Any())
        {
            Console.WriteLine($"[Debug] No endpoint links found within '{versionId}' for state {stateSummary.State}.");
            return;
        }

        // By setting MaxDegreeOfParallelism, we ensure only a manageable number of requests run at once.
        var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 8 };
        await Parallel.ForEachAsync(links, parallelOptions, async (link, cancellationToken) =>
        {
            await ProcessDocumentationLinkAsync(link, stateSummary);
        });
    }

    private static async Task ProcessDocumentationLinkAsync(HtmlNode link, StateSummary stateSummary)
    {
        var href = link.GetAttributeValue("href", string.Empty);
        var parts = href.Split(new[] { '.' }, 3);
        if (parts.Length != 3) return;

        var sectionName = parts[0].Replace("#", "");
        var endpointKey = parts[1];
        var endpointName = EndpointCleaningRegex().Replace(endpointKey, string.Empty).TrimEnd('_');

        lock (s_summaryLock)
        {
            var section = stateSummary.Sections.FirstOrDefault(s => s.Name == sectionName);
            if (section == null)
            {
                section = new Section(sectionName);
                stateSummary.Sections.Add(section);
            }

            if (section.Endpoints.Contains(endpointName)) return;
            section.Endpoints.Add(endpointName);
        }

        var protocol = link.GetAttributeValue("onclick", string.Empty).Contains("http://") ? "http" : "https";
        var url = string.Format(ApiEndpointUrlTemplate, protocol, stateSummary.State, sectionName, $"{endpointKey}.{parts[2]}");
        var endpointContent = await GetStringContentAsync(url);

        await WriteEndpointDocumentAsync(stateSummary.State, sectionName, endpointKey, endpointContent);
    }

    private static async Task WriteEndpointDocumentAsync(string state, string section, string endpointKey, string? content)
    {
        if (string.IsNullOrWhiteSpace(content)) return;
        var directoryPath = Path.Combine(ReferenceDirectory, section, state);
        Directory.CreateDirectory(directoryPath);

        var filePath = Path.Combine(directoryPath, $"{endpointKey}.html");
        await File.WriteAllTextAsync(filePath, content);
    }

    private static async Task<string?> GetStringContentAsync(string url)
    {
        using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        try
        {
            return await client.GetStringAsync(url);
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n[Warning] Could not fetch {url}. Reason: {ex.Message}");
            Console.ResetColor();
            return null;
        }
    }
}