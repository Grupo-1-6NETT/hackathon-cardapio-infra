using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{    
    public DbSet<Categoria> Categorias { get; set; }    
    public DbSet<Item> Items { get; set; }    
}
