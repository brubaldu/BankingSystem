using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Account
    {
        public int AccountId { get; set; }
        public virtual User AccountUser { get; set; }
        public virtual Currency Currency { get; set; }
        public double Balance { get; set; }
    }
}
