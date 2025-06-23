using Core.Entities;

namespace Consumer.Model;
public  class BaseEntityDto
{
    public Guid? Id { get; set; }
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public Guid? CriadoPor { get; set; }
    public Guid? AtualizadoPor { get; set; }

    public void PopulateBase<T>(T e) where T : BaseEntity
    {
        e.Id = Id ?? default;
        e.DataCriacao = DataCriacao ?? default;
        e.DataAtualizacao = DataAtualizacao ?? default;
        e.CriadoPor = CriadoPor ?? default;
        e.AtualizadoPor = AtualizadoPor ?? default;
    }
}
