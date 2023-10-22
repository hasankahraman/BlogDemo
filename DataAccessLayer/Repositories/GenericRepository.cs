using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        Context context = new Context();
        public void Add(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> Get()
        {
            return context.Set<T>().ToList();
        }

		public List<T> Get(Expression<Func<T, bool>> filter)
		{
			return context.Set<T>().Where(filter).ToList();
		}

		public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T t)
        {
            //context.Update(t);
            //context.SaveChanges();

            var entityToUpdate = context.Entry(t);
            entityToUpdate.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
