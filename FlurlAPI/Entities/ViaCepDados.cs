namespace FlurlAPI.Entities;

public record ViaCepDados
{
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Complemento { get; set; }
    public string? Localidade { get; set; }
    public string? Uf { get; set; }
    public string? Ibge { get; set; }
    public string? Gia { get; set; }
    public string? Ddd { get; set; }
    public string? Siafi { get; set; }

    public ViaCepDados() { }

}
