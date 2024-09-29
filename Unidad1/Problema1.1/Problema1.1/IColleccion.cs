using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._1
{
    public interface IColleccion
    {
        bool EstaVacia();

        object Extraer();

        object Primero();

        void Añadir(Pila p);
    }
}
