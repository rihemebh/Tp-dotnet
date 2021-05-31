using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace a2.Repositories
{
      class Repository<T> : IRepository<T> where T : class
    {
       
             DbSet<T> dbSet;
             ShoppingContext context;

       

           public Repository(ShoppingContext context)
            {
                this.context = context;
                dbSet = context.Set<T>();
            }



            public virtual IEnumerable<T> GetAll()
            {
                return dbSet.ToList();
            }
        public virtual void Remove(int Id)
        {
            T entity = dbSet.Find(Id);
            dbSet.Remove(entity);
        }

        public virtual T GetByID(int Id)
            {
                return dbSet.Find(Id);
            }

            public virtual void Add(T entity)
            {
            Console.WriteLine("adding : " + entity.ToString() + " ...");
                dbSet.Add(entity);
            }
        
            public virtual void Update(T entity)
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }

        }
}
