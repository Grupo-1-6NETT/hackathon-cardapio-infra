namespace Core.Entities;

public class Cliente : IKeyedModel
{    
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
