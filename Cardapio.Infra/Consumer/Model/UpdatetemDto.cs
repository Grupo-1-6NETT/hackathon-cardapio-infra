using Core.Entities;

namespace Consumer.Model;

public class UpdateItemDto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public bool? Disponivel { get; set; }
    public string? NomeCategoria { get; set; }    
}
