using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Club_UI.Models
{
    public class MyError : HandleErrorAttribute
    {
        //创建异常处理队列
        //public static Queue<Exception> Exec = new Queue<Exception>();
        public static IRedisClientsManager clientsManager = new PooledRedisClientManager(new string[] { "129.204.227.86:6379" });
        public static IRedisClient redisClient = clientsManager.GetClient();
        /// <summary>
        /// 捕获异常
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            Exception ex = context.Exception;
            //将异常写进队列
            //Exec.Enqueue(ex);
            redisClient.EnqueueItemOnList("errorMsg",ex.ToString());
            context.HttpContext.Server.Transfer("/404.html");
        }
    }
}