using EnvioBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Data.Repositories
{
    public interface IEnvioRepository
    {
        Task<List<TEnvio>> GetAllDates(DateTime fecha1, DateTime fecha2);
        Task<bool> Create(TEnvio envio);
        Task<bool> Delete(int id);
    }
}
