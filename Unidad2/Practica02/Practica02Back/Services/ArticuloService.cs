using Practica02.Data;
using Practica02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02Back.Services
{
    public class ArticuloService : IArticuloService
    {
        private IAplicacion app;

        public ArticuloService()
        {
            app= new Aplicacion();
        }
        public bool BorrarArticulo(int id)
        {
            return app.RegistrarBajaArticulo(id);
        }

        public bool EsValido(Articulo a)
        {
            return app.Validar(a); 
        }

        public List<Articulo> GetArticulos()
        {
            return app.ConsultarArticulo();
        }

        public bool RegistrarArticulo(Articulo a)
        {
            return app.SaveArticulo(a);
        }
    }
}
