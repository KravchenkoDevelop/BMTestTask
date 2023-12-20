using Test.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();

// Add DB services
builder.Services.RegisterDataService();

builder.Services.ConfigureSwagger();

//Configure API Runtime
builder.Services.ApiSettings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.SwaggerAppConfig();
}

app.ApiRuntime();
app.MapControllers();

app.Run();
