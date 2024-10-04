using EnvioBack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Data.Repositories
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly EnviosDbContext _context;
        public EnvioRepository(EnviosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TEnvio envio)
        {
            _context.TEnvios.Add(envio);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Delete(int id)
        {
            var envioEliminar= await _context.TEnvios.FindAsync(id);
            envioEliminar.Estado = "CANCELADO";
            _context.TEnvios.Update(envioEliminar);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<List<TEnvio>> GetAllDates(DateTime fecha1, DateTime fecha2)
        {
            return await _context.TEnvios.Where(x => x.FechaEnvio.CompareTo(fecha1) >= 0 && x.FechaEnvio.CompareTo(fecha2) <= 0).ToListAsync();
        }
    }
}