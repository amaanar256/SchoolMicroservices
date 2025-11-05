using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot config
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services
builder.Services.AddOcelot();
builder.Services.AddHttpClient();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

await app.UseOcelot();

app.Run();
