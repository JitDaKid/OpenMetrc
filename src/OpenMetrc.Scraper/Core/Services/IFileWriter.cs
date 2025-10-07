using NSwag;

namespace OpenMetrc.Scraper.Core.Services;
public interface IFileWriter
{
    Task WriteOpenApiDocumentAsync(OpenApiDocument document);
}