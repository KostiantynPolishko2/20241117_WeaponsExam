using OpenAIServer.Interfaces;
using OpenAIServer.Repositories;
using OpenAI;
using OpenAIServer.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fetch OpenAIClient via handler
builder.Services.AddTransient<OpenAIClient>(serviceProvider =>
{
    return new HandlerOpenAIClient().CreateOpenAIClientAsync(builder.Configuration["OpenAI:Data"]).Result;
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IImageAIRepository, ImageAIRepository>();


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

app.UseMiddleware<HandlerException>();

app.UseRouting();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();