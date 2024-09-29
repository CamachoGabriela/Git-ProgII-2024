using Microsoft.AspNetCore.Mvc;
using WebProductos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private static readonly List<Producto> lst = new List<Producto>();

        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            foreach(var p in lst)
            {
                if (p.Codigo.Equals(id))
                {
                    return Ok(p.ToString());
                }
            }
            return NotFound("Producto no encontrado");
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto p)
        {
            bool exist = false;
            foreach(var producto in lst)
            {
                if (producto.Codigo.Equals(p.Codigo))
                {
                    exist = true;
                }
            }

            if(p == null || string.IsNullOrEmpty(p.Nombre) || p.Precio <= 0 || exist)
            {
                return BadRequest("Datos incorrectos");
            }
            else
            {
                lst.Add(p);
                return Ok("Producto Registrado");
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto p)
        {
            foreach(var producto in lst)
            {
                if (producto.Codigo.Equals(id))
                {
                    producto.Nombre = p.Nombre;
                    producto.Precio = p.Precio;
                    return Ok("Producto actualizado");
                }            
            }
            return NotFound("Objeto no encontrado para actualizarse");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            foreach(var p in lst)
            {
                if (p.Codigo.Equals(id))
                {
                    lst.Remove(p);
                    return Ok("Objeto eliminado");
                }
            }
            return NotFound("No se encontro el objeto para eliminar");
        }
    }
}
