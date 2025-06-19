namespace Consumer.Model;
public class PedidoDto : BaseEntityDto
{
    public int? Status { get; set; }
    public int? Entrega { get; set; }
    public ClienteDto? Cliente { get; set; }    
}
