using EnvioBack.Data.Entities;
using EnvioBack.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly IEnvioRepository _repository;
        public EnvioService(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CancelarEnvio(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> CrearEnvio(TEnvio envio)
        {
            if(Validar(envio))
                return await _repository.Create(envio);
            return false;
        }

        public async Task<List<TEnvio>> GetEnvios(DateTime fecha1, DateTime fecha2)
        {
            return await _repository.GetAllDates(fecha1, fecha2);
        }

        public bool Validar(TEnvio envio)
        {
            return envio.Estado != null && envio.IdEmpresa != null && envio.Direccion != null && envio.DniCliente != null && envio.FechaEnvio != null;
        }
    }
}
