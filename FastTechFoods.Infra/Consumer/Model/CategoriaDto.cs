using Core.Entities;

namespace Consumer.Model;
public class CategoriaDto : BaseEntityDto
{    
    public string? Nome { get; set; }

    public Categoria ToEntity()
    {
        var entity = new Categoria
        {            
            Nome = Nome ?? string.Empty,
        };

        PopulateBase(entity);

        return entity;
    }
}
