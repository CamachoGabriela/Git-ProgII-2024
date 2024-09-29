using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Cbu { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastMove { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public int ClientId { get; set; }
    }
}
