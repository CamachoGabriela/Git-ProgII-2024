using CashApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static readonly List<Cash> monedas = new List<Cash>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(monedas);
        }

        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach (var mon in monedas)
            {
                if(mon.Nombre.Equals(nombre))
                    return Ok(mon);
            }
            return NotFound("Moneda no registrada");
        }

        [HttpPost]
        public IActionResult Post([FromBody]Cash c)
        {
            if(c == null || string.IsNullOrEmpty(c.Nombre))
            {
                return BadRequest("Datos Incorrectos");
            }
            else
            {
                monedas.Add(c);
                return Ok("Moneda registrada");
            }
        }
    }
}
