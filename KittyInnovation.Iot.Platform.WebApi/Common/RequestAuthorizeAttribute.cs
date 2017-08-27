using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace KittyInnovation.Iot.Platform.WebApi.Common
{
    /// <summary>
    /// 自定义此特性用于接口的身份验证
    /// </summary>
    public class RequestAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从Http请求中获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if(authorization!=null 
                && authorization.Parameter!=null)
            {
                //解密Ticket,验证用户名密码
                var encryptTicket = authorization.Parameter;

            }
            else
            {
                //如果获取不到身份验证信息，并且不允许匿名访问，则返回401
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(i => i is AllowAnonymousAttribute);
                if (isAnonymous)
                    base.OnAuthorization(actionContext);
                else
                    HandleUnauthorizedRequest(actionContext);
            }
        }

        /// <summary>
        /// 验证用户名密码
        /// </summary>
        /// <param name="encryptTicket"></param>
        /// <returns></returns>
        private bool ValidateTicket(string encryptTicket)
        {
            //揭秘
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;
            var index = strTicket.IndexOf('&');
            var userName = strTicket.Substring(0, index);
            var password = strTicket.Substring(index + 1);
            if (userName == "hezp@cnsecom.com"
                && password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
