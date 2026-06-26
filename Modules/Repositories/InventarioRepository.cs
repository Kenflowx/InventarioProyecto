using InventarioProyecto.Data;
using InventarioProyecto.Modules.Inventario.Dtos;
using InventarioProyecto.Modules.Inventario.Entities;

namespace InventarioProyecto.Modules.Inventario.Repositories
{
    public class InventarioRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public List<Producto> FindAll()
        {
            return _context.Productos.Where(p => p.IsActive).ToList();
        }

        public Producto? FindOne(Guid uuid)
        {
            return _context.Productos.FirstOrDefault(p => p.Uuid == uuid && p.IsActive);
        }

        public Producto Create(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto;
        }

        public Producto Update(Producto producto)
        {
            _context.Update(producto);
            _context.SaveChanges();
            return producto;
        }

        public bool Delete(Guid uuid)
        {
            var producto = FindOne(uuid);
            if (producto is null) return false;

            producto.IsActive = false;
            _context.SaveChanges();
            return true;
        }
    }
}