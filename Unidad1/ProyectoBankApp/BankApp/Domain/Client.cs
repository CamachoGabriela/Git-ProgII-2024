using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Account> Accounts { get; set;}

    
        public Client()
        {

        }

        public Client(Account a)
        {
            Accounts.Add(a);
        }

        public void AddAccount(Account a)
        {
            Accounts.Add(a);
        }
    }
}
