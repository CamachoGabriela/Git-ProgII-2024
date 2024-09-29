using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Domain
{
    public class Client
    {
        private string name;
        private string surname;
        private int dni;

        public string Name { get { return name;} set { name = value; } }
        public string Surname { get {  return surname; } set { surname = value; } }
        public int Dni { get { return dni; } set { dni = value; } }

        public Client(string name, string surname, int dni)
        {
            this.name = name;
            this.surname = surname;
            this.dni = dni;
        }
        public Client()
        {

        }
    }
}
