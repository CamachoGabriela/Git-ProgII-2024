using BackRecetas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Data.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasDbContext _context;
        public RecetaRepository(RecetasDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Receta receta)
        {
            _context.Recetas.Add(receta);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> Delete(int id)
        {
            var recetaEliminar = await _context.Recetas.FindAsync(id);
            if ((recetaEliminar!= null))
            {
                recetaEliminar.Cheff = null;
                _context.Recetas.Update(recetaEliminar);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Receta>> GetAll()
        {
            return await _context.Recetas.Where(x=>x.Cheff != null).ToListAsync();
        }

        public async Task<Receta?> GetById(int id)
        {
            return await _context.Recetas.FindAsync(id);
        }

        public async Task<bool> Update(int id, Receta receta)
        {
            var recetaExistente = await _context.Recetas.FindAsync(id);
            if(recetaExistente != null)
            {
                recetaExistente.Ingredientes = receta.Ingredientes;
                recetaExistente.Nombre = receta.Nombre;
                recetaExistente.Cheff = receta.Cheff;
                _context.Recetas.Update(recetaExistente);
                return await _context.SaveChangesAsync()>0;
            }
            return false;
        }
    }
}
