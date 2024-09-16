using Microsoft.AspNetCore.Mvc;
using ProductosApi.Models;
using ProductosApi.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase 
    {
        private readonly IAplication aplicacion;
        public ProductoController()
        {
            aplicacion = new ProductoService();
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = aplicacion.GetProductos();
            if (productos == null)
                return NotFound("Producto no encontrado");
            return Ok(productos);  
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult GetProductoId(int id)
        {
            var producto = aplicacion.GetById(id);
            if (producto == null)
                return NotFound("No se encontraron resultados.");
            return Ok(producto);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult PostProducto(Producto producto)
        {
            var result = false;
            try
            {
                if (producto != null)
                {
                    result = aplicacion.SaveProducto(producto);
                    if(result)
                        return Ok("Producto guardado exitosamente");
                }
                return BadRequest("Producto no válido");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            var productos = aplicacion.DeleteProducto(id);
            if (!productos)
                return NotFound("Producto no encontrado");
            return Ok(productos);
        }
    }
}
