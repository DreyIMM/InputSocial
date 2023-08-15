using IPS.Usuario.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices();

// Add services to the container.
var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);
app.Run();

