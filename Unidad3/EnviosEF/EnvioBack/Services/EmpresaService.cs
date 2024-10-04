using EnvioBack.Data.Entities;
using EnvioBack.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _repository = empresaRepository;   
        }

        public async Task<bool> Create(TEmpresa empresa)
        {
            if(Validar(empresa))
                await _repository.Create(empresa);
            return false;
        }

        private bool Validar(TEmpresa empresa)
        {
            return empresa.Id != null && empresa.RazonSocial != null && empresa.Rubro != null && empresa.FechaBaja != null && empresa.CodPostal !=null;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<TEmpresa>> GetByDate(DateTime fecha)
        {
            return await _repository.GetByDate(fecha);
        }

        public async Task<bool> Update(int id, TEmpresa empresa)
        {
            return await _repository.Update(id, empresa);
        }
    }
}
