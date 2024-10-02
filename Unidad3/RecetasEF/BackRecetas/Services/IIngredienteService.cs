using BackRecetas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Services
{
    public interface IIngredienteService
    {
        Task<List<Ingrediente>> GetAllIngredientes();
        Task<Ingrediente?> GetIngrediente(int id);
        Task<bool> AgregarIngrediente(Ingrediente ingrediente);
        Task<bool> ModificarIngrediente(int id, Ingrediente ingrediente);
        Task<bool> EliminarIngrediente(int id);
    }
}
