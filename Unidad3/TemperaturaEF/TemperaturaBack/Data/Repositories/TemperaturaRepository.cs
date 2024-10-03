using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturaBack.Data.Entities;

namespace TemperaturaBack.Data.Repositories
{
    public class TemperaturaRepository : ITemperaturaRepository
    {
        private readonly TemperaturaDbContext _context;
        public TemperaturaRepository(TemperaturaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Temperatura temperatura)
        {
            if(temperatura != null)
            {
                temperatura.FechaHora = DateTime.Now;
                _context.Temperaturas.Add(temperatura);
                return await _context.SaveChangesAsync() >0;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var temperaturaActual = await _context.Temperaturas.FindAsync(id);
            if (temperaturaActual != null)
            {
                _context.Temperaturas.Remove(temperaturaActual);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;

        }

        public async Task<List<Temperatura>> GetAll()
        {
            return await _context.Temperaturas.ToListAsync();
        }

        public async Task<Temperatura?> GetById(int id)
        {
            return await _context.Temperaturas.FindAsync(id);
        }

        public async Task<bool> Update(int id, Temperatura temperatura)
        {
            var temperaturaExistente = await _context.Temperaturas.FindAsync(id);
            if(temperaturaExistente != null)
            {
                temperaturaExistente.FechaHora = DateTime.Now;
                temperaturaExistente.Valor = temperatura.Valor;

                _context.Temperaturas.Update(temperaturaExistente);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
