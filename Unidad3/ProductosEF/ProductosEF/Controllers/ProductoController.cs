using Microsoft.AspNetCore.Mvc;
using ProductoBack.Data.Models;
using ProductoBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductosEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        public ProductoController(IProductoService service)
        {
            _service = service;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllProductos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                if (producto != null)
                {
                    await _service.RegistrarProducto(producto);
                    return Ok("Producto registrado exitosamente");
                }
                else
                    return BadRequest("No se pudo registrar el producto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != null && producto != null)
                {
                    await _service.ModificarProducto(id, producto);
                    return Ok("Producto modificado exitosamente");
                }
                else
                {
                    return NotFound("No se ha encontrado el producto a modificar");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, string motivo)
        {
            try
            {
                if (id != null)
                { 
                    if(motivo != null)
                    {
                        await _service.CancelarProducto(id, motivo);
                        return Ok("Producto eliminado exitosamente");
                    }
                    else
                    {
                        return BadRequest("Debe ingresar un motivo válido");
                    }
                }
                else
                {
                    return NotFound("No se ha encontrado el producto que quiere eliminar");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }
    }
}
