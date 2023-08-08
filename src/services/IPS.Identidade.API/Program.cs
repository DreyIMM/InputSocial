using IPS.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfig();

// Add services to the container.
var app = builder.Build();

app.UseSwaggerConfig();
app.UseApiConfiguration(app.Environment);
app.Run();

