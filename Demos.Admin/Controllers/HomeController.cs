using Basic.Service;
using Common.Logging;
using Core.EnumType;
using Core.Utility;
using Data.Entities;
using Data.Entities.Models;
using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Demos.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return Content("OK");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Update()
        {
            return View();
        }
         
        public ActionResult NoAuthority()
        {
            return Json(new Result { result = false, msg = "您没有该操作权限" }, JsonRequestBehavior.AllowGet);
        }

    }
}