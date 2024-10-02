using BackRecetas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Services
{
    public interface IRecetaService
    {
        Task<List<Receta>> GetAllRecetas();
        Task<Receta?> GetRecetaById(int id);
        Task<bool> CrearReceta(Receta receta);
        Task<bool> ModificarReceta(int id, Receta receta);
        Task<bool> EliminarReceta(int id);
    }
}
