using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Domain
{
    public class Account
    {
        private string cbu;
        private Client client;
        private string typeAccount;
        private float balance;
        private float lastMove;

        public string Cbu { get; set; }
        public Client Client { get; set; }
        public string TypeAccount { get; set; }
        public float Balance { get; set; }
        public float LastMove { get; set; }
    }
}
