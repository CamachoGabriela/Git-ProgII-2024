using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCine.Data.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> GetAll();
        Task<Pelicula?> GetById(int id);
        Task<Pelicula?> GetByTitle(string titulo);
        Task<List<Pelicula?>> GetByGenre(string genero);
        Task<bool> Create(Pelicula pelicula);
        Task<bool> Update(int id, Pelicula pelicula);
        Task<bool> Delete(int id);
    }
}
