using IT_Club_IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IT_Club_IBLL
{
    public interface IBaseManager<T> where T:class,new()
    {
        IDBSession CurrentDBSession { get; }
        IBaseService<T> CurrentService { get; set; }
        IQueryable<T> Query(Expression<Func<T,bool>> whereLambda);
        IQueryable<T> PageQuery<s>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);
        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
        bool AddEntity(T entity);
    }
}
