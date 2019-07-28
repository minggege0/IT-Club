using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_IDAL
{
    public interface IDBSession
    {
        DbContext db { get; }

        IUserInfoService UserInfoService { get; set; }
        bool SaveChanges();
    }
}
