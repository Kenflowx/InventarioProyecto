using System.ComponentModel.DataAnnotations;

namespace InventarioProyecto.Modules.Inventario.Dtos
{
    public class ActualizarProductoDto
    {
        [MinLength(3, ErrorMessage = "El SKU debe tener mínimo 3 caracteres")]
        public string? Sku { get; set; }

        [MinLength(3, ErrorMessage = "El nombre debe tener mínimo 3 caracteres")]
        public string? Nombre { get; set; }
                                
        public decimal? Precio { get; set; }

        public int? Stock { get; set; }

        [MinLength(3, ErrorMessage = "La categoría debe tener mínimo 3 caracteres")]
        public string? Categoria { get; set; }
    }
}