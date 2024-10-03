using ProductoBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoBack.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task<bool> Create(Producto producto);
        Task<bool> Update(int id, Producto producto);
        Task<bool> Delete(int id, string motivo);
    }
}
