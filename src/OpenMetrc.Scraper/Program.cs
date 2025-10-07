using System.Collections.Concurrent;
using OpenMetrc.Scraper;
using OpenMetrc.Scraper.Application;
using OpenMetrc.Scraper.Core.Models;
using OpenMetrc.Scraper.Core.Utils;
using OpenMetrc.Scraper.Infrastructure;

Console.WriteLine("=== METRC Schema Generator ===");

HtmlParsingService htmlParser = new();

List<string> states =
[
    "al", "ak", "az", "ar", "ca", "cz", "co", "ct", "de", "dc", "fl", "ga", "gu", "hi", "id", "il", "in", "ia",
    "ks", "ky", "la", "me", "md", "ma", "mi", "mn", "ms", "mo", "mt", "ne", "nv", "nh", "nj", "nm", "ny", "nc", "nd",
    "oh", "ok", "or", "pa", "pr", "ri", "sc", "sd", "tn", "tx", "ut", "vt", "vi", "va", "wa", "wv", "wi", "wy"
];

const string referenceDirectory = "../../../Reference";
const string basePath = "../../../../";
const string schemaOutputPath = "../../../../GeneratedSchemas";

ConcurrentBag<Exception> errors = [];

Console.Write("Scrape for fresh data? (Y/n): ");
string? userInput = Console.ReadLine();
bool scrapeFreshData = !userInput?.Trim().Equals("n", StringComparison.OrdinalIgnoreCase) ?? true;

if (scrapeFreshData)
{
    Console.WriteLine("Phase 1: Scraping fresh state documentation...");
    StateService.DeleteReferenceDocuments(referenceDirectory);

    ConcurrentBag<StateSummary> stateSummaries = [];

    IEnumerable<Task> scrapingTasks = states.Select(async state =>
    {
        try
        {
            StateSummary stateSummary = await StateService.ProcessState(state, referenceDirectory);
            if (stateSummary.Sections.Count != 0)
            {
                stateSummaries.Add(stateSummary);
                Console.WriteLine($"Scraped: {state.ToUpper()}");
            }
        }
        catch (Exception ex)
        {
            errors.Add(ex);
            Console.WriteLine($"[ERROR] {state.ToUpper()}: {ex.Message}");
        }
    });

    await Task.WhenAll(scrapingTasks);
    await StateService.WriteStateSummariesAsync([.. stateSummaries], "../../../../../state-summaries.json");
}
else
{
    Console.WriteLine("Phase 1: Skipping scraping. Using existing local files in 'Reference' directory.");
}

// --- Verify ---
if (!Directory.Exists(referenceDirectory))
{
    ConsoleWriter.WriteLines(
        "The 'Reference' directory does not exist.",
        "This indicates the scraping phase was not completed successfully.",
        "Please ensure you have an active internet connection and try running the scraper again.");
    return;
}

// --- Phase 2: Schema Discovery Only ---
Console.WriteLine("\nPhase 2: Discovering schemas from documentation...");

Directory.CreateDirectory(schemaOutputPath);

await ProcessSchemas("v1", referenceDirectory, schemaOutputPath);
await ProcessSchemas("v2", referenceDirectory, schemaOutputPath);

Console.WriteLine("\n✅ Schema extraction complete!");
Console.WriteLine($"Schemas written to: {Path.GetFullPath(schemaOutputPath)}");

return;

// --------------------------------------------------------------------
// Local helper method
// --------------------------------------------------------------------
static async Task ProcessSchemas(string version, string referenceDirectory, string outputDirectory)
{
    string[] htmlFiles = Directory.GetFiles(referenceDirectory, $"*_{version}*.html", SearchOption.AllDirectories);
    if (htmlFiles.Length == 0) return;

    var htmlParser = new HtmlParsingService();
    var schemaService = new SchemaGenerationService();

    foreach (var filePath in htmlFiles)
    {
        var exampleSchema = new HtmlSchemaExtractor().GenerateSchemaFromHtml(File.ReadAllText(filePath));
        if (exampleSchema == null) continue;

        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.Load(filePath);
        string section = new DirectoryInfo(filePath).Parent?.Parent?.Name ?? "Misc";
    }

    // Write all schemas to one file
    string versionPath = Path.Combine(outputDirectory, version.ToUpper());
    Directory.CreateDirectory(versionPath);
    var combinedRoot = schemaService.BuildRootSchema();
    string filePathOut = Path.Combine(versionPath, "AllSchemas.json");
    await File.WriteAllTextAsync(filePathOut, combinedRoot.ToJson());

    Console.WriteLine($"{version.ToUpper()}: Discovered {schemaService.ModelSchemas.Count} schemas.");
    Console.WriteLine($"{version.ToUpper()}: Wrote schemas to {filePathOut}");
}