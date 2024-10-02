using BackRecetas.Data.Entities;
using BackRecetas.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecetasEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly IRecetaService _service;
        public RecetaController(IRecetaService service)
        {
            _service = service;
        }
        // GET: api/<RecetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {      
                return Ok(await _service.GetAllRecetas());
             
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // GET api/<RecetaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult?> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(await _service.GetRecetaById(id));
                }
                else
                {
                    return NotFound("Recetas no encontradas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // POST api/<RecetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Receta receta)
        {
            try
            {
                if (receta != null)
                {
                    await _service.CrearReceta(receta);
                    return Ok("Receta creada con éxito");
                }
                else
                {
                    return BadRequest("Ingrese valores válidos");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // PUT api/<RecetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Receta receta)
        {
            try
            {
                if (receta != null && id != null )
                {
                    await _service.ModificarReceta(id, receta);
                    return Ok("Receta modificada con éxito");
                }
                else
                {
                    return BadRequest("Ingrese valores válidos");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // DELETE api/<RecetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    await _service.EliminarReceta(id);
                    return Ok("Receta eliminada con éxito");
                }
                else
                {
                    return NotFound($"No se pudo eliminar, porque no existe la receta número {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }
    }
}
