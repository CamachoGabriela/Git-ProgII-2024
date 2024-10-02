using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public interface IDetallesTurnoRepository
    {
        Task<List<TDetallesTurno>> GetAll();
        Task<TDetallesTurno?> GetById(int idT, int idS);
        Task<bool> Create(TDetallesTurno detalle);
        Task<bool> Update(int idT, int idS, TDetallesTurno detalle);
        Task<bool> Delete(int idT, int idS);
    }
}
