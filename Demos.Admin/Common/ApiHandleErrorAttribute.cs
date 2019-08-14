using Common.Logging;
using Newtonsoft.Json;
using System.Web.Http.Filters;

namespace Demos.Admin.Common
{
    /// <summary>
    /// api全局异常捕获
    /// </summary>
    public class ApiHandleErrorAttribute : ExceptionFilterAttribute
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            base.OnException(filterContext);

            //异常信息
            ErrorMessage msg = new ErrorMessage(filterContext.Exception, "接口");
            msg.ActionArguments = JsonConvert.SerializeObject(filterContext.ActionContext.ActionArguments, Formatting.Indented);
            msg.ShowException = false;

            string ErrMsg = JsonConvert.SerializeObject(msg, Formatting.Indented);
            Log.Error("全局异常日志：" + ErrMsg);

        }
    }
}