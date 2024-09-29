using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._1
{
    public class Pila : IColleccion
    {
        private int ultimo = 0;
        private object[] array = {new Pila("Hola"), new Pila("Chau")};
        private string nombre;
        public static int Contador { get; set; } = 0;

        public Pila(string nombre)
        {
            ultimo++;
            Contador++;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return nombre;
        }

        public bool EstaVacia()
        {
            bool result = true;
            foreach (object x in array)
            {
                if (x != null)
                {
                    result = false;
                }
            }
            return result;
        }

        public object Extraer()
        {
            object p = array[0];
            for (int i = 0; i < ultimo; i++)
            {
                array[i] = array[i + 1];
            }
            array[ultimo] = null;
            ultimo--;
            return p.ToString();
        }

        public object Primero()
        {
            throw new NotImplementedException();
        }

        public void Añadir(Pila pila)
        {
            array[ultimo] = pila;
        }

        //override bool EstaVacia()
        //{
        //    bool result = true;
        //    foreach (object x in array)
        //    {
        //        if (x != null)
        //        {
        //            result = false;
        //        }
        //    }
        //    return result;
        //}

        //public override object Extraer()
        //{

        //}

        //public override object Primero()
        //{

        //}

        //public override bool Añadir()
        //{

        //}
    }
}
