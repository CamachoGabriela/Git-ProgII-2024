using BankApp.Data;
using BankApp.Data.Implementations;
using BankApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class Service
    {
        private RepositoryClient rClient;
        private RepositoryAccounts rAccount;

        public Service()
        {
            rClient = new RepositoryClient();
            rAccount = new RepositoryAccounts();
        }

        public List<Client> GetAllClients(List<Parameter>? parameters)
        {
            return rClient.GetAllClients(parameters);
        }

        public List<Account> GetAllAccounts(List<Parameter>? parameters)
        {
            return rAccount.GetAllAccounts(parameters);
        }

        public bool InsertClientAndAccounts(Client c)
        {
            return rClient.InsertClientAndAccounts(c);
        }

        public bool InsertAccount(Account a)
        {
            return rAccount.InsertAccount(a);
        }
    }
}
