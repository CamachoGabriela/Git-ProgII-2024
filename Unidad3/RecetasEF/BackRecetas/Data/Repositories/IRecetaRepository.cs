using BackRecetas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Data.Repositories
{
    public interface IRecetaRepository
    {
        Task<List<Receta>> GetAll();
        Task<Receta?> GetById(int id);
        Task<bool> Create(Receta receta);
        Task<bool> Update(int id,Receta receta);
        Task<bool> Delete(int id);
    }
}
