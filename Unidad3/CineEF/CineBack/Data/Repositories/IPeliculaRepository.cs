using CineBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Data.Repositories
{
    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> GetAll();
        Task<Pelicula?> GetById(int id);
        Task<List<Pelicula>> FindByGender(int id);
        Task<bool> Create(Pelicula pelicula);
        Task<bool> Update(int id, Pelicula pelicula);
        Task<bool> Delete(int id);
    }
}
