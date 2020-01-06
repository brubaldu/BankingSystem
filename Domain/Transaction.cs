﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public virtual Account AccountFrom { get; set; }
        public virtual Account AccountTo { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

    }
}
