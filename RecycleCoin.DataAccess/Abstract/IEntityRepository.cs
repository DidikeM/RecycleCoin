using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using RecycleCoin.Entities.Abstract;

namespace RecycleCoin.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null!);
        T Get(Expression<Func<T, bool>> filter);
        int GetCount(Expression<Func<T, bool>> filter = null!);
        int SumInt(Expression<Func<T, int>> column, Expression<Func<T, bool>> filter = null!);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
