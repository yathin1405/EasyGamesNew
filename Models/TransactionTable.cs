using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyGamesNew.Models
{
    public class TransactionTable
    {
        public long TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public decimal Updated { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<short> TransactionTypeID { get; set; }

        public virtual Client Client { get; set; }
        public virtual TransactionType TransactionType { get; set; }

        public decimal BalanceUpdate(TransactionTable transactionTable)
        {
            EasyGamesNewString db = new EasyGamesNewString();
            Client client = db.Clients.FirstOrDefault(i => i.ClientID == transactionTable.ClientID);


            if (transactionTable.TransactionTypeID == 2)
            {
                client.ClientBalance = client.ClientBalance + transactionTable.Amount;
                db.SaveChanges();
                return client.ClientBalance;
            }
            else
            {
                client.ClientBalance = client.ClientBalance - transactionTable.Amount;
                db.SaveChanges();
                return client.ClientBalance;
            }
        }

    }
}