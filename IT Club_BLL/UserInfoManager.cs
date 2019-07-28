using IT_Club_IBLL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_BLL
{
    public class UserInfoManager : BaseManager<UserInfo>, IUserInfoManager
    {
        public override void SetCurrentService()
        {
            CurrentService = this.CurrentDBSession.UserInfoService;
        }
    }
}
