using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T: class
    {
        List<T> Get();
        List<T> Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
    }
}
