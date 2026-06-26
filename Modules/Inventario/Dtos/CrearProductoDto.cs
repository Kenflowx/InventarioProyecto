using System.ComponentModel.DataAnnotations;

namespace InventarioProyecto.Modules.Inventario.Dtos
{
    public class CrearProductoDto
    {
        [Required(ErrorMessage = "El SKU es requerido")]
        [MinLength(3, ErrorMessage = "El SKU debe tener mínimo 3 caracteres")]
        public required string Sku { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3, ErrorMessage = "El nombre debe tener mínimo 3 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [MinLength(3, ErrorMessage = "La categoría debe tener mínimo 3 caracteres")]
        public required string Categoria { get; set; }
    }
}