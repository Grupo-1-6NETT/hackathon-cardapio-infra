using Core.Enums;

namespace Core.Entities;
public class Pedido : IKeyedModel
{    
    public Guid Id { get; set; }
    public PedidoStatusEnum Status { get; set; }
    public PedidoEntregaEnum Entrega { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
