using MassTransit;

namespace Consumer.Model;

[MessageUrn("delete-item-dto")]
[EntityName("delete-item-dto")]
public class DeleteItemDto
{
    public Guid Id { get; set; }
}
