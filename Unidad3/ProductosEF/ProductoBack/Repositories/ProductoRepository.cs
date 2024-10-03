using Microsoft.EntityFrameworkCore;
using ProductoBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoBack.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosDbContext _context;
        public ProductoRepository(ProductosDbContext contexto)
        {
            _context = contexto;
        }
        public async Task<bool> Create(Producto producto)
        {
            _context.Productos.Add(producto);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Delete(int id, string motivo)
        {
            var productoEliminado = await _context.Productos.FindAsync(id);
            if(productoEliminado != null)
            {
                productoEliminado.FechaBaja = DateTime.Now;
                productoEliminado.MotivoBaja = motivo;
                _context.Productos.Update(productoEliminado);
                return await _context.SaveChangesAsync()>0; 
            }
            return false;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.Where(x=>!x.FechaBaja.HasValue && x.MotivoBaja == null).ToListAsync();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<bool> Update(int id, Producto producto)
        {
            var productoActual = await _context.Productos.FindAsync(id);
            if(productoActual != null)
            {
                if(!string.IsNullOrEmpty(producto.Nombre))
                    productoActual.Nombre = producto.Nombre;
                if(producto.Precio != null)
                    productoActual.Precio = producto.Precio;
                _context.Productos.Update(productoActual);
                return await _context.SaveChangesAsync() > 0 ;
            }
            return false;
        }
    }
}
