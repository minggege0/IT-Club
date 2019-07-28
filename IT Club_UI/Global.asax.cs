using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IT_Club_UI.Models;
using log4net;
using Spring.Web.Mvc;

namespace IT_Club_UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //移除WebForm视图
        void RemoveWebFormEngines() {
            var viewEngines = ViewEngines.Engines;
            var webFormEngines = viewEngines.OfType<WebFormViewEngine>().FirstOrDefault();
            if (webFormEngines!=null)
            {
                viewEngines.Remove(webFormEngines);
            }
        }
        protected void Application_Start()
        {
            //读取了配置文件中关于Log4Net的配置信息
            log4net.Config.XmlConfigurator.Configure();
            MvcHandler.DisableMvcResponseHeader = true;
            RemoveWebFormEngines();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //开启一个线程，扫描异常信息的队列
            string filepath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    //判断一下队列中是否有数据
                   // if (MyError.Exec.Count()>0)
                   if(MyError.redisClient.GetListCount("errorMsg")>0)
                    {
                        //Exception exception=MyError.Exec.Dequeue();
                       string errorMsg= MyError.redisClient.DequeueItemFromList("errorMsg");
                        if (errorMsg != null)
                        {
                            //将异常写入日志文件中
                            //string filename = DateTime.Now.ToString("yyyy-MM-dd");
                            //File.AppendAllText(filepath + filename + ".txt", exception.ToString(), Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(errorMsg);
                        }
                        else
                        {
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        //如果队列中没有数据，休眠
                        Thread.Sleep(3000);
                    }
                }
            },filepath);
        }
    }
}
