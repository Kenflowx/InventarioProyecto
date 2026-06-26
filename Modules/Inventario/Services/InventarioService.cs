using InventarioProyecto.Modules.Inventario.Dtos;
using InventarioProyecto.Modules.Inventario.Entities;
using InventarioProyecto.Modules.Inventario.Repositories;

namespace InventarioProyecto.Modules.Inventario.Services
{
    public class InventarioService(InventarioRepository repository)
    {
        private readonly InventarioRepository _repository = repository;

        public List<Producto> GetAll()
        {
            return _repository.FindAll();
        }

        public Producto? GetByUuid(Guid uuid)
        {
            return _repository.FindOne(uuid);
        }

        public Producto Create(CrearProductoDto dto)
        {
            var producto = new Producto
            {
                Uuid = Guid.NewGuid(),
                Sku = dto.Sku,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Categoria = dto.Categoria,
                IsActive = true
            };
            return _repository.Create(producto);
        }

        public Producto? Update(Guid uuid, ActualizarProductoDto dto)
        {
            var producto = _repository.FindOne(uuid);
            if (producto is null) return null;

            if (dto.Sku is not null) producto.Sku = dto.Sku;
            if (dto.Nombre is not null) producto.Nombre = dto.Nombre;
            if (dto.Precio is not null) producto.Precio = dto.Precio.Value;
            if (dto.Stock is not null) producto.Stock = dto.Stock.Value;
            if (dto.Categoria is not null) producto.Categoria = dto.Categoria;

            return _repository.Update(producto);
        }

        public bool Delete(Guid uuid)
        {
            return _repository.Delete(uuid);
        }
    }
}