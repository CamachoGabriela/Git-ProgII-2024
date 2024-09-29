using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasApp.Interfaces
{
    public abstract class ColleccionAbstracta : IColleccion
    {
        protected int siguiente;
        protected object[] coleccion;

        protected ColleccionAbstracta(int size)
        {
            coleccion = new object[size];
            siguiente = -1;
        }

        public virtual bool Añadir(object elemento)
        {
            bool añadido = false;

            if (siguiente < coleccion.Length)
            {
                coleccion[++siguiente] = elemento;
                añadido = true;
            }
            return añadido;
        }

        public virtual bool EstaVacia()
        {
            return siguiente == -1;
        }

        public abstract object Extraer();

        public void mostrarElementos()
        {
            for(int i = 0; i < siguiente; i++)
            {
                Console.WriteLine(coleccion[i]);
            }
        }

        public virtual object Primero()
        {
            if (!EstaVacia())
            {
                return coleccion[0];
            }
            else
            {
                return "No hay ningún objeto";
            }
        }
    }
}
