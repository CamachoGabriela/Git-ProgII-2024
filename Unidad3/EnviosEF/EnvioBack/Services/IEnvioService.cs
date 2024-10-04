using EnvioBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Services
{
    public interface IEnvioService
    {
        Task<List<TEnvio>> GetEnvios(DateTime fecha1, DateTime fecha2);
        Task<bool> CrearEnvio(TEnvio envio);
        Task<bool> CancelarEnvio(int id);
        bool Validar(TEnvio envio);
    }
}
