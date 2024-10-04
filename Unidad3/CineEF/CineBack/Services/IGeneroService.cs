using CineBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Services
{
    public interface IGeneroService
    {
        Task<List<Genero>> GetAllGeneros();
        Task<Genero?> GetGeneroById(int id);
        Task<bool> RegistrarGenero(Genero genero);
        Task<bool> ModificarGenero (int id, Genero genero);
        Task<bool> EliminarGenero (int id);
        bool ValidarCampos(Genero genero);
    }
}
