using Infrastructures;
using WebAPI;
using Application.Commons;

var builder = WebApplication.CreateBuilder(args);

// Parse the configuration in appsettings
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddInfrastructuresService(configuration.DatabaseConnection);
builder.Services.AddWebAPIService();

// Register AppConfiguration as a singleton for DI
builder.Services.AddSingleton(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthchecks");
app.UseHttpsRedirection();  // Redirect HTTP to HTTPS
app.UseAuthorization();     // Add Authorization Middleware

app.MapControllers();

app.Run();