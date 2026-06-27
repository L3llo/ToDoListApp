using Scalar.AspNetCore;
using ToDoListApp.Server.Application.ToDoItems;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;
using ToDoListApp.Server.Infrastructure;
using ToDoListApp.Server.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy.WithOrigins(builder.Configuration["AllowedOrigins"]!)
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors("FrontendPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
