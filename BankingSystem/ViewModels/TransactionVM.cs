using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.ViewModels
{
    public partial class TransactionVM
    {
        public int TransactionId { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
