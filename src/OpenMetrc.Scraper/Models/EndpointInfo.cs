namespace OpenMetrc.Scraper.Models;
public class EndpointInfo
{
    public string Section { get; set; } = null!;
    public string? Summary { get; set; }
    public string? Remarks { get; set; }
    public string ReferenceId { get; set; } = null!;
    public string OperationId { get; set; } = null!;
    public string HttpMethod { get; set; } = null!;
    public string Url { get; set; } = null!;
    public List<ParameterInfo> Parameters { get; set; } = new();
    public string? ExampleRequest { get; set; }
    public string? ExampleResponse { get; set; }
}