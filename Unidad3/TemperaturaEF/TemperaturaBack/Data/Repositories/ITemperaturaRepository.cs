using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturaBack.Data.Entities;

namespace TemperaturaBack.Data.Repositories
{
    public interface ITemperaturaRepository
    {
        Task<List<Temperatura>> GetAll();
        Task<Temperatura?> GetById(int id);
        Task<bool> Create(Temperatura temperatura);
        Task<bool> Update(int id, Temperatura temperatura);
        Task<bool> Delete(int id);
    }
}
