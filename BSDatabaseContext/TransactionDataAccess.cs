using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDatabaseContext
{
    public class TransactionDataAccess : IDataAccess<Transaction>
    {
        public TransactionDataAccess()
        {
        }
        public void Add(Transaction entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Transactions.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public void Delete(Transaction entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Transactions.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public Transaction Get(int id)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    Transaction transaction = context.Transactions.FirstOrDefault(v => v.TransactionId == id);
                    return transaction;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public IEnumerable<Transaction> GetAll()
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    return context.Transactions;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void Modify(Transaction entity)
        {
            using (BankingSystemDBContext context = new BankingSystemDBContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
