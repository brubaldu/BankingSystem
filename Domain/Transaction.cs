using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Transaction
    {
        public int TransactionId { get; set; }
        public virtual Account AccountFrom { get; set; }
        public virtual Account AccountTo { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
    }
}
