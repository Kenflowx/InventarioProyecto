using Microsoft.AspNetCore.Mvc;
using InventarioProyecto.Modules.Inventario.Services;
using InventarioProyecto.Modules.Inventario.Dtos;
using InventarioProyecto.Modules.Inventario.Entities;

namespace InventarioProyecto.Modules.Inventario.Controllers
{
    [ApiController]
    [Route("api/v1/productos")]
    public class InventarioController(InventarioService service) : ControllerBase
    {
        private readonly InventarioService _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{uuid:guid}")]
        public IActionResult GetByUuid(Guid uuid)
        {
            Producto? producto = _service.GetByUuid(uuid);
            return producto == null ? NotFound(new { message = "Recurso no encontrado." }) : Ok(producto);
        }

       [HttpPost]
public IActionResult Create([FromBody] CrearProductoDto dto)
{
    var result = _service.Create(dto);
    return Created($"api/v1/productos/{result.Uuid}", result);
}

        [HttpPatch("{uuid:guid}")]
        public IActionResult Update(Guid uuid, [FromBody] ActualizarProductoDto dto)
        {
            Producto? result = _service.Update(uuid, dto);
            return result == null ? NotFound(new { message = "Recurso no encontrado." }) : Ok(new { message = "Producto actualizado." });
        }

        [HttpDelete("{uuid:guid}")]
        public IActionResult Delete(Guid uuid)
        {
            return _service.Delete(uuid) ? Ok(new { message = "Producto eliminado correctamente." }) : NotFound(new { message = "Recurso no encontrado." });
        }
    }
}