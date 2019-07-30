using IT_Club_IBLL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_BLL
{
    public class UserInfoManager : BaseManager<UserInfo>, IUserInfoManager
    {
        public override void SetCurrentService()
        {
            CurrentService = this.CurrentDBSession.UserInfoService;
        }
        public int ExecuteSql(string sqlStr, params SqlParameter[] pars)
        {
            return CurrentDBSession.ExecuteSql(sqlStr);
        }
        public IQueryable<UserInfo> LoadPageEntity(string pageindex, string pagesize, string obj, string value, out int Total)
        {
            IQueryable<UserInfo> User;
            if (value == null)
                User = PageQuery<int>(int.Parse(pageindex), int.Parse(pagesize), out Total, null, x => x.UserID, true);
            else
            {
                switch (obj)
                {
                    case "1":
                        User = PageQuery<int>(int.Parse(pageindex), int.Parse(pagesize), out Total, x => x.UserName == value, x => x.UserID, true);
                        break;
                    case "2":
                        User = PageQuery<int>(int.Parse(pageindex), int.Parse(pagesize), out Total, x => x.QQ == value, x => x.UserID, true);
                        break;
                    case "3":
                        User = PageQuery<int>(int.Parse(pageindex), int.Parse(pagesize), out Total, x => x.Phone == value, x => x.UserID, true);
                        break;
                    case "4":
                        User = PageQuery<int>(int.Parse(pageindex), int.Parse(pagesize), out Total, x => x.Address == value, x => x.UserID, true);
                        break;
                    default:
                        User = PageQuery<int>(int.Parse(pageindex), int.Parse(pagesize), out Total, null, x => x.UserID, true);
                        break;
                }

            }
            return User;
        }
        public List<UserInfo> ExecuteQuery(string sqlStr, params SqlParameter[] pars)
        {
            return CurrentDBSession.ExecuteQuery<UserInfo>(sqlStr);
        }
    }
}
