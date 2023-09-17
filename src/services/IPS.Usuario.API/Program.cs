using IPS.Usuario.API.Configuration;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
Debug.WriteLine("Iniciando Aplicação");
builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddMessageBusConfiguration(builder.Configuration);
// Add services to the container.
var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);
app.Run();

