using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;

namespace BankApp.Data.Interfaces
{
    public interface IAccount
    {
        List<Account> GetAllAccounts(List<Parameter>? parameters);
    }
}
