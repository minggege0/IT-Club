using IT_Club_BLL;
using IT_Club_IBLL;
using IT_Club_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ExpressionSerialization;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace IT_Club_Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserInfoService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserInfoService.svc 或 UserInfoService.svc.cs，然后开始调试。
    public class UserInfoService : IUserInfoService
    {

        IUserInfoManager UserInfoManager = new UserInfoManager();

        public bool AddEntity(UserInfo User)
        {
            #region 添加
            if (UserInfoManager.AddEntity(User))
            {
                return true;
            }
            return false;
            #endregion
        }

        public bool DeleteEntity(UserInfo User)
        {
            #region 删除
            if (UserInfoManager.DeleteEntity(User))
            {
                return true;
            }
            return false;
            #endregion
        }
        public string Query(string sqlStr, params SqlParameter[] pars)
        {
            #region 查询
            return JsonConvert.SerializeObject(UserInfoManager.ExecuteQuery(sqlStr, pars));
            #endregion
        }
        public string Query(string pageindex, string pagesize, string obj, string value)
        {
            var User = UserInfoManager.LoadPageEntity(pageindex, pagesize, obj, value, out int Total);
            return JsonConvert.SerializeObject(new { total = Total, user = User });
        }

        public bool UpdateEntity(UserInfo User)
        {
            #region 修改
            if (UserInfoManager.UpdateEntity(User))
            {
                return true;
            }
            return false;
            #endregion
        }
    }
}
