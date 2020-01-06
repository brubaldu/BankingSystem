using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDatabaseContext
{
    public interface IDataAccess<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Modify(T entity);

        void Delete(T entity);
    }
}
