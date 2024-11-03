﻿using BackCine.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCine.Data.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private CineMaxContext _context;
        public PeliculaRepository(CineMaxContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var peliEliminada = await _context.Peliculas.FindAsync(id);
            if (peliEliminada != null)
            {
                peliEliminada.EstaActivo = false;
                _context.Peliculas.Update(peliEliminada);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Pelicula>> GetAll()
        {
            return await _context.Peliculas.Where(x => x.EstaActivo == true).ToListAsync();
        }

        public async Task<List<Pelicula?>> GetByGenre(string genero)
        {
        }

        public async Task<Pelicula?> GetById(int id)
        {
            return await _context.Peliculas.FindAsync(id);
        }

        public Task<Pelicula?> GetByTitle(string titulo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
