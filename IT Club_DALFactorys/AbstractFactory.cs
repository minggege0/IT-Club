using IT_Club_IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_DALFactorys
{
    /// <summary>
    /// 通过反射创建类的实例
    /// </summary>
   public class AbstractFactory
    {
        private static readonly string Assemblypath = ConfigurationManager.AppSettings["Assemblypath"];
        private static readonly string Namespace = ConfigurationManager.AppSettings["Namespace"];
        public static IUserInfoService CreateUserInfoService() {
            string fullClassName = Namespace + ".UserInfoService";
            return CreateInstance(fullClassName) as IUserInfoService;
        }
        //public static IUserInfoDal CreateUserInfoDal()
        //{
        //    string fullClassName = NameSpace + ".UserInfoDal";
        //   return CreateInstance(fullClassName) as IUserInfoDal;
        //}
        private static object CreateInstance(string fullClassName)
        {
            var assembly = Assembly.Load(Assemblypath);
            return assembly.CreateInstance(fullClassName);
        }
    }
}
