using Practica04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public interface IServicioService
    {
        List<TServicio> TraerTodosServicios();
        TServicio? TraerServicio(int id);
        List<TServicio>? TraerServicioFiltrado(string? nombre, string? enPromo);
        void AgregarServicio(TServicio servicio);
        void ActualizarServicio(TServicio servicio, int id);
        void EliminarServicio(int id);
    }
}
