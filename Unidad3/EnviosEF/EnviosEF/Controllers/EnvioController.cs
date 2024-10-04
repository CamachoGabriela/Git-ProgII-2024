using EnvioBack.Data.Entities;
using EnvioBack.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnviosEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioService _service;
        public EnvioController(IEnvioService service)
        {
            _service = service;
        }
        // GET: api/<EnvioController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]DateTime fecha1, [FromQuery]DateTime fecha2)
        {
            try
            {
                return Ok(await _service.GetEnvios(fecha1,fecha2));
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Ha ocurrido un error interno. Error {ex.Message}");
            }
        }

        // POST api/<EnvioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEnvio  envio)
        {
            try
            {
                if (envio != null)
                {
                    await _service.CrearEnvio(envio);
                    return Ok("Envío creado con éxito");
                }
                    
                        
                else
                {
                    return BadRequest("Ingrese datos válidos");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }
        }

        // DELETE api/<EnvioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                    await _service.CancelarEnvio(id);
                    return Ok("Envío cancelado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }
        }
    }
}
