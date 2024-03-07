using AutoFixture;
using Flurl.Http.Testing;
using FlurlAPI.Entities;
using FlurlAPI.Services;

namespace FlurlAPI.Tests;

public class ViaCepServicesTests : BaseTests
{
    Fixture _fixture;

    public ViaCepServicesTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    [Trait("ViaCepServices", "Validação de requisição")]
    public async Task Deve_Retornar_Um_Objeto_Do_Tipo_Via_Cep_Dados_Quando_Cep_For_Valido_E_For_Encontrado()
    {
        //arrange

        var cep = "24040110";
        var viaCepDado = _fixture.Build<ViaCepDados>()
                                 .Without(x => x.Localidade)
                                 .Without(x => x.Cep)
                                 .Without(x => x.Ibge)
                                 .Without(x => x.Ddd)
                                 .Without(x => x.Logradouro)
                                 .Without(x => x.Complemento)
                                 .Without(x => x.Uf)
                                 .Without(x => x.Siafi)
                                 .Without(x => x.Gia)
                                  .Do(x =>
                                  {
                                      x.Cep = "24040110";
                                      x.Ibge = "1234";
                                      x.Logradouro = "Conde Pereira Carneiro";
                                      x.Ddd = "21";
                                      x.Localidade = "Ponta da Areia";
                                      x.Uf = "RJ";

                                  }).Create();

        var service = new ViaCepServices();

        CriarHttpTest();

        //act

        HttpTest
        .RespondWithJson(viaCepDado);

        var dadoRecuperado = await service.ListarDadosDeCepAsync(cep);

        //assert

        HttpTest.ShouldHaveCalled($"http://viacep.com.br/ws/{cep}/json/")
                .WithVerb(HttpMethod.Get)
                .Times(1);

        RemoverHttpTest();
    }
}

public abstract class BaseTests
{
    public HttpTest HttpTest { get; set; }

    public void CriarHttpTest()
    {
        HttpTest = new HttpTest();
    }

    public void RemoverHttpTest()
    {
        HttpTest.Dispose();
    }


}
