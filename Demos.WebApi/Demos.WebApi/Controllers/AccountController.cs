
using System;
using Newtonsoft.Json;
using System.Web.Http;
using Core.EnumType;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Demos.WebApi.Controllers
{

    /// <summary>
    /// 用户中心
    /// </summary>
    public partial class AccountController : BaseController
    {


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="memberService"></param>
        public AccountController()
        {
        }

        public JsonResult List() {
            return null;
        }
    }
}
