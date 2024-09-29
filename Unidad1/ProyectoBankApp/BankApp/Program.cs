using System.Runtime.CompilerServices;
using BankApp.Services;

namespace BankApp
{
    public class Program
    {
        static void Main()
        {
            Service oService = new Service();

            Console.WriteLine("Seleccione la opción que desea ejecutar\n1.Ingresar un cliente con sus respectivas cuentas\n" +
                              "2.Insertar una cuenta a un cliente existente\n" +
                              "3.Listar todos los clientes\n" +
                              "4.Listar todas las cuentas");
            
            int respuesta = Convert.ToInt32(Console.ReadLine());

            
            while(respuesta > 4 && respuesta < 1)
            {
                Console.WriteLine("Ingreso un valor inválido, por favor ingreselo de nuevo\n" +
                                  "Seleccione la opción que desea ejecutar\n1.Ingresar un cliente con sus respectivas cuentas\n" +
                                  "2.Insertar una cuenta a un cliente existente\n" +
                                  "3.Listar todos los clientes\n" +
                                  "4.Listar todas las cuentas");
            }
            
            
        }
    }
}
