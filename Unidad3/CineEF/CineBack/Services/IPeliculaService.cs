using CineBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Services
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> GetAllPeliculas();
        Task<Pelicula?> GetPeliculaById(int id);
        Task<bool> RegistrarPelicula(Pelicula pelicula);
        Task<bool> ModificarPelicula(int id, Pelicula pelicula);
        Task<bool> EliminarPelicula(int id);
        bool ValidarCampos(Pelicula pelicula);
    }
}
