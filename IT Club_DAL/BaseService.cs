using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IT_Club_Model;

namespace IT_Club_DAL
{
    public class BaseService<T> where T : class, new()
    {
        DbContext db = DBContextFactory.CreateDbContext();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
      public IQueryable<T> Query(Expression<Func<T, bool>> whereLambda)
        {
            if (whereLambda != null)
            {
                return db.Set<T>().Where(whereLambda);
            }
            return db.Set<T>();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orederbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> PageQuery<s>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where(whereLambda);
            TotalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip((PageIndex - 1) * PageSize).Take(PageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip((PageIndex - 1) * PageSize).Take(PageSize);
            }
            return temp;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            db.Entry<T>(entity).State =EntityState.Added;
            return true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }
    }
   
}
