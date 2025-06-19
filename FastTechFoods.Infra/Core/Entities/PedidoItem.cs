namespace Core.Entities;
public class PedidoItem : IKeyedModel
{    
    public Guid Id { get; set; }
    public Item Item { get; set; }
    public Pedido Pedido { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
