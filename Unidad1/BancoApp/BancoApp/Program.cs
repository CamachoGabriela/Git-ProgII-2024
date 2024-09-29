using BancoApp.Bussines;
using BancoApp.Domain;
using Microsoft.Identity.Client;
using System.Reflection.Emit;

namespace BancoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Service oService = new Service();



            Console.WriteLine("Seleccione la acción a realizar\n1.Ingresar una cuenta\n2.Salir");
            int respuesta = Convert.ToInt32(Console.ReadLine());

            while (respuesta != 1 && respuesta != 2)
            {
                Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor");
                respuesta = Convert.ToInt32(Console.ReadLine());
            }

            while (respuesta == 1)
            {
                Client c = new Client();

                Console.WriteLine("Ingrese el dni del cliente");
                int dni = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el nombre del cliente");
                string name = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido del cliente");
                string surname = Console.ReadLine();

                c.Dni = dni;
                c.Name = name;
                c.Surname = surname;

                Account acc = new Account();

                acc.Client = c;

                Console.WriteLine("Ingrese el cbu que tendrá la cuenta");
                string cbu = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Ingrese el saldo que tendrá la cuenta");
                float balance = float.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el tipo de cuenta");
                string typeAccount = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Ingrese el último movimiento de la cuenta");
                float lastMove = float.Parse(Console.ReadLine());

                acc.Cbu = cbu;
                acc.Balance = balance;
                acc.TypeAccount = typeAccount;
                acc.LastMove = lastMove;

                int affectedRows = oService.Register(acc);

                if (affectedRows > 0)
                {
                    Console.WriteLine("Se ha agregado una cuenta");
                }
                else
                {
                    Console.WriteLine("Error al agregar la cuenta");
                }

                Console.WriteLine("Seleccione la acción a realizar\n1.Ingresar una cuenta\n2.Salir");
                respuesta = Convert.ToInt32(Console.ReadLine());

                while (respuesta != 1 && respuesta != 2)
                {
                    Console.WriteLine("Ingreso un valor inválido, ingreselo otra vez, por favor");
                    respuesta = Convert.ToInt32(Console.ReadLine());
                }
            }

            //Crear primera cuenta

            //Console.WriteLine("¿Desea crear una cuenta?\n1.Sí\n2.No");
            //int respuesta;
            //respuesta = Convert.ToInt32(Console.ReadLine());
            //while (respuesta != 1 && respuesta != 2)
            //{
            //    Console.WriteLine("Ingreso un valor inválido, ingreselo otra vez, por favor");
            //    respuesta = Convert.ToInt32(Console.ReadLine());
            //}

            //if(respuesta == 1)
            //{
            //    Client c = new Client();

            //    Console.WriteLine("Ingrese el dni del cliente");
            //    int dni = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Ingrese el nombre del cliente");
            //    string name = Console.ReadLine();

            //    Console.WriteLine("Ingrese el apellido del cliente");
            //    string surname = Console.ReadLine();

            //    c.Dni = dni;
            //    c.Name = name;
            //    c.Surname = surname;

            //    Account acc = new Account();

            //    acc.Client = c;

            //    Console.WriteLine("Ingrese el cbu que tendrá la cuenta");
            //    string cbu = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine("Ingrese el saldo que tendrá la cuenta");
            //    float balance = float.Parse(Console.ReadLine());

            //    Console.WriteLine("Ingrese el tipo de cuenta");
            //    string typeAccount = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine("Ingrese el último movimiento de la cuenta");
            //    float lastMove = float.Parse(Console.ReadLine());

            //    acc.Cbu = cbu;
            //    acc.Balance = balance;
            //    acc.TypeAccount = typeAccount;
            //    acc.LastMove = lastMove;

            //    int affectedRows = oService.Register(acc);

            //    if (affectedRows > 0)
            //    {
            //        Console.WriteLine("Se ha agregado una cuenta");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error al agregar la cuenta");
            //    }
            //}

            ////Crear segunda cuenta

            //Console.WriteLine("¿Desea crear otra cuenta?\n1.Sí\n2.No");
            
            //respuesta = Convert.ToInt32(Console.ReadLine());
            //while (respuesta != 1 && respuesta != 2)
            //{
            //    Console.WriteLine("Ingreso un valor inválido, ingreselo otra vez, por favor");
            //    respuesta = Convert.ToInt32(Console.ReadLine());
            //}

            //if (respuesta == 1)
            //{
            //    Client c = new Client();

            //    Console.WriteLine("Ingrese el dni del cliente");
            //    int dni = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Ingrese el nombre del cliente");
            //    string name = Console.ReadLine();

            //    Console.WriteLine("Ingrese el apellido del cliente");
            //    string surname = Console.ReadLine();

            //    c.Dni = dni;
            //    c.Name = name;
            //    c.Surname = surname;

            //    Account acc = new Account();

            //    acc.Client = c;

                

            //    Console.WriteLine("Ingrese el cbu que tendrá la cuenta");
            //    string cbu = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine("Ingrese el saldo que tendrá la cuenta");
            //    float balance = float.Parse(Console.ReadLine());

            //    Console.WriteLine("Ingrese el tipo de cuenta");
            //    string typeAccount = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine("Ingrese el último movimiento de la cuenta");
            //    float lastMove = float.Parse(Console.ReadLine());

            //    acc.Cbu = cbu;
            //    acc.Balance = balance;
            //    acc.TypeAccount = typeAccount;
            //    acc.LastMove = lastMove;

            //    int affectedRows = oService.Register(acc);

            //    if (affectedRows > 0)
            //    {
            //        Console.WriteLine("Se ha agregado una cuenta");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error al agregar la cuenta");
            //    }
            //}
            

        }
    }
}
