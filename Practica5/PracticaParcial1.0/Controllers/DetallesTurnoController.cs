using Microsoft.AspNetCore.Mvc;
using Negocio.Data.Entities;
using Negocio.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaParcial1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesTurnoController : ControllerBase
    {
        private readonly IDetallesTurnoService _service;
        public DetallesTurnoController(IDetallesTurnoService service)
        {
            _service = service;
        }
        // GET: api/<DetallesTurnoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllDetalles());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // GET api/<DetallesTurnoController>/5
        [HttpGet("{idT},{idS}")]
        public async Task<IActionResult> GetById(int idT, int idS)
        {
            try
            {
                if (idT == 0 || idS == 0)
                    return BadRequest("Debe ingresar un identificador válido");
                var detalle = await _service.GetDetalle(idT, idS);
                if (detalle == null)
                    return BadRequest("Detalle no encontrado");
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // POST api/<DetallesTurnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TDetallesTurno detalle)
        {
            try
            {
                if (detalle == null)
                    return BadRequest("Debe ingresar valores válidos");
                var detail = await _service.RegistrarDetalle(detalle);
                return Ok("Detalle creado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // PUT api/<DetallesTurnoController>/5
        [HttpPut("{idT},{idS}")]
        public async Task<IActionResult> Put(int idT, int idS, [FromBody] TDetallesTurno detalle)
        {
            try
            {
                if (idT == null || idS == null || detalle ==null)
                    return BadRequest("Debe ingresar un valor");
                await _service.EditarDetalle(idT,idS, detalle);
                return Ok("Detalle actualizado correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // DELETE api/<DetallesTurnoController>/5
        [HttpDelete("{idT}")]
        public async Task <IActionResult> Delete(int idT, [FromQuery] int idS)
        {
            try
            {
                if (idT == null || idS == null)
                    return BadRequest("Ingrese un identificador válido");
                await _service.EliminarDetalle(idT,idS);
                return Ok("Detalle eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }
    }
}
