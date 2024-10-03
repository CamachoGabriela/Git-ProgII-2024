using ProductoBack.Data.Models;
using ProductoBack.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoBack.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;   
        }
        public async Task<bool> CancelarProducto(int id, string motivo)
        {
            var productoEliminado = await _repository.GetById(id);
            if(productoEliminado!= null)
            {
                if (!await ValidarActualizaciones(productoEliminado))
                    return await _repository.Delete(id, motivo);
            }
            return false;
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            return await _repository.GetAll();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> ModificarProducto(int id, Producto producto)
        {
            if (!await ValidarActualizaciones(producto))
                return await _repository.Update(id, producto);
            return false;
        }

        public async Task<bool> RegistrarProducto(Producto producto)
        {
            if(!ValidarRegistroProducto(producto.Nombre).Result)
                return await _repository.Create(producto);
            return false;
        }

        public async Task<bool> ValidarActualizaciones(Producto producto)
        {
            var productoActualizar = await _repository.GetAll();
            return producto == productoActualizar.Where(x => x.FechaBaja == null && x.MotivoBaja == null);
        }

        public async Task<bool> ValidarRegistroProducto(string nombre)
        {
            var productoValido = await _repository.GetAll();
            return productoValido.Any(x => x.Nombre == nombre);
        }
    }
}
