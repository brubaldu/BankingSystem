using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        [ForeignKey("AccountFrom")]
        public int AccountFromId { get; set; }
        public virtual Account AccountFrom { get; set; }
        [ForeignKey("AccountTo")]
        public int AccountToId { get; set; }
        public virtual Account AccountTo { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }


    }
}
