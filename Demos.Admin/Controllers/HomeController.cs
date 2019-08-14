using Basic.Service;
using Common.Logging;
using Core.EnumType;
using Core.Utility;
using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Service;
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
using TZ.Infrastructure;

namespace Demos.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        //转厂 》申请表表头
        private ITRANSAPPLYHEADINPUTService _ITRANSAPPLYHEADINPUTService;

        public HomeController(
            TZContext context,
            ITRANSAPPLYHEADINPUTService iTRANSAPPLYHEADINPUTService
           )
        {

            this._ITRANSAPPLYHEADINPUTService = iTRANSAPPLYHEADINPUTService;
        }

        public ActionResult Index()
        {

            AddData1();

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


        private void AddData1()
        {
            TRANSAPPLYHEADINPUT objModel = new TRANSAPPLYHEADINPUT();

            objModel.ID = Guid.NewGuid();
            //公司ID
            objModel.CONO = "4b461617-d6e4-40c6-b192-1e3d7c592a91";
            //转入转出类型
            objModel.TRANS_TYPE = 1; //1:转入申请表；2:转出申请表
            //流转申报预录入编号
            objModel.ROTATE_DCL_PREENT_NO = "000000008605555";
            //流转申报编号
            objModel.ROTATE_DCL_NO = "0001";
            //变更次数
            objModel.CHG_TMS_CNT = 0;
            //流转类型代码
            objModel.ROTATE_TYPECD = "A";
            //申报表有效时间
            //objModel.DCL_TB_VALID_TIME = "";
            //转入底账编号 (手册号或账册号)
            objModel.TRFIN_ORIACT_NO = "M0000001";
            //转入企业内部编号
            //转入地关区代码
            //转入地区代码
            //转入企业编号
            //转入企业社会信用代码
            //转入企业名称
            //转出企业海关编码
            //转出企业社会信用代码
            //转出企业名称
            //转入录入企业海关编号
            //转入录入企业统一社会信用代码
            //转入录入企业名称
            //转入申报企业海关编号
            //转入申报企业社会信用代码
            //转入申报企业名称
            //转入企业法人/联系电话
            //转入申报人/联系电话
            objModel.TRFIN_DCL_CONC_NAME = "0755";
            //预计运输耗时
            //送货距离
            //转入录入日期
            objModel.TRFIN_INPUT_TIME = DateTime.Now;
            //转入申报日期
            //转入地企业备注
            //转出地海关
            objModel.TRFOUT_PLC_CUSCD = "5309";
            //转出账册编号
            objModel.TRFOUT_ORIACT_NO = "ZC000001";
            //转出企业内部编号
            //转出地区代码
            //转出录入企业海关编号
            //转出录入企业社会信用代码
            //转出录入企业名称
            //转出录入企业IC卡号
            //转出申报企业代码
            //转出申报企业社会信用代码
            //转出申报企业名称
            //转出企业法人/联系电话
            //转出申报人/联系电话
            objModel.TRFOUT_DCL_CONC_ER_NAME = "0755-01";
            //转出录入日期
            objModel.TRFOUT_INPUT_TIME = DateTime.Now;
            //转出申报日期
            //转出地企业备注
            //申报类型 (1：备案，2：变更)
            objModel.DCL_TYPECD = "1";
            //备注
            //录入人
            objModel.CREATE_CODE = "xxxxxx";
            //录入人名称
            objModel.CREATE_NAME = "Magic";
            //录入日期
            objModel.CREATE_DATE = DateTime.Now;
            //修改人
            //修改人名称
            //修改日期
            //审核人
            //审核人名称
            //审核日期
            //审批状态 (0=数据草稿,内部审核通过时为10)
            objModel.APPR_STATUS = "0";
            //审批日期
            //审批备注

            _ITRANSAPPLYHEADINPUTService.AddTRANSAPPLYHEADINPUT(objModel);

        }
    }
}