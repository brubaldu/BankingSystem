using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDatabaseContext
{
    public class AccountDataAccess : IDataAccess<Account>
    {
        public AccountDataAccess()
        {
        }
        public void Add(Account entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {                    
                    context.Accounts.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public void Delete(Account entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Accounts.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public Account Get(int id)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    
                    Account account = context.Accounts.FirstOrDefault(v => v.AccountId == id);
                    context.Entry(account).Reference(e => e.AccountUser).Load();
                    context.Entry(account).Reference(e => e.Currency).Load();
                    return account;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public bool Exists(int id)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    return context.Accounts.Any(v => v.AccountId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }


        public IEnumerable<Account> GetAll()
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    return context.Accounts;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void Modify(Account entity)
        {
            using (BankingSystemDBContext context = new BankingSystemDBContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public bool SameOwner(int accountFromId, int accountToId)
        {
            using (BankingSystemDBContext context = new BankingSystemDBContext())
            {
                return Get(accountFromId).AccountUser.UserId == Get(accountToId).AccountUser.UserId;
            }

        }
    }
}
