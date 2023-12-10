using IPS.Feed.API.BackgroundTasks;
using IPS.Feed.API.Configuration;
using IPS.Feed.API.Services;
using IPS.Feed.Domain.Interfaces;
using IPS.WebApi.Core.Identidade;

// (START) Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddHostedService<BairrosMomentsService>();
builder.Services.AddScoped<IScopedBairrosService, BairrosService>();
builder.Services.RegisterServices();
builder.Services.AddMessageBusConfigurationNLP(builder.Configuration);
// (END) Add services to the container.


// (START) Configure the HTTP request pipeline.
var app = builder.Build();

app.UseApiConfiguration(builder.Environment);
app.UseSwaggerConfiguration();
app.Run();
// (END) Configure the HTTP request pipeline.
