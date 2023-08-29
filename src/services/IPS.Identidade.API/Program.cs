using IPS.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfig();
builder.Services.AddMessageBusConfiguration(builder.Configuration);

// Add services to the container.
var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseSwaggerConfig();
app.UseApiConfiguration(app.Environment);
app.Run();

