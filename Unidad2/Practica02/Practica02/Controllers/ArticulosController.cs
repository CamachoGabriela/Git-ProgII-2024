using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica02.Models;
using Practica02Back.Services;

namespace Practica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloService service;
        public ArticulosController()
        {
            service = new ArticuloService();
        }
        [HttpGet]
        public IActionResult GetArticulo()
        {
            return Ok(service.GetArticulos());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticulo(int id)
        {
            try
            {
                if (service.BorrarArticulo(id))
                    return Ok($"Artículo {id} eliminado");
                else
                    return NotFound("Artículo no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            try
            {
                if(service.EsValido(articulo))
                {
                    if (articulo == null)
                        return BadRequest("Se esperaba un Artículo válido");
                    if (service.RegistrarArticulo(articulo))
                        return Ok("Artículo registrado con éxito");
                    else
                        return StatusCode(500, "No se pudo registrar el artículo");
                }
                else
                    return BadRequest("El artículo no es válido");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

    }
}
