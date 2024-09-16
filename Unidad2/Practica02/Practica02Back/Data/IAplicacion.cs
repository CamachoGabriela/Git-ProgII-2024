using Microsoft.Win32;
using Practica02.Models;
using System.Collections.Generic;

namespace Practica02.Data
{
    public interface IAplicacion
    {
        bool SaveArticulo(Articulo a);
        List<Articulo> ConsultarArticulo();
        bool RegistrarBajaArticulo(int id);
        bool Validar(Articulo a);
    }
}
