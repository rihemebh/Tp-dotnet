using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2.Repositories
{
    public interface IRepository<T> where T : class
    {
       
        void Remove(int id);
        void Update(T entity);
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
    }
}
