using Practica04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public interface IServicioRepository
    {
        List<TServicio> GetAll();
        TServicio? GetById(int id);

        List<TServicio>? GetByFilter(string? nombre, string? enPromo);
        void Create(TServicio servicio);
        void Update(TServicio servicio, int id);
        void Delete(int id);
    }
}
