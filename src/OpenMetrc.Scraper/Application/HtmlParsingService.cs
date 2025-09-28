using System.Text.RegularExpressions;
using HtmlAgilityPack;
using NJsonSchema;
using NSwag;
using OpenMetrc.Scraper.Models;

namespace OpenMetrc.Scraper.Application;

public partial class HtmlParsingService
{
    public static readonly Dictionary<string, (JsonObjectType Type, string Format)> KnownParameterTypes = new()
    {
        { "id", (JsonObjectType.Integer, "int64") }, { "packageId", (JsonObjectType.Integer, "int64") },
        { "harvestId", (JsonObjectType.Integer, "int64") }, { "pageNumber", (JsonObjectType.Integer, "int32") },
        { "pageSize", (JsonObjectType.Integer, "int32") }, { "isFromMotherPlant", (JsonObjectType.Boolean, "") },
        { "lastModifiedStart", (JsonObjectType.String, "date-time") },
        { "lastModifiedEnd", (JsonObjectType.String, "date-time") },
        { "checkinDateStart", (JsonObjectType.String, "date") },
        { "checkinDateEnd", (JsonObjectType.String, "date") },
        { "salesDateStart", (JsonObjectType.String, "date") },
        { "salesDateEnd", (JsonObjectType.String, "date") }, { "date", (JsonObjectType.String, "date") }
    };

    [GeneratedRegex(@"\{([^\}]+)\}")]
    private static partial Regex InlineRouteParameterRegex();
    [GeneratedRegex("<.*?>")]
    private static partial Regex StripHtmlTagsRegex();

    internal EndpointInfo ExtractEndpointInfo(HtmlDocument htmlDoc, string section)
    {
        var endpointInfo = new EndpointInfo { Section = section };
        var endpointHeader = htmlDoc.DocumentNode.SelectSingleNode(
            "//h3[starts-with(@id, 'get_') or starts-with(@id, 'post_') or starts-with(@id, 'put_') or starts-with(@id, 'delete_')]");
        if (endpointHeader == null) return endpointInfo;

        var operationId = endpointHeader.GetAttributeValue("id", string.Empty);
        endpointInfo.ReferenceId = operationId;
        endpointInfo.OperationId = operationId;

        var parts = endpointHeader.InnerText.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2) return endpointInfo;
        
        endpointInfo.HttpMethod = parts[0].Trim().ToUpperInvariant();
        endpointInfo.Url = parts[1].Trim();
        
        ExtractRouteParameters(endpointInfo);
        ExtractQueryParameters(htmlDoc, endpointInfo);
        ExtractExamplePayloads(htmlDoc, endpointInfo);

        endpointInfo.Summary = GetEndpointSummary(htmlDoc);
        endpointInfo.Remarks = GetEndpointRemarks(htmlDoc);

        return endpointInfo;
    }

    private void ExtractRouteParameters(EndpointInfo endpointInfo)
    {
        foreach (Match match in InlineRouteParameterRegex().Matches(endpointInfo.Url))
        {
            var paramName = match.Groups[1].Value;
            var (paramType, paramFormat) = GetParameterSchema(paramName);
            endpointInfo.Parameters.Add(new ParameterInfo
                { Name = paramName, Type = paramType, Format = paramFormat, Kind = OpenApiParameterKind.Path });
        }
    }

    private void ExtractQueryParameters(HtmlDocument htmlDoc, EndpointInfo endpointInfo)
    {
        var paramRows = htmlDoc.DocumentNode.SelectNodes(
            "//h4[contains(text(), 'Parameters')]/following-sibling::table[1]/tbody/tr");
        if (paramRows == null) return;

        foreach (var row in paramRows)
        {
            var nameNode = row.SelectSingleNode("td[1]");
            if (nameNode == null || nameNode.InnerText.Contains("No parameters")) continue;
            var paramName = nameNode.InnerText.Replace("optional", "").Trim();
            var (paramType, paramFormat) = GetParameterSchema(paramName, row.InnerHtml);
            endpointInfo.Parameters.Add(new ParameterInfo
            {
                Name = paramName,
                Description = row.SelectSingleNode("td[2]")?.InnerText.Trim() ?? string.Empty,
                IsOptional = row.InnerHtml.Contains("optional", StringComparison.OrdinalIgnoreCase),
                Type = paramType, Format = paramFormat, Kind = OpenApiParameterKind.Query
            });
        }
    }

    private void ExtractExamplePayloads(HtmlDocument htmlDoc, EndpointInfo endpointInfo)
    {
        endpointInfo.ExampleResponse = GetExampleCodeByHeading(htmlDoc, "Example Response");
        if (endpointInfo.HttpMethod is "POST" or "PUT")
            endpointInfo.ExampleRequest = GetExampleCodeByHeading(htmlDoc, "Example Request");
    }

    private string? GetExampleCodeByHeading(HtmlDocument htmlDoc, string headingText) =>
        htmlDoc.DocumentNode.SelectSingleNode($"//h4[contains(text(), '{headingText}')]/following-sibling::pre[1]/code")?.InnerText.Trim();
    
    private (JsonObjectType Type, string Format) GetParameterSchema(string name, string? contextHtml = null)
    {
        if (KnownParameterTypes.TryGetValue(name, out var schema)) return schema;
        return contextHtml?.Contains("timestamp", StringComparison.OrdinalIgnoreCase) == true
            ? (JsonObjectType.String, "date-time")
            : (JsonObjectType.String, string.Empty);
    }

    internal string GetEndpointSummary(HtmlDocument htmlDoc) =>
        htmlDoc.DocumentNode.SelectSingleNode("//p[@class='lead']")?.InnerText.Trim() ?? string.Empty;
    
    internal string GetEndpointRemarks(HtmlDocument htmlDoc)
    {
        var permissions = new List<string>();
        var permissionsTable = htmlDoc.DocumentNode.SelectNodes(
            "//h4[contains(text(), 'Permissions Required')]/following-sibling::table[1]/tbody/tr");
        if (permissionsTable != null)
            permissions.AddRange(from row in permissionsTable
                let permission = row.SelectSingleNode("td[1]")?.InnerText.Trim()
                where !string.IsNullOrEmpty(permission) && permission != "None"
                select StripHtmlTagsRegex().Replace(permission, string.Empty));
        var permissionsText = permissions.Any() ? string.Join(" • ", permissions) : "<i>none</i>";
        var descriptionNode = htmlDoc.DocumentNode.SelectSingleNode(
            "//h3[starts-with(@id, 'get_') or starts-with(@id, 'post_') or starts-with(@id, 'put_') or starts-with(@id, 'delete_')]/following-sibling::p");
        var description = descriptionNode?.InnerText.Trim() ?? string.Empty;
        return $"{description}{(!string.IsNullOrWhiteSpace(description) ? "<br/>" : "")}<b>Permissions Required</b>: {permissionsText}";
    }
}