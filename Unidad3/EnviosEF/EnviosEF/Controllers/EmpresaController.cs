using EnvioBack.Data.Entities;
using EnvioBack.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnviosEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _service;

        public EmpresaController(IEmpresaService empresaService)
        {
            _service = empresaService;
        }


        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime fecha)
        {
            try
            {
                return Ok(await _service.GetByDate(fecha));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }
        }


        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEmpresa empresa)
        {
            try
            {
                await _service.Create(empresa);
                return Ok("Creado :D");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TEmpresa empresa)
        {
            try
            {
                await _service.Update(id, empresa);
                return Ok("Actualizado :D");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }


        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok("Empresa eliminada =(");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }

        }
    }
}
