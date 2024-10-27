global using FastEndpoints;

using DistroWatch.Api.Database;
using DistroWatch.Api.Repositories;
using DistroWatch.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton<IDbConnectionFactory>(_ => new SqliteConnectionFactory(
    builder.Configuration.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddTransient<IDistributionRepository, DistributionRepository>();
builder.Services.AddTransient<IDistributionService, DistributionService>();

var app = builder.Build();
app.UseFastEndpoints();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();
