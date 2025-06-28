namespace Core.Dto;
public class ItemDto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal? Preco { get; set; }
    public bool? Disponivel { get; set; }
    public Guid? CategoriaId { get; set; }
}
