using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturaBack.Data.Entities;

namespace TemperaturaBack.Services
{
    public interface ITemperaturaService
    {
        Task<List<Temperatura>> GetAllTemperaturas();
        Task<Temperatura?> GetTemperaturaById(int id);
        Task<bool> RegistrarTemperatura(Temperatura temperatura);
        Task<bool>EditarTemperatura(int id, Temperatura temperatura);
        Task<bool> DeleteTemperatura(int id);
    }
}
