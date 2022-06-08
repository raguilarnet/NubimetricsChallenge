using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NubimetricsChallengeCurrency.ConsoleApp.Helpers;
using NubimetricsChallengeCurrency.ConsoleApp.Models;
using NubimetricsChallengeCurrency.ConsoleApp.Services;

Console.WriteLine("Nubimetrics Challenge Currency Console App");

var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHttpClient("MLCurrencyClientAPI", cfg =>
                   {
                       cfg.BaseAddress = new Uri("https://api.mercadolibre.com/currencies/");
                   });
                   services.AddHttpClient("MLCurrencyConversionsClientAPI", cfg =>
                   {
                       cfg.BaseAddress = new Uri("https://api.mercadolibre.com/currency_conversions/");
                   });
                   services.AddTransient<MLCurrencyServices>();
                   services.AddTransient<MLCurrencyConversionsServices>();
               }).UseConsoleLifetime();

var host = builder.Build();

using (var serviceScope = host.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    try
    {
        var currencyService = services.GetRequiredService<MLCurrencyServices>();
        var allCurrenciesResult = await currencyService.GetAllCurrencies();

        var currencyConversionsService = services.GetRequiredService<MLCurrencyConversionsServices>();

        List<double> ratiosForCsvFile = new List<double>();

        List<CurrencyWithConversions> currencyWithConversionsList = new List<CurrencyWithConversions>();

        foreach (var item in allCurrenciesResult)
        {
            CurrencyWithConversions currencyWithConversions = new CurrencyWithConversions();

            var currencyConversionResult = await currencyConversionsService.GetCurrencyConversionById(item.id.ToUpper());
            ratiosForCsvFile.Add(currencyConversionResult.ratio);

            #region Mapp
            currencyWithConversions.id = item.id;
            currencyWithConversions.symbol = item.symbol;
            currencyWithConversions.description = item.description;
            currencyWithConversions.decimal_places = item.decimal_places;

            currencyWithConversions.todolar = currencyConversionResult;
            #endregion

            currencyWithConversionsList.Add(currencyWithConversions);
        }

        #region Create Json Files
        await CopyToJsonFileHelpers.StreamWriteJsonAsync(currencyWithConversionsList, "currency.json");
        await CopyToJsonFileHelpers.PrettyWriteJsonAsync(currencyWithConversionsList, "currencyPretty.json");
        #endregion
        Console.WriteLine("Json file successfully generated");

        #region Create Csv Files
        CopyToCsvFileHelpers.StreamWriteCsvAsync(ratiosForCsvFile, "ratios.csv");
        #endregion
        Console.WriteLine("Csv file successfully generated");

        Console.WriteLine("All files successfully generated");
    }
    catch (Exception)
    {
        Console.WriteLine("Error Occured");
    }
}
Console.ReadLine();

return 0;
