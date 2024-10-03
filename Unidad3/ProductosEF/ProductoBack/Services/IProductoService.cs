using ProductoBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoBack.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAllProductos();
        Task<Producto?> GetById(int id);
        Task<bool> RegistrarProducto(Producto producto);
        Task<bool> ModificarProducto(int id, Producto producto);
        Task<bool> CancelarProducto(int id, string motivo);
        Task<bool> ValidarRegistroProducto(string nombre);
        Task<bool> ValidarActualizaciones(Producto producto);
    }
}
