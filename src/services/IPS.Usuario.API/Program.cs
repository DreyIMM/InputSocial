using IPS.Usuario.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices(builder.Configuration);

// Add services to the container.
var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);
app.Run();

