using BackRecetas.Data.Entities;
using BackRecetas.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Services
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _repository;
        public RecetaService(IRecetaRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CrearReceta(Receta receta)
        {
            return await _repository.Create(receta);
        }

        public async Task<bool> EliminarReceta(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Receta>> GetAllRecetas()
        {
            return await _repository.GetAll();
        }

        public async Task<Receta?> GetRecetaById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> ModificarReceta(int id, Receta receta)
        {
            return await _repository.Update(id, receta);
        }
    }
}
