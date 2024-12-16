using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Serve static files for the panel
app.UseStaticFiles();
app.UseDefaultFiles();

// Add a test endpoint to verify KeyGen functionality
app.MapGet("/generate-key", () =>
{
    string result;
    try
    {
        // Placeholder: Update this to call your actual KeyGen logic
        result = "Key generation success: " + GenerateKey();
    }
    catch (Exception ex)
    {
        result = "Error generating key: " + ex.Message;
    }
    return result;
});

app.MapControllers();

app.Run();

// Example function to simulate KeyGen logic
string GenerateKey()
{
    // Placeholder logic
    return Guid.NewGuid().ToString();
}
