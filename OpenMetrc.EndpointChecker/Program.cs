using System.Text.Json;

// --- Helper Methods ---
static List<string> GetSectionDifferences(List<Section> baseSections, List<Section> compareSections)
{
    var differences = new List<string>();

    // Filter out sections with zero endpoints in the compared state
    var filteredCompareSections = compareSections.Where(s => s.Endpoints.Any()).ToList();
    var filteredBaseSections = baseSections.Where(s => s.Endpoints.Any()).ToList();

    var baseDict = filteredBaseSections.ToDictionary(s => s.Name, s => s);
    var compareDict = filteredCompareSections.ToDictionary(s => s.Name, s => s);

    // Check for missing or extra sections
    var missingSections = baseDict.Keys.Except(compareDict.Keys).ToList();
    var extraSections = compareDict.Keys.Except(baseDict.Keys).ToList();

    if (missingSections.Any())
        differences.Add($"Missing sections: {string.Join(", ", missingSections)}");
    if (extraSections.Any())
        differences.Add($"Extra sections: {string.Join(", ", extraSections)}");

    // Compare matching sections
    foreach (var sectionName in baseDict.Keys.Intersect(compareDict.Keys))
    {
        var baseSec = baseDict[sectionName];
        var cmpSec = compareDict[sectionName];

        var missingInCompare = baseSec.Endpoints.Except(cmpSec.Endpoints).ToList();
        var extraInCompare = cmpSec.Endpoints.Except(baseSec.Endpoints).ToList();

        if (missingInCompare.Any())
            differences.Add($"Section '{sectionName}' missing endpoints: {string.Join(", ", missingInCompare)}");
        if (extraInCompare.Any())
            differences.Add($"Section '{sectionName}' extra endpoints: {string.Join(", ", extraInCompare)}");
    }

    return differences;
}

var json = await File.ReadAllTextAsync("state-summaries.json");
var states = JsonSerializer.Deserialize<List<StateDefinition>>(json)!;

bool allSimilar = true;
var firstState = states.First();

foreach (var state in states.Skip(1))
{
    var diffs = GetSectionDifferences(firstState.Sections, state.Sections);
    if (diffs.Any())
    {
        Console.WriteLine($"State {state.State} differs from {firstState.State}:");
        foreach (var diff in diffs)
            Console.WriteLine($"  - {diff}");
        allSimilar = false;
    }
}

if (allSimilar)
    Console.WriteLine("✅ All states have similar sections and endpoints.");

// Helper classes
public class StateDefinition
{
    public string State { get; set; } = "";
    public List<Section> Sections { get; set; } = new();
}

public class Section
{
    public string Name { get; set; } = "";
    public List<string> Endpoints { get; set; } = new();
}