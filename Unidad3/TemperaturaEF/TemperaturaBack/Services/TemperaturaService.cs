using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturaBack.Data.Entities;
using TemperaturaBack.Data.Repositories;

namespace TemperaturaBack.Services
{
    public class TemperaturaService : ITemperaturaService
    {
        private readonly ITemperaturaRepository _repository;
        public TemperaturaService(ITemperaturaRepository repository)
        {
                _repository = repository;
        }
        public async Task<bool> DeleteTemperatura(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> EditarTemperatura(int id, Temperatura temperatura)
        {
            return await _repository.Update(id, temperatura);
        }

        public async Task<List<Temperatura>> GetAllTemperaturas()
        {
            return await _repository.GetAll();
        }

        public async Task<Temperatura?> GetTemperaturaById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> RegistrarTemperatura(Temperatura temperatura)
        {
            return await _repository.Create(temperatura);
        }
    }
}
