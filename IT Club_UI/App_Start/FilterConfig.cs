using IT_Club_UI.Models;
using System.Web;
using System.Web.Mvc;

namespace IT_Club_UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyError());
        }
    }
}
