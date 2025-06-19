namespace Consumer.Model;
public class PedidoItemDto : BaseEntityDto
{
    public ItemDto? Item { get; set; }
    public PedidoDto? Pedido { get; set; }
    public int? Quantidade { get; set; }
}
