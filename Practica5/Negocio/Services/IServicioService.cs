using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public interface IServicioService
    {
        Task<List<TServicio>> GetServicios();
        Task<TServicio?> GetServicio(int id);
        Task<bool> RegistrarServicio(TServicio servicio);
        Task<bool> EditarServicio(int id, TServicio servicio);
        Task<bool> CancelarServicio(int id);
    }
}
