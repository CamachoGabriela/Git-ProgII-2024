using Microsoft.Win32;
using Practica02.Models;
using Practica02Back.Models;
using System;
using System.Collections.Generic;

namespace Practica02.Data
{
    public interface IAplicacion
    {
        bool SaveArticulo(Articulo a);
        List<Articulo> ConsultarArticulo();
        bool RegistrarBajaArticulo(int id);
        bool Validar(Articulo a);


        bool SaveFactura(Factura oFactura);
        Factura GetById(int id);
        List<Factura> GetFacturas();
        List<Factura> ConsultaFiltros(DateTime fecha, int fp);
        bool UpdateFactura(Factura oFactura);
    }
}
