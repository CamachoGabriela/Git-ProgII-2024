using Microsoft.EntityFrameworkCore;
using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private TurnosDbContext _context;
        public ServicioRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TServicio servicio)
        {
            _context.Add(servicio);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Delete(int id)
        {
            var servicioEliminado = await _context.TServicios.FindAsync(id);
            servicioEliminado.Activo = false;

            _context.TServicios.Update(servicioEliminado);
            return await _context.SaveChangesAsync()>0;

        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _context.TServicios.Where(x=>x.Activo==true).ToListAsync(); 
        }

        public async Task<TServicio?> GetById(int id)
        {
            return await _context.TServicios.FindAsync(id);
        }

        public async Task<bool> Update(int id, TServicio servicio)
        {
            var servicioExistente = await _context.TServicios.FindAsync(id);
            if (servicio != null)
            {
                servicioExistente.Nombre = servicio.Nombre;
                servicioExistente.Costo = servicio.Costo;
                servicioExistente.EnPromocion = servicio.EnPromocion;
                _context.TServicios.Update(servicioExistente);
                return await _context.SaveChangesAsync() > 0;
            } 
            return false;
        }
    }
}
