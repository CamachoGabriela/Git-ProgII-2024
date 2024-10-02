using BackRecetas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Data.Repositories
{
    public interface IIngredienteRepository
    {
        Task<List<Ingrediente>> GetAll();
        Task<Ingrediente?> GetById(int id);
        Task<bool> Create(Ingrediente ingrediente);
        Task<bool> Update(int id, Ingrediente ingrediente);
        Task<bool> Delete(int id);
    }
}
