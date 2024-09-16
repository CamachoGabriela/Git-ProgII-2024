using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using System.Globalization;
using FechaApi.Models;

namespace FechaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        private string[] diaSemana;

        public FechaController()
        {
            diaSemana = new string[] { "Dom", "Lun", "Mar", "Mier", "Jue", "Vie", "Sab"  };        
        }

        static readonly List<Fecha>lst = new List<Fecha>();

        [HttpGet] //[HttpGet("/id")]
        public IActionResult Get()
        {
            var fec  =DateTime.Now;
            var value = new Fecha()
            {
                Numero = fec.Day,
                Dia = diaSemana[(int)fec.DayOfWeek], 
                Mes = fec.Month.ToString(),
                Anho = fec.Year
            };
            return Ok(value);
        }

    }
}

