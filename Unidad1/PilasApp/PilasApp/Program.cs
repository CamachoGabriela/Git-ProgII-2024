using PilasApp.Clases;
using PilasApp.Interfaces;

namespace PilasApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pila1 = new Pila(10);
            var cola1 = new Cola(10);

            //Cola
            Console.WriteLine("----Prueba con Cola FIFO----");

            //Esta vacia antes de añadir
            string estaVaciaCola;
            if (cola1.EstaVacia())
                estaVaciaCola = "Verdadero";
            else
                estaVaciaCola = "Falso";

            Console.WriteLine("La Cola está vacía: " + estaVaciaCola);

            //Añadir elementos
            cola1.Añadir("Elemento 1");
            cola1.Añadir("Elemento 2");
            cola1.Añadir("Elemento 3");
            cola1.Añadir("Elemento 4");

            //Mostrar elementos Cola
            Console.WriteLine("Elementos de la Cola: ");
            cola1.mostrarElementos();

            //Esta vacia despues de añadir
            if (cola1.EstaVacia())
                estaVaciaCola = "Verdadero";
            else
                estaVaciaCola = "Falso";

            Console.WriteLine("La Cola está vacía: " + estaVaciaCola);

            

            //Extraer
            Console.WriteLine("Elemento extraído: " + cola1.Extraer());



            //Pila
            Console.WriteLine("----Prueba con la Pila LIFO----");

            //Esta vacia antes de añadir
            string estaVaciaPila;
            if (pila1.EstaVacia())
                estaVaciaPila = "Verdadero";
            else
                estaVaciaPila = "Falso";

            Console.WriteLine("La Pila está vacía: " + estaVaciaPila);

            pila1.Añadir("Elemento A");
            pila1.Añadir("Elemento B");
            pila1.Añadir("Elemento C");
            pila1.Añadir("Elemento D");

            //Esta vacia despues de añadir
            if (pila1.EstaVacia())
                estaVaciaPila = "Verdadero";
            else
                estaVaciaPila = "Falso";

            Console.WriteLine("La Pila está vacía: " + estaVaciaPila);

            //Mostrar elementos Pila
            Console.WriteLine("Elementos de la Pila: ");
            pila1.mostrarElementos();

            //Extraer
            Console.WriteLine("Elemento extraído: " + pila1.Extraer());

            //ColleccionAbstracta[] array = {pila1, cola1, pila2, cola2};

            //foreach (ColleccionAbstracta c in array) 
            //{
            //    Console.WriteLine(c.Añadir(c));
            //}

            //foreach (ColleccionAbstracta c in array)
            //{
            //    Console.WriteLine(c.EstaVacia());
            //}

            //foreach (ColleccionAbstracta c in array)
            //{
            //    Console.WriteLine(c.Extraer());
            //}

        }
    }
}