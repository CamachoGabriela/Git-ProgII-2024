using Practica02.Data;
using Practica02Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02Back.Services
{
    public class FacturaServicio
    {
        private IAplicacion _repository;
        public FacturaServicio()
        {
            _repository = new Aplicacion();
        }

        public bool SaveFactura(Factura oFactura)
        {
            return _repository.SaveFactura(oFactura);
        }
        public Factura GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Factura> ConsultaFiltros(DateTime fecha, int fp)
        {
            return _repository.ConsultaFiltros(fecha,fp);
        }

    }
}
