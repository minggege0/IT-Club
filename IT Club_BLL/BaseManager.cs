using IT_Club_DALFactorys;
using IT_Club_IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_BLL
{
    public abstract class BaseManager<T> where T : class, new()
    {
        public IDBSession CurrentDBSession
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }
        public IBaseService<T> CurrentService { get; set; }
        public abstract void SetCurrentService();
        public BaseManager()
        {
            SetCurrentService();
        }
        public IQueryable<T> Query(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentService.Query(whereLambda);
        }
        public IQueryable<T> PageQuery<s>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentService.PageQuery<s>(PageIndex, PageSize, out TotalCount, whereLambda, orderbyLambda, isAsc);
        }
        public bool DeleteEntity(T entity)
        {
            CurrentService.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        public bool UpdateEntity(T entity)
        {
            CurrentService.UpdateEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        public bool AddEntity(T entity)
        {
            CurrentService.AddEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
    }
}
