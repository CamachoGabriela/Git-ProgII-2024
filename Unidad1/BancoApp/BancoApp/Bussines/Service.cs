using BancoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoApp.Domain;

namespace BancoApp.Bussines
{
    public class Service
    {
        private RegisterRepository repository = new RegisterRepository();

        public Service()
        {
            
        }

        public int Register(Account a)
        {
            return repository.Register(a);
        }
    }
}
