using Negocio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public interface IServicioTurno
    {
        Task<List<TTurno>> GetTurnos();
        Task<TTurno?> GetTurno(int id);
        Task<bool> RegistrarTurno(TTurno turno);
        Task<bool> EditarTurno(int id, TTurno turno);
        Task<bool> CancelarTurno(int id, string motivo);
        bool Validar(TTurno? turno,int id);
        Task<bool> ValidarFecha(string fecha, string? hora);
    }
}
