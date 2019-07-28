using IT_Club_DAL;
using IT_Club_IDAL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return DBContextFactory.CreateDbContext();
            }
        }

        private IUserInfoService _userInfoService;
        public IUserInfoService UserInfoService
        {
            get
            {
                if (_userInfoService == null)
                {
                    _userInfoService = AbstractFactory.CreateUserInfoService();
                }
                return _userInfoService;
            }
            set
            {
                _userInfoService = value;
            }
        }
        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }

    }
    //public  class DBSessions : IDBSession
    //{
    //    // OAEntities Db = new OAEntities();
    //    public DbContext db
    //    {
    //        get
    //        {
    //            return DBContextFactory.CreateDbContext();
    //        }
    //    }
    //    private IUserInfoService _userInfoService;
    //    public IUserInfoService UserInfoService
    //    {
    //        get
    //        {
    //            if (_userInfoService == null)
    //            {
    //                //_UserInfoDal = new UserInfoDal();
    //                _userInfoService = AbstractFactory.CreateUserInfoService();//通过抽象工厂封装了类的实例的创建
    //            }
    //            return _userInfoService;
    //        }
    //        set
    //        {
    //            _userInfoService = value;
    //        }
    //    }
    //    /// <summary>
    //    /// 一个业务中经常涉及到对多张操作，我们希望链接一次数据库，完成对张表数据的操作。提高性能。 工作单元模式。
    //    /// </summary>
    //    /// <returns></returns>
    //    public bool SaveChanges()
    //    {
    //        return db.SaveChanges() > 0;
    //    }
    //    //public int ExecuteSql(string sql, params SqlParameter[] pars)
    //    //{
    //    //    return Db.Database.ExecuteSqlCommand(sql, pars);
    //    //}
    //    //public List<T> ExecuteQuery<T>(string sql, params SqlParameter[] pars)
    //    //{
    //    //    return Db.Database.SqlQuery<T>(sql, pars).ToList();
    //    //}

    //}
}
