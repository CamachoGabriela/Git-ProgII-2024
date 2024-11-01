using CineBack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Data.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineDbContext _context;
        public PeliculaRepository(CineDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Pelicula pelicula)
        {
            if(pelicula != null)
            {
                pelicula.Estreno = true;
                _context.Peliculas.Add(pelicula);
                return await _context.SaveChangesAsync() >0;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var peliculaEliminar = await _context.Peliculas.FindAsync(id);
            if(peliculaEliminar!= null)
            {
                peliculaEliminar.Estreno = false;   
                _context.Peliculas.Update(peliculaEliminar);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Pelicula>> FindByGender(int id)
        {
            return await _context.Peliculas.Where(x=>x.GeneroNavigation.Id==id && x.Estreno==true).ToListAsync();
        }

        public async Task<List<Pelicula>> GetAll()
        {
            return await _context.Peliculas.Where(x=>x.Estreno==true).ToListAsync();
        }

        public async Task<Pelicula?> GetById(int id)
        {
            return await _context.Peliculas.FindAsync(id);
        }

        public async Task<bool> Update(int id, Pelicula pelicula)
        {
            var peliculaActual = await _context.Peliculas.FindAsync(id);
            if (peliculaActual!= null && pelicula != null)
            {
                if (!string.IsNullOrEmpty(pelicula.Titulo))
                    peliculaActual.Titulo = pelicula.Titulo;
                if (!string.IsNullOrEmpty(pelicula.Director))
                    peliculaActual.Director = pelicula.Director;
                if (pelicula.Anho != null)
                    peliculaActual.Anho = pelicula.Anho;
                if (pelicula.GeneroNavigation != null)
                    peliculaActual.GeneroNavigation = pelicula.GeneroNavigation;

                _context.Peliculas.Update(peliculaActual);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
