using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseWolverine();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/greeting", () => "Hello World!");
app.MapWolverineEndpoints();

app.Run();
public partial class Program { }