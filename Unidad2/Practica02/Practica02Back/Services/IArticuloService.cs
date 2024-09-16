using Practica02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02Back.Services
{
    public interface IArticuloService
    {
        List<Articulo> GetArticulos();
        bool RegistrarArticulo(Articulo a);
        bool BorrarArticulo(int id);
        bool EsValido(Articulo a);
    }
}
