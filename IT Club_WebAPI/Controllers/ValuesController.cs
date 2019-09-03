using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IT_Club_BLL;
using IT_Club_IBLL;
using IT_Club_Model;
using Newtonsoft.Json;
namespace IT_Club_WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IUserInfoManager userInfoManager = new UserInfoManager();
        // GET api/values
        public IEnumerable<UserInfo>Get()
        {
            return userInfoManager.Query(null);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
