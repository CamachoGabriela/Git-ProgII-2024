using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public interface IServicioRepository
    {
        Task<List<TServicio>> GetAll();
        Task<TServicio?> GetById(int id);
        Task<bool> Create(TServicio servicio);
        Task<bool> Update(int id, TServicio servicio);
        Task<bool> Delete(int id);
    }
}
