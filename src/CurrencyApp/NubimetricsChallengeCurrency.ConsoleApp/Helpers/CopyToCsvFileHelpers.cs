using CsvHelper;
using System.Globalization;
using System.Text.Json;

namespace NubimetricsChallengeCurrency.ConsoleApp.Helpers;

public static class CopyToCsvFileHelpers
{
    public static void StreamWriteCsvAsync(IEnumerable<double> obj, string fileName)
    {
        try
        {
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteField(obj);
            }
        }
        catch (CsvHelperException)
        {
            Console.WriteLine("Error creating csv file");
        }
    }
}
