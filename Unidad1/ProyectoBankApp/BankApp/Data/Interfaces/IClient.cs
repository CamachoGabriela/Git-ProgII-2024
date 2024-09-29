using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;

namespace BankApp.Data.Interfaces
{
    public interface IClient
    {
        List<Client> GetAllClients(List<Parameter>? parameters);

        bool InsertClientAndAccounts(Client c);
    }
}
