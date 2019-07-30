using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IT_Club_Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserInfoService”。
    [ServiceContract]
    public interface IUserInfoService
    {
        [OperationContract(Name = "ExecuteQuery")]
        string Query(string sqlStr,params SqlParameter[]pars);
        [OperationContract(Name ="Query")]
        string Query(string pageindex,string pagesize,string obj,string value);
        [OperationContract]
        bool DeleteEntity(UserInfo User);
        [OperationContract]
        bool UpdateEntity(UserInfo User);
        [OperationContract]
        bool AddEntity(UserInfo User);
    }
}
