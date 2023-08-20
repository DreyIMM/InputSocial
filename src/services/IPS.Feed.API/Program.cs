using IPS.Feed.API.Configuration;

// (START) Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
// (END) Add services to the container.


// (START) Configure the HTTP request pipeline.
var app = builder.Build();

app.UseApiConfiguration(builder.Environment);
app.Run();
// (END) Configure the HTTP request pipeline.
