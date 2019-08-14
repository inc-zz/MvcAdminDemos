using Common.Logging;
using Core.EnumType;
using Data.Entities;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Demos.Admin.Common
{

    /// <summary>
    /// 授权验证
    /// </summary>
    public class CustAuthorizeAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 重写基类的验证方式，加入我们自定义的Ticket验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var token = actionContext.Request.Headers.GetValues("token").FirstOrDefault();
            var authorization = actionContext.Request.Headers.Authorization;

            if (token != null)
            {
                var encryptTicket = token;
                if (ValidateToken(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                base.IsAuthorized(actionContext);

                //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        /// <summary>
        /// 重写返回类
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            var response = filterContext.Response = filterContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            ResultObject result = new ResultObject();
            
            result.StatusCode = StatusCodeEnum.Unauthorized;
            result.Message = "服务端拒绝访问：你没有权限";
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
        
        }

        /// <summary>
        /// 解密token 根据StaffId 获取缓存服务器用户数据，判断用户名密码是否匹配
        /// </summary>
        /// <param name="encryptToken"></param>
        /// <returns></returns>
        private bool ValidateToken(string encryptToken)
        {
            if (!string.IsNullOrEmpty(encryptToken))
            {
                try
                {
                    //string _tokenKey = ConfigurationManager.AppSettings["EncryptDesToekn"];
                    //string tokenStr = NetCryptoHelper.AesDecrypt(encryptToken, _tokenKey);
                    //TokenDto token = JsonConvert.DeserializeObject<TokenDto>(tokenStr);
                    //if (token != null)
                    //{
                    //    //得到token 
 
                    //}
                }
                catch (Exception e)
                {
                    Log.Info("Token解析出错：" + e.Message);
                    return false;
                }
            }
            return false;
        }


    }
}