using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyGamesNew.Models
{
    public class TransactionType
    {
        public short TransactionTypeID { get; set; }
        public string TarnsactionTypeName { get; set; }


        public virtual ICollection<TransactionTable> TransactionTables { get; set; }
    }
}