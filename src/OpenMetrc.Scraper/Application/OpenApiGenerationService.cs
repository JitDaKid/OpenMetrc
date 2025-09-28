using HtmlAgilityPack;
using NSwag;

namespace OpenMetrc.Scraper.Application;

public class OpenApiGenerationService
{
    private readonly HtmlParsingService _htmlParser;

    public OpenApiGenerationService(HtmlParsingService htmlParser)
    {
        _htmlParser = htmlParser;
    }

    public OpenApiDocument Generate(IEnumerable<string> htmlFilePaths, string version, SchemaGenerationService schemaService)
    {
        var document = new OpenApiDocument
        {
            Info = new OpenApiInfo { Title = "METRC API", Version = version }
        };

        foreach (var filePath in htmlFilePaths)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);
            var section = new DirectoryInfo(filePath).Parent?.Parent?.Name ?? "Misc";

            var endpointInfo = _htmlParser.ExtractEndpointInfo(htmlDoc, section);
            if (string.IsNullOrWhiteSpace(endpointInfo.Url)) continue;

            schemaService.DiscoverSchemasFromEndpoint(endpointInfo);

            if (!document.Paths.TryGetValue(endpointInfo.Url, out var pathItem))
            {
                pathItem = new OpenApiPathItem();
                document.Paths.Add(endpointInfo.Url, pathItem);
            }
            var operation = new OpenApiOperation
            {
                Summary = endpointInfo.Summary,
                Description = endpointInfo.Remarks,
                OperationId = NamingService.GetMethodName(endpointInfo.OperationId),
            };

            foreach (var parameter in endpointInfo.Parameters) operation.Parameters.Add(parameter.OpenApiParameter);
            operation.Responses.Add("200", new OpenApiResponse { Description = "Ok" });
            operation.Tags.Add(section);
            pathItem.TryAdd(endpointInfo.HttpMethod, operation);
        }
        schemaService.LinkDiscoveredSchemas();
        return document;
    }
}