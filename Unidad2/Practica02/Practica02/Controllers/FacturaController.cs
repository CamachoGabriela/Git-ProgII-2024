using Microsoft.AspNetCore.Mvc;
using Practica02.Data;
using Practica02Back.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IAplicacion _repository;
        public FacturaController()
        {
            _repository = new Aplicacion();
        }
        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetFacturas());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error. Ha ocurrido un error interno!");
            }
        }

        // GET api/<FacturaController>/5
        [HttpGet("byId/{id}")]
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
        [HttpGet("filtro/{fecha}/{fp}")]
        public IActionResult GetFiltro(DateTime fecha, int fp)
        {
            try
            {
                return Ok(_repository.ConsultaFiltros(fecha, fp));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Factura value)
        {
            try
            {
                if (value != null)
                {
                    _repository.SaveFactura(value);
                    return Ok("Factura Insertada");
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


        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Factura value)
        {
            if (value == null || id != value.NroFactura)
            {
                return BadRequest("El número de factura no coincide.");
            }

            try
            {
                var facturaExistente = _repository.GetById(id); // Método para obtener el libro por ID
                if (facturaExistente == null)
                {
                    return NotFound("Factura no encontrado.");
                }
                facturaExistente.NroFactura = value.NroFactura;
                facturaExistente.Fecha = value.Fecha;
                facturaExistente.FormaPago = value.FormaPago;
                facturaExistente.Cliente = value.Cliente;

                _repository.UpdateFactura(value);
                return Ok("Factura actualizado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

       
    }
}
