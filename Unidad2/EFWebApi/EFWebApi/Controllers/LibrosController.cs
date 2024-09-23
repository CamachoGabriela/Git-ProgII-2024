using EFWebApi.Data.Repository;
using EFWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private ILibroRepository _repository;

        public LibrosController(ILibroRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<LibrosController>
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

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        //POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] Libro value)
        {
            try
            {
                if(IsValid(value))
                {
                    _repository.Create(value);
                    return Ok("Libro Insertado");
                }
                else
                {
                    return BadRequest("Los datos no son correctos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        private bool IsValid(Libro value)
        {
            return !string.IsNullOrEmpty(value.Isbn) && !string.IsNullOrEmpty(value.Nombre) && !string.IsNullOrEmpty(value.FechaPublicacion)
                && value.Autor != 0;
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Libro value)
        {
            if (value == null || id != value.IdLibro) 
            {
                return BadRequest("ID no coincide con el libro proporcionado.");
            }

            try
            {
                var libroExistente = _repository.GetById(id); // Método para obtener el libro por ID
                if (libroExistente == null)
                {
                    return NotFound("Libro no encontrado.");
                }
                libroExistente.Isbn = value.Isbn;
                libroExistente.Nombre = value.Nombre;
                libroExistente.FechaPublicacion = value.FechaPublicacion;
                libroExistente.Genero = value.Genero;
                libroExistente.Autor = value.Autor;

                _repository.Update(value);
                return Ok("Libro actualizado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("Libro borrado");  //if
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
    }
}
