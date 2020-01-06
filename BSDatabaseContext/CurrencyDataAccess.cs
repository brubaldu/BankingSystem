using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDatabaseContext
{
    public class CurrencyDataAccess : IDataAccess<Currency>
    {
        public CurrencyDataAccess()
        {
        }
        public void Add(Currency entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Currencies.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public void Delete(Currency entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Currencies.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public Currency Get(int id)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    Currency currency = context.Currencies.FirstOrDefault(v => v.CurrencyId == id);
                    return currency;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public Currency GetByCode(string code)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    Currency currency = context.Currencies.FirstOrDefault(v => v.Code == code);
                    return currency;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<Currency> GetAll()
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    return context.Currencies;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void Modify(Currency entity)
        {
            using (BankingSystemDBContext context = new BankingSystemDBContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
