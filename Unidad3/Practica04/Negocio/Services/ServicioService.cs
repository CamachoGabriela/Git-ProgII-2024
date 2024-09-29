using Negocio.Data.Repositories;
using Practica04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;
        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }
        public void ActualizarServicio(TServicio servicio, int id)
        {
            _repository.Update(servicio, id);
        }

        public void AgregarServicio(TServicio servicio)
        {
            _repository.Create(servicio);
        }

        public void EliminarServicio(int id)
        {
            _repository.Delete(id);
        }

        public TServicio? TraerServicio(int id)
        {
            return _repository.GetById(id);
        }

        public List<TServicio>? TraerServicioFiltrado(string? nombre, string? enPromo)
        {
            return _repository.GetByFilter(nombre, enPromo);
        }

        public List<TServicio> TraerTodosServicios()
        {
            return _repository.GetAll();
        }
    }
}
