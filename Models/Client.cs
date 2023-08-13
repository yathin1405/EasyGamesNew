using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyGamesNew.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal ClientBalance { get; set; }


        public virtual ICollection<TransactionTable> TransactionTables { get; set; }
    }
}