using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Club_BLL;
using IT_Club_IBLL;
using Newtonsoft.Json;

namespace IT_Club_UI.Controllers
{
    public class UserInfoController : Controller
    {
        
        // GET: UserInfo
        public IUserInfoManager userinfo = new UserInfoManager();
        public ActionResult Index()
        {
            TempData["id"] = Request["id"];
            return View();
        }
        public ActionResult Data()
        {
            int a = int.Parse(TempData["id"].ToString());
            var user = userinfo.Query(u => u.UserID == a).ToList();
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}