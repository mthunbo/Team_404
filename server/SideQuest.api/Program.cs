using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SideQuest.Api.Config;
using SideQuest.api.Repositories;
using SideQuest.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDb
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton(sp =>
{
    var mongoSettings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoSettings.DatabaseName);
});

// DI: Repositories + Services
builder.Services.AddScoped<FamilyRepository>();
builder.Services.AddScoped<ParentRepository>();

builder.Services.AddScoped<FamilyService>();
builder.Services.AddScoped<ParentService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MobileDev", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MobileDev");

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Ok("API is running"));

app.Run();
