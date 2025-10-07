using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using OpenMetrc.Scraper.Core.Models;

namespace OpenMetrc.Scraper;

/// <summary>
/// Scrapes Metrc's API documentation for each state to generate local reference files and a summary.
/// </summary>
internal static partial class StateService
{
    private const string ApiDocUrlTemplate = "https://api-{0}.metrc.com/documentation";
    private const string ApiEndpointUrlTemplate = "{0}://api-{1}.metrc.com/Documentation/Method?key={2}.{3}";
    private static readonly string[] s_apiVersions = { "version-1-collapse", "version-2-collapse" };
    private static readonly object s_summaryLock = new();

    [GeneratedRegex("(?:[^a-z0-9_-]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled)]
    private static partial Regex EndpointCleaningRegex();

    /// <summary>
    /// Deletes the local cache of reference documents to ensure a fresh scrape.
    /// </summary>
    internal static void DeleteReferenceDocuments(string referenceDirectory)
    {
        if (Directory.Exists(referenceDirectory))
            Directory.Delete(referenceDirectory, true);
    }

    /// <summary>
    /// Processes a single state by scraping its API documentation.
    /// </summary>
    internal static async Task<StateSummary> ProcessState(string state, string referenceDirectory)
    {
        StateSummary stateSummary = new(state);
        string url = string.Format(ApiDocUrlTemplate, state);
        string? content = await GetStringContentAsync(url);

        if (string.IsNullOrWhiteSpace(content)) return stateSummary;

        HtmlDocument htmlDoc = new();
        htmlDoc.LoadHtml(content);

        List<Task> tasks = s_apiVersions
            .Select(versionId => ProcessApiVersionNodeAsync(htmlDoc, versionId, stateSummary, referenceDirectory))
            .ToList();

        await Task.WhenAll(tasks);

        return stateSummary;
    }

    /// <summary>
    /// Writes the consolidated list of state summaries to a JSON file.
    /// </summary>
    internal static async Task WriteStateSummariesAsync(IEnumerable<StateSummary> stateSummaries, string stateSummaryFilePath)
    {
        JsonSerializerOptions options = new() { WriteIndented = true };
        string jsonContent = JsonSerializer.Serialize(stateSummaries.OrderBy(s => s.State), options);
        await File.WriteAllTextAsync(stateSummaryFilePath, jsonContent);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"A summary of all METRC states has been written to: {stateSummaryFilePath}");
        Console.ResetColor();
    }

    private static async Task ProcessApiVersionNodeAsync(HtmlDocument htmlDoc, string versionId, StateSummary stateSummary, string referenceDirectory)
    {
        HtmlNode versionNode = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id='{versionId}']");
        if (versionNode == null)
        {
            Console.WriteLine($"[Debug] Version container '{versionId}' not found for state {stateSummary.State}.");
            return;
        }

        List<HtmlNode> links = versionNode.Descendants("a").ToList();
        if (!links.Any())
        {
            Console.WriteLine($"[Debug] No endpoint links found within '{versionId}' for state {stateSummary.State}.");
            return;
        }

        // By setting MaxDegreeOfParallelism, we ensure only a manageable number of requests run at once.
        ParallelOptions parallelOptions = new() { MaxDegreeOfParallelism = 8 };
        await Parallel.ForEachAsync(links, parallelOptions, async (link, cancellationToken) =>
        {
            await ProcessDocumentationLinkAsync(link, stateSummary, referenceDirectory);
        });
    }

    private static async Task ProcessDocumentationLinkAsync(HtmlNode link, StateSummary stateSummary, string referenceDirectory)
    {
        string href = link.GetAttributeValue("href", string.Empty);
        string[] parts = href.Split(new[] { '.' }, 3);
        if (parts.Length != 3) return;

        string sectionName = parts[0].Replace("#", "");
        string endpointKey = parts[1];
        string endpointName = EndpointCleaningRegex().Replace(endpointKey, string.Empty).TrimEnd('_');

        lock (s_summaryLock)
        {
            Section? section = stateSummary.Sections.FirstOrDefault(s => s.Name == sectionName);
            if (section == null)
            {
                section = new Section(sectionName);
                stateSummary.Sections.Add(section);
            }

            if (section.Endpoints.Contains(endpointName)) return;
            section.Endpoints.Add(endpointName);
        }

        string protocol = link.GetAttributeValue("onclick", string.Empty).Contains("http://") ? "http" : "https";
        string url = string.Format(ApiEndpointUrlTemplate, protocol, stateSummary.State, sectionName, $"{endpointKey}.{parts[2]}");
        string? endpointContent = await GetStringContentAsync(url);

        await WriteEndpointDocumentAsync(stateSummary.State, sectionName, endpointKey, endpointContent, referenceDirectory);
    }

    private static async Task WriteEndpointDocumentAsync(string state, string section, string endpointKey, string? content, string referenceDirectory)
    {
        if (string.IsNullOrWhiteSpace(content)) return;
        string directoryPath = Path.Combine(referenceDirectory, section, state);
        _ = Directory.CreateDirectory(directoryPath);

        string filePath = Path.Combine(directoryPath, $"{endpointKey}.html");
        await File.WriteAllTextAsync(filePath, content);
    }

    private static async Task<string?> GetStringContentAsync(string url)
    {
        using HttpClient client = new() { Timeout = TimeSpan.FromSeconds(10) };
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