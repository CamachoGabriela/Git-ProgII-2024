using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Data
{
    public class RegisterRepository : IRegisterable
    {
        public int Register(Account account)
        {
            DataHelper helper = DataHelper.GetInstance();
            int AffectedRows = helper.CreateAccount(account);
            return AffectedRows;
        }
    }
}
