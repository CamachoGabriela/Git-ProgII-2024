using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilasApp.Interfaces;

namespace PilasApp.Clases
{
    public class Pila : ColleccionAbstracta
    {
        //Metodos
        public override object Extraer()
        {
            object p;

            if (!EstaVacia())
            {
                p = coleccion[siguiente];

                coleccion[siguiente] = null;
                siguiente--;

                return p;
            }
            else
            {
                return "Está vacía";
            }
        }

        public Pila(int size) : base(size)
        {

        }
    }
}
