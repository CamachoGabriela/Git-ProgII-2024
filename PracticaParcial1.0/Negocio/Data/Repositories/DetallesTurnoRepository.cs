using Microsoft.EntityFrameworkCore;
using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public class DetallesTurnoRepository : IDetallesTurnoRepository
    {
        private TurnosDbContext _context;
        public DetallesTurnoRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TDetallesTurno detalle)
        {
            // controlar que no se pueden grabar dos veces el mismo servicio como detalle
            var existe = await _context.TDetallesTurnos.FirstOrDefaultAsync(x=>x.IdTurno == detalle.IdTurno && x.IdServicio==detalle.IdServicio);
            if (existe != null) return false; 
            _context.TDetallesTurnos.Add(detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int idT, int idS)
        {
            var detalleEliminado = await _context.TDetallesTurnos.FindAsync(idT,idS);
            if (detalleEliminado != null)
            {
                _context.TDetallesTurnos.Remove(detalleEliminado);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<TDetallesTurno>> GetAll()
        {
            return await _context.TDetallesTurnos.ToListAsync();
        }

        public async Task<TDetallesTurno?> GetById(int idT, int idS)
        {
            return await _context.TDetallesTurnos.FindAsync(idT, idS);
        }

        public async Task<bool> Update(int idT, int idS, TDetallesTurno detalle)
        {
            var detallesExistentes = await _context.TDetallesTurnos.FindAsync(idT,idS);
            if(detallesExistentes != null)
            {
                //detallesExistentes.IdServicio= detalle.IdServicio;
                //detallesExistentes.IdTurno= detalle.IdTurno;
                detallesExistentes.Observaciones = detalle.Observaciones;
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
