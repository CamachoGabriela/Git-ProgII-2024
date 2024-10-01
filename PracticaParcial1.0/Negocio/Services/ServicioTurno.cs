using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Negocio.Data.Entities;
using Negocio.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ServicioTurno : IServicioTurno
    {
        private readonly ITurnoRepository _turnoRepository;
        public ServicioTurno(ITurnoRepository repository)
        {
            _turnoRepository = repository;
        }
        public async Task<bool> CancelarTurno(int id, string motivo)
        {
            return await _turnoRepository.Delete(id, motivo);
        }

        public async Task<bool> EditarTurno(int id, TTurno turno)
        {
            return await _turnoRepository.Update(id, turno);
        }

        public async Task<TTurno?> GetTurno(int id)
        {
            return await _turnoRepository.GetById(id);
        }

        public async Task<List<TTurno>> GetTurnos()
        {
            return await _turnoRepository.GetAll();
        }

        public async Task<bool> RegistrarTurno(TTurno turno)
        {
            if (await ValidarFecha(turno.Fecha, turno.Hora))
            {
                //Truncar la longitud de fecha a varchar(10)
                turno.Fecha = turno.Fecha?.Substring(0, Math.Min(turno.Fecha.Length, 10));
                return await _turnoRepository.Create(turno);
            }
            return false;
        }

        public bool Validar(TTurno? turno, int id)
        {
            var isMatch = Regex.IsMatch(id.ToString(),@"^\d+$");
            var aux = false;
            if (id != null && isMatch)
            {
                aux = true;
            }
            return aux;
        }
        //Deberá controlar que la fecha de reserva no supere los 45 días a la fecha actual.
        public async Task<bool> ValidarFecha(string fecha, string? hora)
        {
            var fec = Convert.ToDateTime(fecha);
            var hs = TimeSpan.Parse(hora);

            var fechaMaxima = DateTime.Today.AddDays(45);
            if (fec > fechaMaxima) return false;


            var lst = await _turnoRepository.GetAll();
            //solo es posible registrar el turno si para la fecha y hora seleccionadas no existe un registro previamente cargado.
            var existe = lst.Where(x=>x.Fecha.Equals(fecha) && x.Hora.Equals(hora)).FirstOrDefault();
            return existe == null;
        }
    }
}
