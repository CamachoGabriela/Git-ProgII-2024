using EnvioBack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly EnviosDbContext _context;

        public EmpresaRepository(EnviosDbContext enviosDbContext)
        {
            _context = enviosDbContext;
        }

        public async Task<bool> Create(TEmpresa empresa)
        {
            _context.TEmpresas.Add(empresa);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Delete(int id)
        {
            var IdEmpresa = await _context.TEmpresas.FindAsync(id);
            _context.TEmpresas.Remove(IdEmpresa);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<List<TEmpresa>> GetByDate(DateTime fecha)
        {
            return await _context.TEmpresas.Where(x => x.FechaBaja<fecha).ToListAsync();
        }

        public async Task<bool> Update(int id, TEmpresa empresa)
        {
            var idEmpresa = await (_context.TEmpresas.FindAsync(id));
            idEmpresa.RazonSocial = empresa.RazonSocial;
            idEmpresa.Rubro = empresa.Rubro;
            idEmpresa.FechaBaja = empresa.FechaBaja;
            idEmpresa.CodPostal = empresa.CodPostal;
            _context.TEmpresas.Update(idEmpresa);


            return await _context.SaveChangesAsync() > 0;
        }
    }
}
