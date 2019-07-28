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
        //�Ƴ�WebForm��ͼ
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
            //��ȡ�������ļ��й���Log4Net��������Ϣ
            log4net.Config.XmlConfigurator.Configure();
            MvcHandler.DisableMvcResponseHeader = true;
            RemoveWebFormEngines();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //����һ���̣߳�ɨ���쳣��Ϣ�Ķ���
            string filepath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    //�ж�һ�¶������Ƿ�������
                   // if (MyError.Exec.Count()>0)
                   if(MyError.redisClient.GetListCount("errorMsg")>0)
                    {
                        //Exception exception=MyError.Exec.Dequeue();
                       string errorMsg= MyError.redisClient.DequeueItemFromList("errorMsg");
                        if (errorMsg != null)
                        {
                            //���쳣д����־�ļ���
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
                        //���������û�����ݣ�����
                        Thread.Sleep(3000);
                    }
                }
            },filepath);
        }
    }
}
