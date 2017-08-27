using KittyInnovation.Iot.Platform.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace KittyInnovation.Iot.Platform.WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [AllowAnonymous]
        public Models.User Login(string userName, string password)
        {
            if (!ValidateUser(userName, password))
            {
                return new Models.User { Sucess = false };
            }
            //获取票据
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, userName, DateTime.Now,
                DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", userName, password), FormsAuthentication.FormsCookiePath);
            //加密票据
            var resu = FormsAuthentication.Encrypt(ticket);
            var user = new Models.User { UserName = userName, Password = password, Sucess = true, Ticket = resu };
            HttpContext.Current.Session[userName] = user;
            return user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateUser(string userName, string password)
        {
            return true;
        }
        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
