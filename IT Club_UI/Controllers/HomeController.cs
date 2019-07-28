using IT_Club_BLL;
using IT_Club_IBLL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Club_UI.UserInfoServiceReference;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
            return serviceClient.Query(null);
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
        //public string Search()
        //{

        //    switch (Request["selectvalue"])
        //    {
        //        case "1":
        //            serviceClient.Query(y=>y);
        //            break;
        //        case "2":
        //            break;
        //        case "3":
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}