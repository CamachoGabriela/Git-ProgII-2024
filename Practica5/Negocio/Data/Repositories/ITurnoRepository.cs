using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public interface ITurnoRepository
    {
        Task<List<TTurno>> GetAll();
        Task<TTurno?> GetById(int id);
        Task<bool> Create(TTurno turno);
        Task<bool> Update(int id, TTurno turno);
        Task<bool> Delete(int id, string motivo);
       
    }
}
