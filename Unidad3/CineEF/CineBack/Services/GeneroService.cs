using CineBack.Data.Entities;
using CineBack.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repository;
        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> EliminarGenero(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Genero>> GetAllGeneros()
        {
            return await _repository.GetAll();
        }

        public async Task<Genero?> GetGeneroById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> ModificarGenero(int id, Genero genero)
        {
            return await _repository.Update(id, genero);
        }

        public async Task<bool> RegistrarGenero(Genero genero)
        {
            if(ValidarCampos(genero)) 
                return await _repository.Create(genero);
            return false;
        }

        public bool ValidarCampos(Genero genero)
        {
            return genero.Nombre != null ? true : false;
        }
    }
}
