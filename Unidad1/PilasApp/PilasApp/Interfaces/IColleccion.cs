using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasApp.Interfaces
{
    public interface IColleccion
    {
        bool EstaVacia();

        object Extraer();

        object Primero();

        bool Añadir(object elemento);

        void mostrarElementos();
    }
}
