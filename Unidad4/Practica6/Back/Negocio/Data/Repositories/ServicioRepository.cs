using Microsoft.EntityFrameworkCore;
using Practica04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private ServiciosDbContext _context;
        public ServicioRepository(ServiciosDbContext context)
        {
            _context = context;
        }

        public void Create(TServicio servicio)
        {
            _context.TServicios.Add(servicio);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var serviciosEliminados = GetById(id);
            if (serviciosEliminados != null)
            {
                serviciosEliminados.Activo = false;
                _context.TServicios.Update(serviciosEliminados);
                _context.SaveChanges();
            }
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.Where(x => x.Activo == true).ToList();
        }

        public List<TServicio>? GetByFilter(string? nombre, string? enPromo)
        {
            if (nombre != null && enPromo != null)
                return _context.TServicios.Where(x => x.Nombre.Contains(nombre) && x.EnPromocion == enPromo && x.Activo==true).ToList();
            else if (nombre != null)
                return _context.TServicios.Where(x => x.Nombre.Contains(nombre) && x.Activo == true).ToList();
            else
                return _context.TServicios.Where(x=>x.EnPromocion==enPromo && x.Activo == true).ToList();
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public void Update(TServicio servicio, int id)
        {
            if (servicio != null)
            {
                var serv = _context.TServicios.Find(id);
                if (serv != null)
                {
                    if (servicio.Costo != 0)
                        serv.Costo = servicio.Costo;
                    if (servicio.Nombre != null)
                        serv.Nombre = servicio.Nombre;
                    if (servicio.EnPromocion != null)
                        serv.EnPromocion = servicio.EnPromocion;
                    _context.TServicios.Update(serv);
                    _context.SaveChanges();
                }
                
            }
        }
    }
}
