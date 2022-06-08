using System.Text.Json;
using System.Text.Json.Serialization;

namespace NubimetricsChallengeCurrency.ConsoleApp.Helpers;

public static class CopyToJsonFileHelpers
{
    private static readonly JsonSerializerOptions _options
        = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    
    public static async Task StreamWriteJsonAsync(object obj, string fileName)
    {
        try
        {
            await using var fileStream = File.Create(fileName);
            await using var utf8JsonWriter = new Utf8JsonWriter(fileStream);

            await JsonSerializer.SerializeAsync(fileStream, obj, _options);
        }
        catch (Exception)
        {
            Console.WriteLine("Error creating json file");
        }
        
    }

    public static async Task PrettyWriteJsonAsync(object obj, string fileName)
    {
        try
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(obj, options);

            await File.WriteAllTextAsync(fileName, jsonString);
        }
        catch (Exception)
        {
            Console.WriteLine("Error creating json file");
        }
    }
}
