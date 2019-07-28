using IT_Club_BLL;
using IT_Club_IBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Linq.Expressions;
using Spring.Web.Services;
using IT_Club_Model;
using ExpressionSerialization;

namespace IT_Club_Service
{
    /// <summary>
    /// UserInfoService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class UserInfoService : System.Web.Services.WebService
    {


        IUserInfoManager UserInfoManager = new UserInfoManager();
        [WebMethod]
        public string Query(Expression<Func<UserInfo, bool>> wherelamda)
        {

            return JsonConvert.SerializeObject(UserInfoManager.Query(wherelamda));
        }
    }
}
