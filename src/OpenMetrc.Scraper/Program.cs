using System.Collections.Concurrent;
using Corvus.Json.CodeGeneration;
using OpenMetrc.Scraper;
using OpenMetrc.Scraper.Application;
using OpenMetrc.Scraper.Application.Contracts;
using OpenMetrc.Scraper.Infrastructure;
using OpenMetrc.Scraper.Models;

// --- Services & Setup ---
var htmlParser = new HtmlParsingService();
var openApiService = new OpenApiGenerationService(htmlParser);
var fileWriter = new FileWriter();
var modelGenerator = new AotModelGenerator();
var controllerGenerator = new OpenMetrc.Scraper.Infrastructure.CodeGenerator();
var states = new List<string>
{
    "al", "ak", "az", "ar", "ca", "cz", "co", "ct", "de", "dc", "fl", "ga", "gu", "hi", "id", "il", "in", "ia",
    "ks", "ky", "la", "me", "md", "ma", "mi", "mn", "ms", "mo", "mt", "ne", "nv", "nh", "nj", "nm", "ny", "nc", "nd",
    "oh", "ok", "or", "pa", "pr", "ri", "sc", "sd", "tn", "tx", "ut", "vt", "vi", "va", "wa", "wv", "wi", "wy"
};

var errors = new ConcurrentBag<Exception>();
const string referenceDirectory = "../../../Reference";
const string basePath = "../../../../";

// --- Get user input from console ---
Console.Write("Scrape for fresh data? (Y/n): ");
var userInput = Console.ReadLine();
// Default to YES unless the user explicitly types 'n' or 'N'.
var scrapeFreshData = !userInput?.Trim().Equals("n", StringComparison.OrdinalIgnoreCase) ?? true;

Console.WriteLine("---"); // Separator for clarity

if (scrapeFreshData)
{
    // --- Phase 1: Scraping ---
    Console.WriteLine("Phase 1: Scraping fresh state documentation...");
    StateService.DeleteReferenceDocuments();
    var stateSummaries = new ConcurrentBag<StateSummary>();

    var scrapingTasks = states.Select(async state =>
    {
        try
        {
            var stateSummary = await StateService.ProcessState(state);
            if (stateSummary.Sections.Any())
            {
                stateSummaries.Add(stateSummary);
                Console.WriteLine($"Scraped: {state.ToUpper()}");
            }
        }
        catch (Exception)
        {
            // Handle or log errors as needed
        }
    });
    await Task.WhenAll(scrapingTasks);
    await StateService.WriteStateSummariesAsync(stateSummaries.ToList());
}
else
{
    Console.WriteLine("Phase 1: Skipping scraping. Using existing local files in 'Reference' directory.");
}


// --- Phase 2: Verification ---
if (!Directory.Exists(referenceDirectory))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nError: The 'Reference' directory was not created.");
    Console.WriteLine("This means the scraping phase failed to download any documentation.");
    Console.ResetColor();
    return;
}

// --- Phase 3: Processing & Generation ---
Console.WriteLine("\nPhase 2: Generating OpenAPI specifications and C# models...");

// --- Process V1 ---
var v1Files = Directory.GetFiles(referenceDirectory, "*_v1*.html", SearchOption.AllDirectories);
if (v1Files.Length > 0)
{
    var schemaServiceV1 = new SchemaGenerationService();
    // Pass 1: Discover all schemas
    var v1Document = openApiService.Generate(v1Files, "v1", schemaServiceV1);
    // Pass 2: Link schemas together
    schemaServiceV1.LinkDiscoveredSchemas();
    Console.WriteLine($"V1 specification and {schemaServiceV1.ModelSchemas.Count} schemas generated in memory.");

    // Generate the C# code strings in memory
    var generatedCodeV1 = modelGenerator.Generate(schemaServiceV1.ModelSchemas);
    Console.WriteLine($"[Generator] V1: Generated {generatedCodeV1.Count} C# files in memory.");

    // Write the OpenAPI spec and the generated C# files to disk
    await fileWriter.WriteOpenApiDocumentAsync(v1Document);
    var v1DomainPath = Path.Combine(basePath, "OpenMetrc.V1.Builder/Domain");
    if (Directory.Exists(v1DomainPath)) Directory.Delete(v1DomainPath, true);
    foreach (var (relativeFilePath, code) in generatedCodeV1)
    {
        var fullPath = Path.Combine(v1DomainPath, relativeFilePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        await File.WriteAllTextAsync(fullPath, code);
    }
    Console.WriteLine("[Generator] V1: Wrote C# model files to disk.");
    await controllerGenerator.WriteControllerAsync(v1Document, "V1", basePath, schemaServiceV1);
}
else
{
    Console.WriteLine("V1 processing skipped: No v1 documentation files found.");
}

// --- Process V2 (Same updated logic) ---
var v2Files = Directory.GetFiles(referenceDirectory, "*_v2*.html", SearchOption.AllDirectories);
if (v2Files.Length > 0)
{
    var schemaServiceV2 = new SchemaGenerationService();
    var v2Document = openApiService.Generate(v2Files, "v2", schemaServiceV2);
    schemaServiceV2.LinkDiscoveredSchemas();
    Console.WriteLine($"V2 specification and {schemaServiceV2.ModelSchemas.Count} schemas generated in memory.");

    var generatedCodeV2 = modelGenerator.Generate(schemaServiceV2.ModelSchemas);
    Console.WriteLine($"[Generator] V2: Generated {generatedCodeV2.Count} C# files in memory.");

    await fileWriter.WriteOpenApiDocumentAsync(v2Document);
    var v2DomainPath = Path.Combine(basePath, "OpenMetrc.V2.Builder/Domain");
    if (Directory.Exists(v2DomainPath)) Directory.Delete(v2DomainPath, true);
    foreach (var (relativeFilePath, code) in generatedCodeV2)
    {
        var fullPath = Path.Combine(v2DomainPath, relativeFilePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        await File.WriteAllTextAsync(fullPath, code);
    }
    Console.WriteLine("[Generator] V2: Wrote C# model files to disk.");
    await controllerGenerator.WriteControllerAsync(v2Document, "V2", basePath, schemaServiceV2);
}
else
{
    Console.WriteLine("V2 processing skipped: No v2 documentation files found.");
}

// --- Final Summary ---
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($@"Scraping and generation complete.");
if (!errors.IsEmpty)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Encountered {errors.Count} errors:");
    foreach (var exception in errors)
        Console.WriteLine($"- {exception.Message}");
}
Console.ResetColor();