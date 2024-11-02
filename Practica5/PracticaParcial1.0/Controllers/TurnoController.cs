using Microsoft.AspNetCore.Mvc;
using Negocio.Data.Entities;
using Negocio.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaParcial1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly IServicioTurno _service;
        public TurnoController(IServicioTurno service)
        {
            _service = service;   
        }
        // GET: api/<TurnoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return  Ok(await _service.GetTurnos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // GET api/<TurnoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!_service.Validar(null, id))
                    return NotFound("Identificador inválido");
                return Ok(await _service.GetTurno(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // POST api/<TurnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TTurno turno)
        {
            try
            {
                if(turno == null)
                    return BadRequest("Debe ingresar un identificador válido");
                var result = await _service.RegistrarTurno(turno);
                if(result)
                    return Ok("Turno creado exitosamente");
                return StatusCode(500, "No se pudo crear el turno");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Internal Server Error: {ex.Message}");
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TTurno turno)
        {
            try
            {
                var result = await _service.EditarTurno(id, turno);
                if(result)
                    return Ok("Turno actualizado");
                else
                    return StatusCode(500, "No se pudo editar el turno");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // DELETE api/<TurnoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string motivo)
        {
            try
            {
                var result = await _service.CancelarTurno(id,motivo);
                if (result)
                {
                    return Ok("Turno cancelado");
                }
                return StatusCode(500, "No se pudo cancelar el turno");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }
    }
}
