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
            //Actualizar los datos de una reserva siempre que la fecha/hora sean anteriores a los confirmados en su creación
            if (await ValidarActualizacion(id,turno))
                return await _turnoRepository.Update(id, turno);
            return false;
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
            foreach (var detalle in turno.TDetallesTurnos)
            {
                if (!await ValidarServicio(detalle))
                {
                    return false;
                }
            }
           
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

        public async Task<bool> ValidarActualizacion(int id, TTurno turno)
        {
            var lst = await _turnoRepository.GetById(id);
            var horaActual = TimeSpan.Parse(lst.Hora);
            var horaNueva = TimeSpan.Parse(turno.Hora);
            var fechaActual = Convert.ToDateTime(lst.Fecha);
            var fechaNueva = Convert.ToDateTime(turno.Fecha);
            return fechaActual > fechaNueva || (fechaNueva == fechaActual && horaNueva < horaActual);
        }

        //Deberá controlar que la fecha de reserva no supere los 45 días a la fecha actual.
        public async Task<bool> ValidarFecha(string fecha, string? hora)
        {
            if (fecha == null || hora == null) return false;

            var fec = Convert.ToDateTime(fecha);
            var hs = TimeSpan.Parse(hora);

            var fechaMaxima = DateTime.Today.AddDays(45);
            if (fec > fechaMaxima) return false;


            //solo es posible registrar el turno si para la fecha y hora seleccionadas no existe un registro previamente cargado.
            var lst = await _turnoRepository.GetAll();
            var existe = lst.FirstOrDefault(x =>
            {
                var fechaTurno = Convert.ToDateTime(x.Fecha);
                var horaTurno = TimeSpan.Parse(x.Hora);

                return fechaTurno.Date == fec.Date && horaTurno == hs;
            });
            return existe == null;
        }
        // Validar que se ingrese un servicio tmb
        public async Task<bool> ValidarServicio(TDetallesTurno detalle)
        {
            var lst = await _turnoRepository.GetAll();
            var existeServicio = lst.Any(x=>x.TDetallesTurnos.Any(e=>e.IdServicio==detalle.IdServicio));
            return existeServicio;
        }
    }
}
