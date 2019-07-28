using IT_Club_Model;
using System;
using System.Collections.Generic;
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
        [OperationContract]
        //Expression<Func<UserInfo, bool>> whereLambda
        string Query(string name);
        [OperationContract]
        string PageQuery<s>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, s>> orderbyLambda, bool isAsc);
        [OperationContract]
        bool DeleteEntity(UserInfo User);
        [OperationContract]
        bool UpdateEntity(UserInfo User);
        [OperationContract]
        bool AddEntity(UserInfo User);
    }
}
