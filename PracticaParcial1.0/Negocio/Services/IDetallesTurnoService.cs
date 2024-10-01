using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public interface IDetallesTurnoService
    {
        Task<List<TDetallesTurno>> GetAllDetalles();
        Task<TDetallesTurno?> GetDetalle(int idT,int idS);
        Task <bool> RegistrarDetalle(TDetallesTurno detalle);
        Task<bool> EditarDetalle(int idT, int idS, TDetallesTurno detalles);
        Task<bool> EliminarDetalle(int idT, int idS);
    }
}
