using System.Text.RegularExpressions;
using Humanizer;
using OpenMetrc.Scraper.Core.Extensions;

namespace OpenMetrc.Scraper.Application;

public static partial class NamingService
{
    private static readonly Dictionary<string, string> MethodNameCache = [];
    private static readonly Dictionary<string, string> ModelNameCache = [];
    private static readonly Dictionary<string, string> OperationIdReplacements = new()
    {
        { "_{id}", "_by_id" }, 
        { "{id}", "by_id" }, 
        { "_{salesDateStart}_{salesDateEnd}", "_by_date_range" },
        { "_{label}", "_by_label" }, 
        { "labtestdocument", "lab_test_document" },
        { "labtest", "lab_test" }, 
        { "labsample", "lab_sample" }, 
        { "removewaste", "remove_waste" },
        { "checkins", "check_ins" }, 
        { "moveplantbatch", "move_plant_batch" },
        { "plantbatch", "plant_batch" }, 
        { "changegrowthphase", "change_growth_phase" },
        { "growthphase", "growth_phase" }, 
        { "createpackages", "create_packages" },
        { "createplantings", "create_plantings" }, 
        { "frommotherplant", "from_mother_plant" },
        { "onhold", "on_hold" }, 
        { "bylocation", "by_location" }, 
        { "harvestplants", "harvest_plants" },
        { "manicureplants", "manicure_plants" }, 
        { "moveplants", "move_plants" },
        { "jobtype", "job_type" }, 
        { "customertype", "customer_type" },
        { "patientregistration", "patient_registration" }, 
        { "verifyID", "verify_id" },
        { "returnreason", "return_reason" }, 
        { "paymenttype", "payment_type" },
        { "requiredlab", "required_lab" }, 
        { "testbatch", "test_batch" },
        { "unitsofmeasure", "units_of_measure" }, 
        { "harvestedplants", "harvested_plants" },
        { "tradesample", "trade_sample" }, 
        { "wastemethod", "waste_method" },
        { "usebydate", "use_by_date" }, 
        { "harvestedplant", "harvested_plant" }, 
        { "additivestemplate", "additives_template" },
        { "createpackage", "create_package" }
    };

    /// <summary>
    /// Cleans a raw operation ID into a PascalCase C# method name.
    /// </summary>
    public static string GetMethodName(string rawOperationId)
    {
        if (MethodNameCache.TryGetValue(rawOperationId, out string? cachedId)) return cachedId;
        string sanitizedId = Sanitize(rawOperationId);
        string finalId = StringUtils.SnakeToPascal(sanitizedId);
        _ = MethodNameCache.TryAdd(rawOperationId, finalId);
        return finalId;
    }

    /// <summary>
    /// Derives a correctly-cased C# model name from a raw operation ID.
    /// </summary>
    public static string GetModelName(string rawOperationId)
    {
        string cacheKey = $"{rawOperationId}";
        if (ModelNameCache.TryGetValue(cacheKey, out string? cachedName)) return cachedName;

        string sanitizedId = Sanitize(rawOperationId);
        List<string> words = sanitizedId.Split('_').ToList();

        if (words.FirstOrDefault() is "get" or "post" or "put" or "delete")
            words.RemoveAt(0);

        IEnumerable<string> singularWords = words.Select(word => word.Singularize(inputIsKnownToBePlural: false));
        string baseModelName = string.Join("_", singularWords);

        //if (isRequest) baseModelName += "_request";

        string finalName = StringUtils.SnakeToPascal(baseModelName);
        _ = ModelNameCache.TryAdd(cacheKey, finalName);
        return finalName;
    }

    /// <summary>
    /// Performs initial cleaning on a raw ID string, returning a sanitized snake_case string.
    /// </summary>
    private static string Sanitize(string raw)
    {
        string sanitized = raw.ToLowerInvariant();
        foreach ((string key, string value) in OperationIdReplacements)
            sanitized = sanitized.Replace(key, value, StringComparison.InvariantCultureIgnoreCase);

        sanitized = StringUtils.RemoveParametersAndVersions(sanitized);
        return sanitized.Trim('_');
    }
}