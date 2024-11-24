using OpenAIServer.Interfaces;
using OpenAIServer.Repositories;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add OpenAIAPI as a service
builder.Services.AddTransient<OpenAIClient>(serviceProvider =>
{
    // Get the API key from configuration (appsettings.json or environment variable)
    string? apiKey = "api-key";
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("OpenAI API Key is not configurated");
    }

    // Initialize and return the OpenAIAPI instance
    return new OpenAIClient(apiKey);
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IAsteroidImageRepository, AsteroidImageRepository>();


//add CORS policy for permission treat request from other protocols and ports
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenAiGeneration V1");
    });
}

app.UseRouting();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();