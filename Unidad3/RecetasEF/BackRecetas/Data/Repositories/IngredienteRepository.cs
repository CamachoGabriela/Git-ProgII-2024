using BackRecetas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Data.Repositories
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly RecetasDbContext _context;
        public IngredienteRepository(RecetasDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var ingEliminado = await _context.Ingredientes.FindAsync(id);
            if (ingEliminado != null)
            {
                _context.Ingredientes.Remove(ingEliminado);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Ingrediente>> GetAll()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        public async Task<Ingrediente?> GetById(int id)
        {
            return await _context.Ingredientes.FindAsync(id);
        }

        public async Task<bool> Update(int id, Ingrediente ingrediente)
        {
            var ingExistente = await _context.Ingredientes.FindAsync(id);
            if(ingExistente != null)
            {
                ingExistente.NIngrediente= ingrediente.NIngrediente;
                ingExistente.Cantidad= ingrediente.Cantidad;
                _context.Ingredientes.Update(ingExistente);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
