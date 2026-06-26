using Microsoft.EntityFrameworkCore;
using InventarioProyecto.Modules.Inventario.Entities;

namespace InventarioProyecto.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Producto> Productos => Set<Producto>();
    }
}