using BackRecetas.Data.Entities;
using BackRecetas.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackRecetas.Services
{
    public class IngredienteService : IIngredienteService
    {
        private readonly IIngredienteRepository _repository;
        public IngredienteService(IIngredienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AgregarIngrediente(Ingrediente ingrediente)
        {
            return await _repository.Create(ingrediente);
        }

        public async Task<bool> EliminarIngrediente(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Ingrediente>> GetAllIngredientes()
        {
            return await _repository.GetAll();
        }

        public async Task<Ingrediente?> GetIngrediente(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> ModificarIngrediente(int id, Ingrediente ingrediente)
        {
            return await _repository.Update(id, ingrediente);
        }
    }
}
