using Microsoft.AspNetCore.Mvc;
using TemperaturaBack.Data.Entities;
using TemperaturaBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemperaturaEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private readonly ITemperaturaService _service;
        public TemperaturaController(ITemperaturaService service)
        {
            _service = service;
        }
        // GET: api/<TemperaturaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllTemperaturas());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // GET api/<TemperaturaController>/5
        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _service.GetTemperaturaById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // POST api/<TemperaturaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Temperatura temp)
        {
            try
            {
                if(temp != null)
                {
                    await _service.RegistrarTemperatura(temp);
                    return Ok("Temperatura registrada con éxito");
                }
                else
                {
                    return BadRequest("No se ha ingresado una temperatura válida");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // PUT api/<TemperaturaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Temperatura temp)
        {
            try
            {
                if(id!= null && temp != null)
                {
                    await _service.EditarTemperatura(id, temp);
                    return Ok("Temperatura actualizada con éxito");
                }
                else
                {
                    return NotFound("No se ha encontrado la temperatura solicitada");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }

        // DELETE api/<TemperaturaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    await _service.DeleteTemperatura(id);
                    return Ok("Temperatura eliminada con éxito");
                }
                else
                {
                    return BadRequest("Debe ingresar un IoT para eliminar la temperatura");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Intente nuevamente más tarde. Error: {ex.Message}");
            }
        }
    }
}
