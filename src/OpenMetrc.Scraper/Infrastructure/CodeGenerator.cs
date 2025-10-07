using System.Text.RegularExpressions;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.CSharp.Models;
using NSwag.CodeGeneration.OperationNameGenerators;
using OpenMetrc.Scraper.Application;
using OpenMetrc.Scraper.Core.Extensions;
using OpenMetrc.Scraper.Core.Services;

namespace OpenMetrc.Scraper.Infrastructure;

public partial class CodeGenerator
{
    public async Task WriteControllerAsync(OpenApiDocument document, string version, string basePath, SchemaGenerationService schemaService)
    {
        const string controllerName = "MetrcBase";
        string controllerNamespace = $"OpenMetrc.{version}.Builder.Controllers";

        //IEnumerable<string> allSections = schemaService.ModelSchemas.Values
        //.Select(info => info.Section)
        //.Distinct();

        //// Get ONLY the sections that actually contain request models.
        //IEnumerable<string> requestSections = schemaService.ModelSchemas.Values
        //    .Where(info => info.IsRequest)
        //    .Select(info => info.Section)
        //    .Distinct();

        //List<string> additionalNamespaces =
        //[
        //    "System.Text.Json", "OpenMetrc.Builder.Domain",
        //    .. allSections.Select(s => $"OpenMetrc.Builder.Domain.{s}"),
        //    .. requestSections.Select(s => $"OpenMetrc.Builder.Domain.{s}.Requests"),
        //];

        try
        {
            CSharpControllerGeneratorSettings settings = new()
            {
                OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),
                GenerateClientInterfaces = true,
                GenerateOptionalParameters = true,
                //AdditionalNamespaceUsages = [.. additionalNamespaces],
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

            CSharpControllerGenerator generator = new(document, settings);
            string code = generator.GenerateFile();

            code = ApplyCodeFixes(code, document);

            string path = Path.Combine(basePath, $"OpenMetrc.{version}.Builder/Controllers", $"{controllerName}Controller.cs");
            _ = Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await File.WriteAllTextAsync(path, code);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($@"Error generating controller '{controllerName}': {ex.Message}");
            Console.ResetColor();
        }
    }

    private static string ApplyCodeFixes(string code, OpenApiDocument document)
    {
        // Pattern 1: A flexible regex for POST and PUT methods
        Regex postPutPattern = new Regex(@"Task\s+(Post\w+|Put\w+)\(");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("DEBUG: Applying POST/PUT regex to generated code...");
        var postPutMatches = postPutPattern.Matches(code);
        Console.WriteLine($"DEBUG: Found {postPutMatches.Count} POST/PUT method matches.");
        foreach (Match m in postPutMatches)
        {
            Console.WriteLine($"DEBUG: Matched method signature: '{m.Value.Trim()}' at index {m.Index}");
        }
        Console.ResetColor();

        code = postPutPattern.Replace(code, match =>
        {
            // e.g., "PostItemsAsync"
            string methodNameWithAsync = match.Groups[1].Value;
            // e.g., "PostItems"
            string operationId = methodNameWithAsync.Replace("Async", "");

            var operation = document.Paths.Values
                .SelectMany(pathItem => pathItem.Values)
                .FirstOrDefault(op => string.Equals(op.OperationId, operationId, StringComparison.OrdinalIgnoreCase));

            // Only add a body if the spec defines one
            if (operation?.RequestBody != null)
            {
                string snakeMethodName = StringUtils.PascalToSnake(operationId);
                string requestModelName = NamingService.GetModelName(snakeMethodName);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"DEBUG: Adding body parameter for method '{operationId}' with request model '{requestModelName}'.");
                Console.ResetColor();

                // Inject the body parameter after the opening parenthesis
                return $"{match.Value}[Microsoft.AspNetCore.Mvc.FromBodyAttribute] [System.ComponentModel.DataAnnotations.Required] System.Collections.Generic.ICollection<{requestModelName}> body,";
            }

            // No request body defined, so leave the method signature untouched
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"DEBUG: No request body for method '{operationId}', leaving signature unchanged.");
            Console.ResetColor();
            return match.Value;
        });

        // Pattern 2: A flexible regex for DELETE methods
        Regex deletePattern = new Regex(@"Task\s+(Delete\w+)\(");
        code = deletePattern.Replace(code, match =>
        {
            string methodNameWithAsync = match.Groups[1].Value;
            string operationId = methodNameWithAsync.Replace("Async", "");

            var operation = document.Paths.Values
                .SelectMany(pathItem => pathItem.Values)
                .FirstOrDefault(op => string.Equals(op.OperationId, operationId, StringComparison.OrdinalIgnoreCase));

            if (operation?.RequestBody != null)
            {
                string snakeMethodName = StringUtils.PascalToSnake(operationId);
                string requestModelName = NamingService.GetModelName(snakeMethodName);

                // Inject the body parameter. NSwag should have already added other [FromQuery] parameters.
                return $"{match.Value}[Microsoft.AspNetCore.Mvc.FromBodyAttribute] [System.ComponentModel.DataAnnotations.Required] System.Collections.Generic.ICollection<{requestModelName}> body,";
            }

            return match.Value;
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