using Microsoft.EntityFrameworkCore;

using SoapCore;
using SoapApi.Services; // Asegúrate de tener esta referencia
using SoapApi.Data; // Para DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers(); // Registra los controladores

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=database.db"));

// Agregar el servicio SOAP
builder.Services.AddScoped<IProductoService, ProductoService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware para SOAP antes de enrutamiento
app.UseSoapEndpoint<IProductoService>("/ProductoService.asmx", new SoapCore.SoapEncoderOptions());

// Configurar middleware
app.UseRouting();

// Agregar enrutamiento de controladores
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Mapear controladores
});

app.UseSoapEndpoint<IProductoService>("/ProductoService.asmx", new SoapCore.SoapEncoderOptions());

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
