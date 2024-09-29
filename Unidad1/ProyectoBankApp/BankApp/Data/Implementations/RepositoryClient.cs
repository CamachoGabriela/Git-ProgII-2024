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
    public class RepositoryClient : IClient
    {
        public List<Client> GetAllClients(List<Parameter>? parameters)
        {
            
            DataTable dt = DataHelper.GetHelper().ExecuteSPQuery("OBTENER_CLIENTES", parameters);

            List<Client> clients = new List<Client>();
            if (dt != null)
            {
                
                foreach (DataRow row in dt.Rows)
                {
                    Client c = new Client();

                    c.Id = Convert.ToInt32(row[0]);
                    c.Name = Convert.ToString(row[1]);
                    c.Surname = Convert.ToString(row[2]);
                    c.Dni = Convert.ToInt32(dt.Columns[3]);

                    clients.Add(c);
                }
            }
            else
            {
                clients = null;
            }

            return clients;
            
        }

        public bool InsertClientAndAccounts(Client c)
        {
            bool inserted = false;

            int rows = DataHelper.GetHelper().InsertClientAndAccounts(c);

            if (rows > 0)
            {
                inserted = true;
            }

            return inserted;
        }
    }
}
