using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDatabaseContext
{
    public class UserDataAccess : IDataAccess<User>
    {
        public UserDataAccess()
        {
        }
        public void Add(User entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Users.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public void Delete(User entity)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public User Get(int id)
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    User user = context.Users.FirstOrDefault(v => v.UserId == id);
                    return user;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public IEnumerable<User> GetAll()
        {
            try
            {
                using (BankingSystemDBContext context = new BankingSystemDBContext())
                {
                    return context.Users;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void Modify(User entity)
        {
            using (BankingSystemDBContext context = new BankingSystemDBContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void Create()
        {
            using (BankingSystemDBContext context = new BankingSystemDBContext())
            {
                Domain.User ususario = new Domain.User();
                ususario.Name = "Juan pedro";
                ususario.EmailAddress = "juan@pedro.com";
                this.Add(ususario);
            }

        }
    }
}
