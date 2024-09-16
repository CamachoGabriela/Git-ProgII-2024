using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperaturaApi.Models;
using TemperaturaApi.Service;

namespace TemperaturaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private readonly RegistroTemperaturaService registro;

        public TemperaturaController()
        {
            registro = RegistroTemperaturaService.GetInstance();
        }

        [HttpGet]
        public IActionResult GetTemperaturas()
        {
            var temperatura = registro.GetTemperaturas();
            if (temperatura == null)
                return NotFound("Temperatura no encontrada");
            return Ok(temperatura);
        }

        [HttpGet("{id}")]
        public IActionResult GetTemperaturaId(int id)
        {
            var temperatura = registro.GetTemperaturaById(id);
            if (temperatura == null)
                return NotFound("No se encontraron resultados");
            return Ok(temperatura);
        }

        [HttpPost]
        public IActionResult PostTemperatura(Temperatura temperatura)
        {
            var result = false;
            try
            {
                if (temperatura != null)
                {
                    result = registro.SaveTemperatura(temperatura);
                    if (result)
                        return Ok("Temperatura guardada exitosamente");
                }
                return BadRequest("Temperatura no válida");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }
    }
}
