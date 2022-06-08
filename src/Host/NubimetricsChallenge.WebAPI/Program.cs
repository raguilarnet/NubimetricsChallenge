using NubimetricsChallenge.Application;
using NubimetricsChallenge.Infrastructure;
using NubimetricsChallenge.WebAPI.Helpers;
using NubimetricsChallenge.WebAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

builder.Services.AddAutoMapper(c => c.AddProfile<AutoMapperConfigurationModel>(), AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient("MercadoLibreClient", config =>
{
    config.BaseAddress = new Uri("https://api.mercadolibre.com/");
    config.Timeout = new TimeSpan(0, 0, 30);
    config.DefaultRequestHeaders.Clear();
});

var app = builder.Build();

await ApplyDbMigrationsWithDataSeedAsync(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task ApplyDbMigrationsWithDataSeedAsync(IHost appHost)
{
    await DbMigrationHelpers.ApplyDataBaseMigrations(appHost);
    await DbMigrationHelpers.ApplyDataBaseSeeder(appHost);
}
