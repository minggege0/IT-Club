using IT_Club_BLL;
using IT_Club_IBLL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Club_UI.UserInfoServiceReference;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net.Http;
using Newtonsoft.Json;
namespace IT_Club_UI.Controllers
{
    public class HomeController : Controller
    {
        #region 注释
        //public IUserInfoManager UserInfoManager { get; set; }
        //var query = db.Article.Join(db.category, a => a.ClassId, c => c.CategoryId, (a, c) => new { a,c })
        //       .Join(db.UserInfo, ac=>ac.a.UserId, u => u.UserId, (ac,u) => new {Title=ac.a.Title,CateName=ac.c.CateName,UserName=u.UserName });
        #endregion
        UserInfoServiceClient serviceClient = new UserInfoServiceClient();
        public ActionResult Index()
        {
            return View();
        }
        public int TestError()
        {
            JJTEntities jjt = new JJTEntities();
            jjt.UserInfo.Where(x=>x.UserName=="王明株");
            int a = 2;
            int b = 0;
            return a / b;
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public string Query()
        {
            if (Request["pars[inputvalue]"] == null)
                return serviceClient.Query(Request["pars[pageindex]"], Request["pars[pagesize]"], null, null);
            else
                return serviceClient.Query(Request["pars[pageindex]"], Request["pars[pagesize]"], Request["pars[selectvalue]"], Request["pars[inputvalue]"]);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteEntity()
        {
            return serviceClient.DeleteEntity(new UserInfo() { UserID = Convert.ToInt32(Request["UserID"]) });
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        public bool UpdateEntity()
        {
            #region 修改数据
            UserInfo User = new UserInfo()
            {
                UserID = int.Parse(Request["user[id]"]),
                UserName = Request["user[name]"],
                UserPwd = Request["user[pwd]"],
                QQ = Request["user[qq]"],
                Phone = Request["user[phone]"],
                Address = Request["user[address]"],
                CreateTime = DateTime.Parse(Request["user[createtime]"]),
                UserStatus = Request["user[userstatus]"]
            };
            return serviceClient.UpdateEntity(User);
            #endregion
        }
        public bool AddEntity()
        {
            #region 添加
            UserInfo user = new UserInfo()
            {
                UserName = Request["userinfo[name]"],
                UserPwd = Request["userinfo[pwd]"],
                QQ = Request["userinfo[qq]"],
                Phone = Request["userinfo[phone]"],
                Address = Request["userinfo[address]"],
                CreateTime = DateTime.Now,
                UserStatus = "0"
            };
            return serviceClient.AddEntity(user);
            #endregion
        }
        /// <summary>
        /// WebAPIDemo 测试
        /// </summary>
        /// <returns></returns>
        public string test()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("https://localhost:44375/api/values").Result;
            var list = response.Content.ReadAsStringAsync().Result;
            return list;
        }
    }
}