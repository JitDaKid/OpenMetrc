using NSwag;

namespace OpenMetrc.Scraper.Application.Contracts;
public interface IFileWriter
{
    Task WriteOpenApiDocumentAsync(OpenApiDocument document);
    Task WriteSchemasAsync(string version, string basePath, SchemaGenerationService schemaService);
}