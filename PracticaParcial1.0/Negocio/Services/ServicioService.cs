using Negocio.Data.Entities;
using Negocio.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;
        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CancelarServicio(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> EditarServicio(int id, TServicio servicio)
        {
            return await _repository.Update(id, servicio);
        }

        public async Task<TServicio?> GetServicio(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<TServicio>> GetServicios()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> RegistrarServicio(TServicio servicio)
        {
            return await _repository.Create(servicio);
        }
    }
}
