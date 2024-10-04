using EnvioBack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBack.Services
{
    public interface IEmpresaService
    {

        Task<bool> Create(TEmpresa empresa);

        Task<List<TEmpresa>> GetByDate(DateTime fecha);

        Task<bool> Delete(int id);

        Task<bool> Update(int id,TEmpresa empresa);

    }
}
