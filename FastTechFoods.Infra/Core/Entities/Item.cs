namespace Core.Entities;
public class Item : IKeyedModel
{    
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public bool Disponivel { get; set; }
    public Categoria Categoria { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
