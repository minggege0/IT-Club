using IT_Club_DAL;
using IT_Club_IDAL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_DALFactorys
{
    public class DBSession : IDBSession
    {
        public DbContext db
        {
            get
            {
                //保证数据会话层实例为线程唯一
                return DBContextFactory.CreateDbContext();
            }
        }

        private IUserInfoService _userInfoService;
        private IProductService _productService;
        public IUserInfoService UserInfoService
        {
            get
            {
                if (_userInfoService == null)
                {
                    //通过反射创建类的实例
                    _userInfoService = AbstractFactory.CreateUserInfoService();
                }
                return _userInfoService;
            }
            set
            {
                _userInfoService = value;
            }
        }
        public IProductService ProductService {
            get {
                if (_productService == null)
                {
                    _productService = AbstractFactory.CreateProductService();
                }
                return _productService;
            }
            set {
                _productService = value;
            }
        }
        /// <summary>
        ///  一个业务中经常涉及到对多张操作，我们希望链接一次数据库，完成对张表数据的操作。提高性能。 工作单元模式。
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
        public int ExecuteSql(string sqlStr, params SqlParameter[] pars)
        {
            return db.Database.ExecuteSqlCommand(sqlStr, pars);
        }
        public List<T> ExecuteQuery<T>(string sqlStr, params SqlParameter[] pars)
        {
            return db.Database.SqlQuery<T>(sqlStr, pars).ToList();
        }

    }

}
