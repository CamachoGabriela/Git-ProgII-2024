using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModeloParcialWebApi.Models;
using ModeloParcialWebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModeloParcialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepository _repository;
        public PeliculasController(IPeliculaRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<PeliculasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
        [HttpGet("/Estreno")]
        public IActionResult GetEstreno([FromQuery] int anhoA, [FromQuery] int anhoB)
        {
            try
            {
                var film = _repository.GetAllEstrenos().Where(x => x.Anio >= anhoA && x.Anio <= anhoB).ToList();
                return Ok(film);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
        // GET api/<PeliculasController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PeliculasController>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            try
            {
                if (IsValid(pelicula))
                {
                    _repository.Create(pelicula);
                    return Ok("Película registrada con éxito");
                }
                else
                {
                    return BadRequest("Debe completar los campos obligatorios");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        private bool IsValid(Pelicula pelicula)
        {

            return !string.IsNullOrEmpty(pelicula.Titulo) && !string.IsNullOrEmpty(pelicula.Director) && pelicula.Anio > 0 && pelicula.IdGenero > 0;
        }
        


        //PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                if (_repository.Update(id))
                    return Ok("Cartelera deshabilitada");
                else
                    return NotFound("Película no encontrada");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] string motivo)
        {
            try
            {
                if(_repository.Delete(id,motivo))
                {
                    return Ok("Pelicula eliminada");
                }
                else
                {
                    return NotFound("Película no encontrada");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
    }
}

