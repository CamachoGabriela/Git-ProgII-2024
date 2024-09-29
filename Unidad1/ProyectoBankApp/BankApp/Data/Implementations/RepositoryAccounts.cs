using BankApp.Data.Interfaces;
using BankApp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Implementations
{
    public class RepositoryAccounts : IAccount
    {
        public List<Account> GetAllAccounts(List<Parameter>? parameters)
        {
            List<Account> accounts = new List<Account>();

            DataTable dt = DataHelper.GetHelper().ExecuteSPQuery("OBTENER_CLIENTES", parameters);

            if(dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Account a = new Account();
                    a.Id = Convert.ToInt32(row[0]);
                    a.Cbu = Convert.ToString(row[1]);
                    a.Balance = Convert.ToDecimal(row[2]);
                    a.TypeAccount.Id = Convert.ToInt32(row[3]);
                    a.LastMove = Convert.ToDateTime(row[4]);
                    a.ClientId = Convert.ToInt32(row[5]);

                    accounts.Add(a);
                }
            }
            else
            {
                accounts = null;
            }

            return accounts;
        }

        public bool InsertAccount(Account a)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@CBU", a.Cbu),
                new Parameter("@SALDO", a.Balance),
                new Parameter("@TIPO_CUENTA_ID", a.TypeAccount.Id),
                new Parameter("@ULTIMO_MOVIMIENTO", a.LastMove),
                new Parameter("@CLIENTE_ID", a.ClientId)
            };

            int rows = DataHelper.GetHelper().SimpleInsert("CREAR_CUENTA", parameters);

            bool inserted = false;

            if(rows > 0)
            {
                inserted = true;
            }
            return inserted;
        }
    }
}
