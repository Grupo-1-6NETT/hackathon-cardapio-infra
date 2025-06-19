namespace Consumer.Model;

public class ItemDto : BaseEntityDto
{   public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public bool? Disponivel { get; set; }
    public CategoriaDto? Categoria { get; set; }    
}
