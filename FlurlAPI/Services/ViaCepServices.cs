using Flurl.Http;
using FlurlAPI.Entities;

namespace FlurlAPI.Services;

public class ViaCepServices : IViaCepServices
{
    public async Task<ViaCepDados> ListarDadosDeCepAsync(string? cep)
    {
        var url = $"http://viacep.com.br/ws/{cep}/json/";

        var cepEncontrado = await url.GetJsonAsync<ViaCepDados>();

        return cepEncontrado;
    }
}
