using BackRecetas.Data.Entities;
using BackRecetas.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecetasEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _service;
        public IngredienteController(IIngredienteService service)
        {
            _service = service;   
        }
        // GET: api/<IngredienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllIngredientes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(await _service.GetIngrediente(id));
                }
                else
                {
                    return NotFound("Ingrediente no encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // POST api/<IngredienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ingrediente ing)
        {
            try
            {
                if (ing != null )
                {
                    await _service.AgregarIngrediente(ing);
                    return Ok("Ingrediente registrado con éxito");
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

        // PUT api/<IngredienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ingrediente ing)
        {
            try
            {
                if (ing != null && id != null)
                {
                    await _service.ModificarIngrediente(id, ing);
                    return Ok("Ingrediente modificado con éxito");
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

        // DELETE api/<IngredienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    await _service.EliminarIngrediente(id);
                    return Ok("Ingrediente eliminado con ºexito");
                }
                else
                {
                    return NotFound("El ingrediente no se pudo eliminar, porque no existe");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }
    }
}
