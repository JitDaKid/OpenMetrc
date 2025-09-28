using NSwag;

namespace OpenMetrc.Scraper.Application.Contracts;

public interface ICodeGenerator
{
    Task WriteControllerAsync(OpenApiDocument document, string version, string basePath, SchemaGenerationService schemaService);
}