using Microsoft.AspNetCore.Mvc;
using Negocio.Data.Entities;
using Negocio.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaParcial1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;
        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }
        // GET: api/<ServicioController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _servicioService.GetServicios());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _servicioService.GetServicio(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // POST api/<ServicioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TServicio servicio)
        {
            try
            {
                if(servicio == null)
                    return BadRequest("Ingrese un servicio válido");
                else
                {
                    await _servicioService.RegistrarServicio(servicio);
                    return Ok("Servicio creado exitosamente");
                }
                    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TServicio servicio)
        {
            try
            {
                if (servicio == null)
                    return BadRequest("Ingrese un servicio válido");
                if (id == 0 || id == null)
                    return NotFound("Servicio no encontrado!");
                else
                {
                    await _servicioService.EditarServicio(id, servicio);
                    return Ok("Servicio actualizado exitosamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Ingrese valores válidos");
                else
                {
                    await _servicioService.CancelarServicio(id);
                    return Ok("Servicio Cancelado!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }
    }
}
