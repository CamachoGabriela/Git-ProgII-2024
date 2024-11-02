using CineBack.Data.Entities;
using CineBack.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;
        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }
        // GET: api/<PeliculaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllPeliculas());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(id != null)
                    return Ok(await _service.GetPeliculaById(id));
                else return BadRequest("Debe ingresar un identificar de película" );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        [HttpGet("Genero/{id}")]
        public async Task<IActionResult> GetGenero(int id)
        {
            try
            {
                if (id != null)
                    return Ok(await _service.GetPeliculasPorGenero(id));
                else return BadRequest("Debe ingresar un identificar de película");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // POST api/<PeliculaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pelicula pelicula)
        {
            try
            {
                if (pelicula != null)
                {
                    if (await _service.RegistrarPelicula(pelicula))
                        return Ok("Película creada con éxito!!" );
                    else
                    {
                        return BadRequest("No se ha podido registrar la película" );
                    }
                }
                else
                {
                    return BadRequest("No se ha podido registrar la película" );
                }
                    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // PUT api/<PeliculaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pelicula pelicula)
        {
            try
            {
                if (pelicula != null)
                {
                    if (id != null)
                    {
                        await _service.ModificarPelicula(id, pelicula);
                        return Ok("Película actualizada con éxito!!" );
                    }
                    else
                    {
                        return NotFound( "No se ha encontrado la película solicitada" );
                    }
                }
                else
                {
                    return BadRequest("No se ha podido actualizar la película" );
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // DELETE api/<PeliculaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    await _service.EliminarPelicula(id);
                    return Ok( "Película eliminada con éxito!!" );
                }
                else
                {
                    return NotFound("No se ha encontrado la película solicitada" );
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }
    }
}
