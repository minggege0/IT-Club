using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Club_Model;
using IT_Club_UI.Models;
using Newtonsoft.Json;

namespace IT_Club_UI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public string Search()
        {
            return JsonConvert.SerializeObject(LuceneSearchHelper.GetInstance().Search(Request["inputvalue"]));
        }
        public ActionResult CreateIndex()
        {
            SearchContent content = new SearchContent()
            {
                id = 1,
                productname = "广东龙眼",
                productdesc = "精选金标一级，每10粒泰国龙眼，约只有2粒入选金标一级龙眼"
            };
            LuceneSearchHelper.GetInstance().AddQueue(content);
            return Content("ok");
        }
    }
}