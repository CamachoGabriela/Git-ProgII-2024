using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02Back.Models
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public string Cliente { get; set; }
        public List<Detalle> Detalles { get; set; } //private??

        public List<Detalle> Details()
        {
            return Detalles;
        }
        public Factura()
        {
            Detalles = new List<Detalle>();
        }
        public void AddDetail(Detalle detail)
        {
            if (detail != null)
                Detalles.Add(detail);
        }

        public void Remove(int index)
        {
            Detalles.RemoveAt(index);
        }
    }
}
