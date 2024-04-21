using FreakyFashion.Core.Interfaces;
using FreakyFashion.Core.Services;
using FreakyFashion.Data.Interfaces;
using FreakyFashion.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IMappingService, MappingService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddApplicationInsightsTelemetry();

builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) => 
        config.ConnectionString = "InstrumentationKey=c382ebfd-eaed-4610-b00a-3891a25dd5ed;IngestionEndpoint=https://swedencentral-0.in.applicationinsights.azure.com/;ApplicationId=35362d31-4169-4b75-a333-8a41f1247d9b",
    configureApplicationInsightsLoggerOptions: (options) => { }
);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();