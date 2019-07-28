using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_Common
{
    public class MemcacheHelper
    {
        private static readonly MemcachedClient MClient = null;
        static MemcacheHelper()
        {
            //参数
            string[] MemcacheServiceList = { "123.207.66.129:11211" };

            //设置连接池
            SockIOPool SPool = SockIOPool.GetInstance();
            SPool.SetServers(MemcacheServiceList);
            SPool.InitConnections = 3;
            SPool.MinConnections = 3;
            SPool.MaxConnections = 50;
            SPool.SocketConnectTimeout = 1000;
            SPool.SocketTimeout = 3000;
            SPool.MaintenanceSleep = 30;
            SPool.Failover = true;
            SPool.Nagle = false;
            SPool.Initialize();

            MClient = new MemcachedClient();
            MClient.EnableCompression = false;
        }
        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Set(string key, object value)
        {
            return MClient.Set(key, value);
        }
        //最长过期时间30天
        public static bool Set(string key, object value, DateTime time)
        {
            return MClient.Set(key, value, time);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return MClient.Get(key);
        }
        public static bool Delete(string key)
        {
            if (MClient.KeyExists(key))
            {
                return MClient.Delete(key);
            }
            return false;
        }
    }
}
