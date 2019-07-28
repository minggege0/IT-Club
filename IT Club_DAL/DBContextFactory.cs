using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_DAL
{
   public class DBContextFactory
    {
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new JJTEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
