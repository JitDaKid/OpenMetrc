using System.Globalization;
using System.Text.RegularExpressions;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.CSharp.Models;
using NSwag.CodeGeneration.OperationNameGenerators;
using OpenMetrc.Scraper.Application;
using OpenMetrc.Scraper.Application.Contracts;

namespace OpenMetrc.Scraper.Infrastructure;

public partial class CodeGenerator : ICodeGenerator
{
    public async Task WriteControllerAsync(OpenApiDocument document, string version, string basePath, SchemaGenerationService schemaService)
    {
        const string controllerName = "MetrcBase";
        var controllerNamespace = $"OpenMetrc.{version}.Builder.Controllers";

        var allSections = schemaService.ModelSchemas.Values
        .Select(info => info.Section)
        .Distinct();

        // Get ONLY the sections that actually contain request models.
        var requestSections = schemaService.ModelSchemas.Values
            .Where(info => info.IsRequest)
            .Select(info => info.Section)
            .Distinct();

        var additionalNamespaces = new List<string> { "System.Text.Json", "OpenMetrc.Builder.Domain" };
        additionalNamespaces.AddRange(allSections.Select(s => $"OpenMetrc.Builder.Domain.{s}"));
        additionalNamespaces.AddRange(requestSections.Select(s => $"OpenMetrc.Builder.Domain.{s}.Requests"));


        try
        {
            var settings = new CSharpControllerGeneratorSettings
            {
                OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),
                GenerateClientInterfaces = true,
                GenerateOptionalParameters = true,
                AdditionalNamespaceUsages = additionalNamespaces.ToArray(),
                ControllerTarget = CSharpControllerTarget.AspNetCore,
                ControllerStyle = CSharpControllerStyle.Abstract,
                CodeGeneratorSettings = { SchemaType = SchemaType.OpenApi3 },
                CSharpGeneratorSettings =
                {
                    Namespace = controllerNamespace,
                    JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                    GenerateNullableReferenceTypes = true,
                    GenerateDefaultValues = true,
                    GenerateDataAnnotations = true,
                    GenerateNativeRecords = true,
                    DateType = "DateOnly",
                    PropertyNameGenerator = new CustomPropertyNameGenerator()
                }
            };

            var generator = new CSharpControllerGenerator(document, settings);
            var code = generator.GenerateFile();

            code = ApplyCodeFixes(code);

            var path = Path.Combine(basePath, $"OpenMetrc.{version}.Builder/Controllers", $"{controllerName}Controller.cs");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await File.WriteAllTextAsync(path, code);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($@"Error generating controller '{controllerName}': {ex.Message}");
            Console.ResetColor();
        }
    }

    private string ApplyCodeFixes(string code)
    {
        var postPutPattern = PostPutRegex();
        code = postPutPattern.Replace(code, match =>
        {
            var methodName = match.Groups[1].Value;
            var snakeMethodName = NamingService.ToSnakeCase(methodName);
            var requestModelName = NamingService.GetModelName(snakeMethodName, isRequest: true);
            var prefix = match.Groups[0].Value;

            return $"{prefix}[System.ComponentModel.DataAnnotations.Required] System.Collections.Generic.List<{requestModelName}> body, ";
        });

        var deletePattern = DeleteRegex();
        code = deletePattern.Replace(code, match =>
        {
            var methodName = match.Groups[1].Value;
            Console.WriteLine($@"methodName ' {methodName} '");
            var snakeMethodName = NamingService.ToSnakeCase(methodName);
            var requestModelName = NamingService.GetModelName(snakeMethodName, isRequest: true);
            Console.WriteLine($@"requestModelName ' {requestModelName} '");


            var prefix = match.Groups[1].Value;;

            return $"Task {prefix}([System.ComponentModel.DataAnnotations.Required] System.Collections.Generic.List<{requestModelName}> body, [Microsoft.AspNetCore.Mvc.FromQuery] string licenseNumber";
        });

        return code.Replace("HttpDELETE", "HttpDelete")
            .Replace("HttpGET", "HttpGet")
            .Replace("HttpPUT", "HttpPut")
            .Replace("HttpPOST", "HttpPost")
            .Replace(", )", ")").Replace("<br/>", "").Replace("<br />", "");
    }

    [GeneratedRegex(@"Task\s+(Post\w+|Put\w+)\(")]
    private static partial Regex PostPutRegex();

    [GeneratedRegex(@"Task\s+(Delete\w+)\(\[Microsoft.AspNetCore.Mvc.FromQuery\] string licenseNumber")]
    private static partial Regex DeleteRegex();

}