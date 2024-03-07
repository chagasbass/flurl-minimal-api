using FlurlAPI.Entities;
using FlurlAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKeyedScoped<IViaCepServices, ViaCepServices>("viacep");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/ceps", async ([FromKeyedServices("viacep")] IViaCepServices service, string? cep) =>
{
    var cepEncontrado = await service.ListarDadosDeCepAsync(cep);

    return cepEncontrado;
}).WithDisplayName("Ceps")
  .WithDescription("Busca de dados de um cep")
  .WithName("Ceps")
   .WithOpenApi()
  .Produces<ViaCepDados>(200)
  .Produces<ViaCepDados>(404);

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
