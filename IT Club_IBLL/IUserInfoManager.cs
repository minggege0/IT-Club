using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_IBLL
{
    public interface IUserInfoManager : IBaseManager<UserInfo>
    {
        int ExecuteSql(string sqlStr, params SqlParameter[] pars);
        List<UserInfo> ExecuteQuery(string sqlStr, params SqlParameter[] pars);
        IQueryable<UserInfo> LoadPageEntity(string pageindex, string pagesize, string obj, string value, out int Total);
    }
}
