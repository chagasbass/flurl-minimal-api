using FlurlAPI.Entities;

namespace FlurlAPI.Services;

public interface IViaCepServices
{
    Task<ViaCepDados> ListarDadosDeCepAsync(string? cep);
}
