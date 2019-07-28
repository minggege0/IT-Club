using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_IBLL
{
    public interface IUserInfoManager:IBaseManager<UserInfo>
    {
        //IQueryable SelectUserNameByUserID(int UserID);
    }
}
