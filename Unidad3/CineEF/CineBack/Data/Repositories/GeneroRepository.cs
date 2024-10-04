using CineBack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Data.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly CineDbContext _context;
        public GeneroRepository(CineDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Genero genero)
        {
            if (genero != null)
            {
                _context.Generos.Add(genero);
                return await _context.SaveChangesAsync()>0;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var generoEliminar = await _context.Generos.FindAsync(id);
            if (generoEliminar != null)
            {
                _context.Generos.Remove(generoEliminar);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Genero>> GetAll()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<Genero?> GetById(int id)
        {
            return await _context.Generos.FindAsync(id);
        }

        public async Task<bool> Update(int id, Genero genero)
        {
            var generoActual= await _context.Generos.FindAsync(id);
            if(generoActual != null && genero != null)
            {
                if(!string.IsNullOrEmpty(genero.Nombre))
                    generoActual.Nombre = genero.Nombre;
                if (genero.Peliculas != null)
                    generoActual.Peliculas = genero.Peliculas;

                _context.Generos.Update(generoActual);
                return await _context.SaveChangesAsync() >0;
            }
            return false;
        }
    }
}
