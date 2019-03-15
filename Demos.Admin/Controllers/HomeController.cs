using Core.EnumType;
using Data.Entities.Models;
using Demos.Entities.FilterModel;
using Demos.Entities.ResultModel;
using Member.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demos.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IMemberService _iMemberService;
        public HomeController(IMemberService iMemberService)
        {
            this._iMemberService = iMemberService;
        }

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetModel(int id)
        {
            var model = _iMemberService.GetModel(id);
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 新增/保存实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult SaveModel(MenuInfo model)
        {
            if (ModelState.IsValid)
            {
                var result = new MenuInfo();
                if (model.MenuId > 0)
                {
                    model = _iMemberService.EditModel(model);
                }
                result = _iMemberService.AddModel(model);
                if (result != null)
                {
                    return Json(new Result<MenuInfo> { code = StatusCodeEnum.Success, msg = StatusCodeEnum.Success.GetEnumText(), data = result });
                }
            }
            return Json(new { status = StatusCodeEnum.ParameterError, msg = StatusCodeEnum.ParameterError.GetEnumText() });
        }
        /// <summary>
        /// 批量新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BatchAddModel(List<MenuInfo> list)
        {
            var valid = false;
            foreach (var model in list)
            {
                valid = ModelState.IsValid;
            }
            if (valid)
            {
                var result = _iMemberService.BatchAddModel(list);
                if (result)
                {
                    return Json(new Result<MenuInfo> { code = StatusCodeEnum.Success, msg = StatusCodeEnum.Success.GetEnumText(), data = result });

                }
            }
            return Json(new { status = StatusCodeEnum.ParameterError, msg = StatusCodeEnum.ParameterError.GetEnumText() });
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ActionResult BatchEditModel(List<MenuInfo> list)
        {
            var valid = false;
            foreach (var model in list)
            {
                valid = ModelState.IsValid;
            }
            if (valid)
            {
                var result = _iMemberService.BatchEditModel(list);
                if (result)
                {
                    return Json(new Result<MenuInfo> { code = StatusCodeEnum.Success, msg = StatusCodeEnum.Success.GetEnumText(), data = result });

                }
            }
            return Json(new { status = StatusCodeEnum.ParameterError, msg = StatusCodeEnum.ParameterError.GetEnumText() });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        public ActionResult PageList(PagingInfo paging)
        {
            paging.sqlWhere.AppendFormat("");
            var list = _iMemberService.PagerMenuInfoList(paging);
            return Json(new { code = StatusCodeEnum.Success, data = list.ToList(), count = list.TotalRecords }, JsonRequestBehavior.AllowGet);
        }
    }
}