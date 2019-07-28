using IT_Club_IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_DALFactorys
{
   public class DBSessionFactory
    {
        public static IDBSession CreateDBSession() {
            IDBSession dBSession = (IDBSession)CallContext.GetData("dbsession");
            if (dBSession==null)
            {
                dBSession = new DBSession();
                CallContext.SetData("dbsession",dBSession);
            }
            return dBSession;
        }
    }
}
