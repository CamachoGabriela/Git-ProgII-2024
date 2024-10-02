using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private TurnosDbContext _context;
        public TurnoRepository(TurnosDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TTurno turno)
        {
            _context.TTurnos.Add(turno);
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<bool> Delete(int id, string motivo)
        {
            var turnoEliminado = await _context.TTurnos.FindAsync(id);
            if (turnoEliminado != null)
            {
                turnoEliminado.FechaCancelacion = DateTime.Now;
                turnoEliminado.MotivoCancelacion = motivo;
                _context.TTurnos.Update(turnoEliminado);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _context.TTurnos.Where(x=>x.FechaCancelacion==null).ToListAsync();
        }

        public async Task<TTurno?> GetById(int id)
        {
            return await _context.TTurnos.FindAsync(id);
        }

        public async Task<bool> Update(int id, TTurno turno)
        {
            var turnoExistente = await _context.TTurnos.FindAsync(id);
            if (turnoExistente == null) return false;
            turnoExistente.Fecha = turno.Fecha;
            turnoExistente.Hora = turno.Hora;
            if(!string.IsNullOrEmpty(turno.Cliente))
                turnoExistente.Cliente = turno.Cliente;
            _context.TTurnos.Update(turnoExistente);
            
            return await _context.SaveChangesAsync()>0;

        }
       
    }
}
