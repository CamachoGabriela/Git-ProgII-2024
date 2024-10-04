using CineBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Data.Repositories
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetAll();
        Task<Genero?> GetById(int id);
        Task<bool> Create(Genero genero);
        Task<bool> Update(int id, Genero genero);
        Task<bool> Delete(int id);
    }
}
