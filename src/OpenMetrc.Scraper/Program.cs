using System.Collections.Concurrent;
using OpenMetrc.Scraper;
using OpenMetrc.Scraper.Models;

// List of all possible states and province codes
var states = new List<string>
{
    "al", "ak", "az", "ar", "ca", "cz", "co", "ct", "de", "dc", "fl", "ga", "gu", "hi", "id", "il", "in", "ia",
    "ks", "ky", "la", "me", "md", "ma", "mi", "mn", "ms", "mo", "mt", "ne", "nv", "nh", "nj", "nm", "ny", "nc", "nd",
    "oh", "ok", "or", "pa", "pr", "ri", "sc", "sd", "tn", "tx", "ut", "vt", "vi", "va", "wa", "wv", "wi", "wy"
};

List<StateSummary> finalStateSummaries;

Console.WriteLine("Use previously scraped data? (Y/N)");
string? useExistingDataInput = Console.ReadLine()?.Trim().ToUpper();
bool useExistingData = useExistingDataInput == "Y";

if (!useExistingData)
{
    Console.WriteLine("Starting fresh scrape...");
    var stateSummaries = new ConcurrentBag<StateSummary>();
    double stateCounter = 0;
    var consoleLock = new object();
    var errors = new ConcurrentBag<Exception>();

    StateService.DeleteReferenceDocuments();

    Parallel.ForEach(states, state =>
    {
        try
        {
            var stateSummary = StateService.ProcessState(state).Result;

            // Thread-safe increment of the counter and console update
            lock (consoleLock)
            {
                stateCounter++;
                Console.Write($"\rScanning: {state} {stateCounter / states.Count:P}    ");
            }

            stateSummaries.Add(stateSummary);
        }
        catch (Exception ex)
        {
            errors.Add(ex);
        }
    });

    Console.WriteLine(); // New line after progress bar

    if (!errors.IsEmpty)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var exception in errors) Console.WriteLine(exception.Message);
        Console.ResetColor();
        Console.WriteLine();
    }

    finalStateSummaries = stateSummaries.ToList();
    await StateService.WriteStateSummary(finalStateSummaries);
    Console.WriteLine("Fresh scrape and summary file written.");
}
else
{
    Console.WriteLine("Using existing scraped data...");
    finalStateSummaries = await StateService.ReadStateSummary();

    if (finalStateSummaries == null || !finalStateSummaries.Any())
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: Could not read existing data or data file is empty.");
        Console.WriteLine("Please run a fresh scrape first.");
        Console.ResetColor();
        return; // Exit if data can't be loaded
    }
    Console.WriteLine("Existing data loaded.");
}

// Continue with document and controller generation
var v1Document = OpenApiService.CreateOpenApiDocument("../../../Reference", "v1");
await OpenApiService.WriteOpenApiDocument(v1Document);
var v2Document = OpenApiService.CreateOpenApiDocument("../../../Reference", "v2");
await OpenApiService.WriteOpenApiDocument(v2Document);

await OpenApiService.CreateController(v1Document, "V1");

await OpenApiService.CreateController(v2Document, "V2");

Console.WriteLine($@"Summary: 
States Found: {finalStateSummaries.Count}");
Console.ResetColor();