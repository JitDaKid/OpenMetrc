using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace OpenMetrc.Scraper.Core.Extensions;
internal static partial class StringUtils
{
    private static readonly char[] WordSeparators = { '_', '-', ' ' };

    [GeneratedRegex(@"\{.*?\}")]
    private static partial Regex CurlyBraceParameterRegex();
    [GeneratedRegex(@"_v\d+", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex InlineVersionRegex();

    internal static string RemoveParametersAndVersions(string sanitized)
    {
        sanitized = CurlyBraceParameterRegex().Replace(sanitized, "");
        sanitized = InlineVersionRegex().Replace(sanitized, "");
        return sanitized.Trim('_');
    }

    internal static string GetInnerTrimmed(HtmlDocument htmlDoc, string singleNode)
    {
        HtmlNode descriptionNode = htmlDoc.DocumentNode.SelectSingleNode($"{singleNode}");
        string description = descriptionNode?.InnerText.Trim() ?? string.Empty;
        return description;
    }

    /// <summary>
    /// Converts a snake_case or kebab-case string to PascalCase.
    /// </summary>
    internal static string SnakeToPascal(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
        string[] words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(string.Empty, words.Select(textInfo.ToTitleCase));
    }

    /// <summary>
    /// Turns a PascalCase string into a snake case string separated by underscores.
    /// </summary>
    /// <param name="pascalCaseString">The input PascalCase string.</param>
    /// <returns>A string with underscores inserted between words.</returns>
    internal static string PascalToSnake(this string pascalCaseString)
    {
        if (string.IsNullOrEmpty(pascalCaseString))
        {
            return pascalCaseString;
        }

        StringBuilder sb = new();
        for (int i = 0; i < pascalCaseString.Length; i++)
        {
            char currentChar = pascalCaseString[i];

            // If it's an uppercase letter and not the first character,
            // and the previous character wasn't an underscore or another uppercase letter
            if (char.IsUpper(currentChar) && i > 0 &&
                pascalCaseString[i - 1] != '_' && !char.IsUpper(pascalCaseString[i - 1]))
            {
                _ = sb.Append('_');
            }
            _ = sb.Append(char.ToLower(currentChar, CultureInfo.InvariantCulture));
        }
        return sb.ToString();
    }
}
