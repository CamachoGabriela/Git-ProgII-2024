using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonedaApi.Models;

namespace MonedaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static List<Moneda> lst = new List<Moneda>(); //Sino en cada request, perdería las demás monedas---PONER STATIC
       

        [HttpGet]
        public IActionResult Get()
        {
            lst.Add(new Moneda() { Nombre = "Dólar", Valor = 1260.00 });
            lst.Add(new Moneda() { Nombre = "Peso Argentino", Valor = 1.00 });
            lst.Add(new Moneda() { Nombre = "Euro", Valor = 1450 });
            lst.Add(new Moneda() { Nombre = "Libra", Valor = 1700 });

            return Ok(lst);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Moneda m)  //La info viaja en el body y genera un objeto moneda
        { 
            if(m==null || string.IsNullOrEmpty(m.Nombre))
            {
                return BadRequest("Datos Incorrectos");
            }
            lst.Add(m);
            return Ok("Moneda Registrada");
        
        }

        //GET api/Cash/Dolar
        [HttpGet("{nombre}")] // No Funciona
        public IActionResult Get(string nombre)
        {
            foreach(Moneda mon in lst)
            {
                if (mon.Nombre.Equals(nombre))
                return Ok(mon);
         
            }
            return NotFound("Moneda No Registrada");
        }
    }
}
