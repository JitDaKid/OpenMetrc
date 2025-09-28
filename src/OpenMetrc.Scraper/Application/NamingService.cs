using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Humanizer;

namespace OpenMetrc.Scraper.Application;

public static partial class NamingService
{
    private static readonly char[] WordSeparators = { '_', '-', ' ' };
    private static readonly Dictionary<string, string> MethodNameCache = new();
    private static readonly Dictionary<string, string> ModelNameCache = new();
    private static readonly Dictionary<string, string> OperationIdReplacements = new()
    {
        { "_{id}", "_by_id" }, { "{id}", "by_id" }, { "_{salesDateStart}_{salesDateEnd}", "_by_date_range" },
        { "_{label}", "_by_label" }, { "labtestdocument", "lab_test_document" },
        { "labtest", "lab_test" }, { "labsample", "lab_sample" }, { "removewaste", "remove_waste" },
        { "checkins", "check_ins" }, { "moveplantbatch", "move_plant_batch" },
        { "plantbatch", "plant_batch" }, { "changegrowthphase", "change_growth_phase" },
        { "growthphase", "growth_phase" }, { "createpackages", "create_packages" },
        { "createplantings", "create_plantings" }, { "frommotherplant", "from_mother_plant" },
        { "onhold", "on_hold" }, { "bylocation", "by_location" }, { "harvestplants", "harvest_plants" },
        { "manicureplants", "manicure_plants" }, { "moveplants", "move_plants" },
        { "jobtype", "job_type" }, { "customertype", "customer_type" },
        { "patientregistration", "patient_registration" }, { "verifyID", "verify_id" },
        { "returnreason", "return_reason" }, { "paymenttype", "payment_type" },
        { "requiredlab", "required_lab" }, { "testbatch", "test_batch" },
        { "unitsofmeasure", "units_of_measure" }, { "harvestedplants", "harvested_plants" },
        { "tradesample", "trade_sample" }, { "wastemethod", "waste_method" },
        { "usebydate", "use_by_date" }, {"harvestedplant", "harvested_plant" }, {"additivestemplate", "additives_template"},
        {"createpackage", "create_package"}
    };

    [GeneratedRegex(@"\{.*?\}")]
    private static partial Regex CurlyBraceParameterRegex();
    [GeneratedRegex(@"_v\d+", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex InlineVersionRegex();

    /// <summary>
    /// Cleans a raw operation ID into a PascalCase C# method name.
    /// </summary>
    public static string GetMethodName(string rawOperationId)
    {
        if (MethodNameCache.TryGetValue(rawOperationId, out var cachedId)) return cachedId;
        var sanitizedId = Sanitize(rawOperationId);
        var finalId = ConvertToPascalCase(sanitizedId);
        MethodNameCache.TryAdd(rawOperationId, finalId);
        return finalId;
    }

    /// <summary>
    /// Derives a correctly-cased C# model name from a raw operation ID.
    /// </summary>
    public static string GetModelName(string rawOperationId, bool isRequest)
    {
        var cacheKey = $"{rawOperationId}_{isRequest}";
        if (ModelNameCache.TryGetValue(cacheKey, out var cachedName)) return cachedName;

        var sanitizedId = Sanitize(rawOperationId);
        var words = sanitizedId.Split('_').ToList();

        if (words.FirstOrDefault() is "get" or "post" or "put" or "delete")
            words.RemoveAt(0);

        var singularWords = words.Select(word => word.Singularize(inputIsKnownToBePlural: false));
        var baseModelName = string.Join("_", singularWords);

        if (isRequest)
            baseModelName += "_request";

        var finalName = ConvertToPascalCase(baseModelName);
        ModelNameCache.TryAdd(cacheKey, finalName);
        return finalName;
    }

    /// <summary>
    /// Turns a PascalCase string into a snake case string separated by underscores.
    /// </summary>
    /// <param name="pascalCaseString">The input PascalCase string.</param>
    /// <returns>A string with underscores inserted between words.</returns>
    public static string ToSnakeCase(this string pascalCaseString)
    {
        if (string.IsNullOrEmpty(pascalCaseString))
        {
            return pascalCaseString;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < pascalCaseString.Length; i++)
        {
            char currentChar = pascalCaseString[i];

            // If it's an uppercase letter and not the first character,
            // and the previous character wasn't an underscore or another uppercase letter
            if (char.IsUpper(currentChar) && i > 0 &&
                (pascalCaseString[i - 1] != '_' && !char.IsUpper(pascalCaseString[i - 1])))
            {
                sb.Append('_');
            }
            sb.Append(char.ToLower(currentChar, CultureInfo.InvariantCulture));
        }
        return sb.ToString();
    }

    /// <summary>
    /// Performs initial cleaning on a raw ID string, returning a sanitized snake_case string.
    /// </summary>
    private static string Sanitize(string raw)
    {
        var sanitized = raw.ToLowerInvariant();
        foreach (var (key, value) in OperationIdReplacements)
            sanitized = sanitized.Replace(key, value, StringComparison.InvariantCultureIgnoreCase);

        sanitized = CurlyBraceParameterRegex().Replace(sanitized, "");
        sanitized = InlineVersionRegex().Replace(sanitized, "");
        return sanitized.Trim('_');
    }

    /// <summary>
    /// Converts a snake_case or kebab-case string to PascalCase.
    /// </summary>
    private static string ConvertToPascalCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var textInfo = CultureInfo.InvariantCulture.TextInfo;
        var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(string.Empty, words.Select(w => textInfo.ToTitleCase(w)));
    }
}