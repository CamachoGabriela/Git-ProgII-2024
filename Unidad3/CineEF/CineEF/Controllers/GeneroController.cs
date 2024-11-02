using CineBack.Data.Entities;
using CineBack.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _service;
        public GeneroController(IGeneroService service)
        {
            _service = service;
        }
        // GET: api/<GeneroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllGeneros());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // GET api/<GeneroController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id != null)
                    return Ok(await _service.GetGeneroById(id));
                else return BadRequest("Debe ingresar un identificar de género" );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // POST api/<GeneroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Genero genero)
        {
            try
            {
                if (!string.IsNullOrEmpty(genero.Nombre))
                {
                    await _service.RegistrarGenero(genero); //no le paso nada, pero lo mismo entra, aunque no genera ningún registro
                    return Ok( "Género creado con éxito!!" );
                }
                else
                {
                    return BadRequest("No se ha podido registrar el género" );
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // PUT api/<GeneroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Genero genero)
        {
            try
            {
                if (genero != null)
                {
                    if (id != null)
                    {
                        await _service.ModificarGenero(id, genero);
                        return Ok("Género actualizado con éxito!!" );
                    }
                    else
                    {
                        return NotFound( "No se ha encontrado el género solicitado" );
                    }
                }
                else
                {
                    return BadRequest("No se ha podido actualizar el género" );
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // DELETE api/<GeneroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    await _service.EliminarGenero(id);
                    return Ok("Género eliminado con éxito!!" );
                }
                else
                {
                    return NotFound( "No se ha encontrado el género solicitado" );
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }
    }
}
