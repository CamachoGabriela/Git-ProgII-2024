using Microsoft.EntityFrameworkCore;
using Negocio.Data.Entities;
using Negocio.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class DetallesTurnoService : IDetallesTurnoService
    {
        private IDetallesTurnoRepository _repository;
        public DetallesTurnoService(IDetallesTurnoRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> EditarDetalle(int idT, int idS, TDetallesTurno detalles)
        {
            return _repository.Update(idT,idS, detalles);
        }

        public async Task<bool> EliminarDetalle(int idT, int idS)
        {
            return await _repository.Delete(idT,idS);
        }

        public async Task<List<TDetallesTurno>> GetAllDetalles()
        {
            return await _repository.GetAll();
        }

        public async Task<TDetallesTurno?> GetDetalle(int idT, int idS)
        {
            return await _repository.GetById(idT, idS);
        }

        public async Task<bool> RegistrarDetalle(TDetallesTurno detalle)
        {
            if(await ValidarRepeticion(detalle))
                return await _repository.Create(detalle);
            return false;
        }

        public async Task<bool> ValidarRepeticion(TDetallesTurno detalle)
        {
            // controlar que no se pueden grabar dos veces el mismo servicio como detalle
       
            var lst = await _repository.GetAll();
            var existe = lst.FirstOrDefault(x=>x.IdTurno == detalle.IdTurno && x.IdServicio== detalle.IdServicio);
            return existe == null;
        }
    }
}
