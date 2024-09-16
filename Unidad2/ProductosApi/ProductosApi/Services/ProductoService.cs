using Microsoft.Extensions.Configuration.UserSecrets;
using ProductosApi.Models;
using System.Data;

namespace ProductosApi.Services
{
    public class ProductoService : IAplication
    {
        public static List<Producto> lstProducto = new List<Producto>();
        public bool DeleteProducto(int id)
        {
            var result = false;
            var producto = lstProducto.Find(p => p.Codigo == id);
            if (producto != null)
            {
                lstProducto.Remove(producto);
                result = true;
            }
            return result ;
        }

        public Producto? GetById(int id)
        {
            var producto = lstProducto.Find(producto => producto.Codigo == id);
            
            return producto;
        }

        public List<Producto> GetProductos()
        {
            return lstProducto;
        }

        public bool SaveProducto(Producto oProducto)
        {
            bool result = false;
            if (oProducto != null)
            {
                lstProducto.Add(oProducto);
                result = true;
            }
            return result ;
        }
    }
}
