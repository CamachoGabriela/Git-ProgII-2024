using CineBack.Data.Entities;
using CineBack.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repository;
        public PeliculaService(IPeliculaRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> EliminarPelicula(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Pelicula>> GetAllPeliculas()
        {
            return await _repository.GetAll();
        }

        public async Task<Pelicula?> GetPeliculaById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> ModificarPelicula(int id, Pelicula pelicula)
        {
            return await _repository.Update(id, pelicula);
        }

        public async Task<bool> RegistrarPelicula(Pelicula pelicula)
        {
            if(ValidarCampos(pelicula))
                return await _repository.Create(pelicula);
            return false;
        }

        public bool ValidarCampos(Pelicula pelicula)
        {
            return pelicula.Titulo != null && pelicula.Anho != null && pelicula.Director != null && pelicula.Genero != null;
        }
    }
}
