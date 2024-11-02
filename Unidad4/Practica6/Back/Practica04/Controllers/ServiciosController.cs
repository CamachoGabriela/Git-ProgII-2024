using Microsoft.AspNetCore.Mvc;
using Negocio.Data.Repositories;
using Practica04.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica04.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private IServicioRepository _servicioRepository;
        public ServiciosController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }
        // GET: api/<ServiciosController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_servicioRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public IActionResult GeById(int id)
        {
            try
            {
                return Ok(_servicioRepository.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
        [HttpGet("/Servicio/Filter")]
        public IActionResult GeByFilter([FromQuery]string? nombre, [FromQuery]string? enPromo)
        {
            try
            {
                return Ok(_servicioRepository.GetByFilter(nombre,enPromo));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                _servicioRepository.Create(servicio);
                return Ok("Servicio creado con éxito");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TServicio servicio, int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Identificador de servicio inválido");

                _servicioRepository.Update(servicio,id);
                return Ok("Servicio actualizado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servicioRepository.Delete(id);
                return Ok("Servicio eliminado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
    }
}
