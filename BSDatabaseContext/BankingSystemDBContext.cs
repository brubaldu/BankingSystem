using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;
using MySql.Data.EntityFramework;

namespace BSDatabaseContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BankingSystemDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public BankingSystemDBContext() : base("name=BankingDB")
        {
            
        }
    }
}
