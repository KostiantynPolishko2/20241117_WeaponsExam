using OpenAIServer.Interfaces;
using OpenAIServer.Repositories;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fetch the API key at startup
string? url = builder.Configuration["OpenAI:Data"];
if (url == null)
{
    throw new InvalidOperationException("Data for OpenAI API Key is missing");
}

HttpClient httpClient = new HttpClient();
string? apiKey = await httpClient.GetStringAsync(url);
if (string.IsNullOrEmpty(apiKey))
{
    throw new InvalidOperationException("OpenAI API Key is not configured");
}

// Register OpenAIClient with the fetched API key
builder.Services.AddTransient<OpenAIClient>(_ => new OpenAIClient(apiKey));

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