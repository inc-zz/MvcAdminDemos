 
/*
*此代码由T4模板自动生成，所有在此基础上的更改将被覆盖，
*请勿在此文件添加自己的代码
*生成时间 2019/05/27 11:00:15
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 
namespace Data.Entities.Models
{
    /// <summary>
    /// 企业资质申请表头的实体
    /// </summary>
    public partial class ETPSAPTIHEADINPUT
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public ETPSAPTIHEADINPUT()
        {
                        this. INPUT_DATE = DateTime.Now;
                    }
 
 
	/// <summary>
	///  ID
	/// </summary>
    	[Required(ErrorMessage="ID不能为空")]
		public Guid ID { set; get; }
 
			 
	/// <summary>
	///  公司资料唯一编码
	/// </summary>
    	[Required(ErrorMessage="公司资料唯一编码不能为空")]
		public String CONO { set; get; }
 
			 
	/// <summary>
	///  预录入统一编号
	/// </summary>
    	public String SEQ_NO { set; get; }
 
			 
	/// <summary>
	///  联网企业档案库编号
	/// </summary>
    	public String ET_ARCRP_NO { set; get; }
 
			 
	/// <summary>
	///  变更次数
	/// </summary>
    	[Required(ErrorMessage="变更次数不能为空")]
		public Int32 CHG_TMS_CNT { set; get; }
 
			 
	/// <summary>
	///  资质类型
	/// </summary>
    	[Required(ErrorMessage="资质类型不能为空")]
		public String EMSTYPE { set; get; }
 
			 
	/// <summary>
	///  企业内部编号
	/// </summary>
    	[Required(ErrorMessage="企业内部编号不能为空")]
		public String ETPS_PREENT_NO { set; get; }
 
			 
	/// <summary>
	///  主管关区代码
	/// </summary>
    	[Required(ErrorMessage="主管关区代码不能为空")]
		public String MASTER_CUSCD { set; get; }
 
			 
	/// <summary>
	///  经营企业社会信用代码
	/// </summary>
    	public String BIZOP_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  经营企业编号
	/// </summary>
    	[Required(ErrorMessage="经营企业编号不能为空")]
		public String BIZOP_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  经营企业名称
	/// </summary>
    	[Required(ErrorMessage="经营企业名称不能为空")]
		public String BIZOP_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  加工企业社会信用代码
	/// </summary>
    	public String PRCS_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  加工企业编号
	/// </summary>
    	[Required(ErrorMessage="加工企业编号不能为空")]
		public String PRCS_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  加工企业名称
	/// </summary>
    	[Required(ErrorMessage="加工企业名称不能为空")]
		public String PRCS_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  申报企业社会信用代码
	/// </summary>
    	public String DCL_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  申报企业编号
	/// </summary>
    	[Required(ErrorMessage="申报企业编号不能为空")]
		public String DCL_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  申报企业名称
	/// </summary>
    	[Required(ErrorMessage="申报企业名称不能为空")]
		public String DCL_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  申报企业类型代码
	/// </summary>
    	public String DCL_ETPS_TYPECD { set; get; }
 
			 
	/// <summary>
	///  联系地址
	/// </summary>
    	public String CONC_ADDR { set; get; }
 
			 
	/// <summary>
	///  电话号码
	/// </summary>
    	public String TELNUM { set; get; }
 
			 
	/// <summary>
	///  结束有效时间
	/// </summary>
    
	public DateTime ? FINISH_VALID_TIME { set; get; }
 
			 
	/// <summary>
	///  加工生产能力金额
	/// </summary>
    	[Required(ErrorMessage="加工生产能力金额不能为空")]
		public Decimal PRCS_PRDC_ABLT_AMT { set; get; }
 
			 
	/// <summary>
	///  批准证编号
	/// </summary>
    	public String APCRET_NO { set; get; }
 
			 
	/// <summary>
	///  风险担保标记代码
	/// </summary>
    	public String RISK_ASSURE_MARKCD { set; get; }
 
			 
	/// <summary>
	///  关联单证编号
	/// </summary>
    	public String RLT_FORM_NO { set; get; }
 
			 
	/// <summary>
	///  申报来源标记代码
	/// </summary>
    	[Required(ErrorMessage="申报来源标记代码不能为空")]
		public String DCL_SOURCE_MARKCD { set; get; }
 
			 
	/// <summary>
	///  申报类型代码
	/// </summary>
    	[Required(ErrorMessage="申报类型代码不能为空")]
		public String DCL_TYPECD { set; get; }
 
			 
	/// <summary>
	///  申报时间
	/// </summary>
    
	public DateTime ? DCL_TIME { set; get; }
 
			 
	/// <summary>
	///  备注
	/// </summary>
    	public String RMK { set; get; }
 
			 
	/// <summary>
	///  审批状态代码
	/// </summary>
    	[Required(ErrorMessage="审批状态代码不能为空")]
		public String EMAPV_STUCD { set; get; }
 
			 
	/// <summary>
	///  执行标记代码
	/// </summary>
    	public String EXE_MARKCD { set; get; }
 
			 
	/// <summary>
	///  备案批准时间
	/// </summary>
    
	public DateTime ? PUTREC_APPR_TIME { set; get; }
 
			 
	/// <summary>
	///  变更批准时间
	/// </summary>
    
	public DateTime ? CHG_APPR_TIME { set; get; }
 
			 
	/// <summary>
	///  审批备注
	/// </summary>
    	public String APPR_NOTE { set; get; }
 
			 
	/// <summary>
	///  录入单位代码
	/// </summary>
    	public String INPUT_CODE { set; get; }
 
			 
	/// <summary>
	///  录入单位社会信用代码
	/// </summary>
    	public String INPUT_CREDIT_CODE { set; get; }
 
			 
	/// <summary>
	///  录入单位名称
	/// </summary>
    	public String INPUT_NAME { set; get; }
 
			 
	/// <summary>
	///  入库时间
	/// </summary>
    
	public DateTime ? ADD_TIME { set; get; }
 
			 
	/// <summary>
	///  录入日期
	/// </summary>
    	[Required(ErrorMessage="录入日期不能为空")]
		public DateTime INPUT_DATE { set; get; }
 
			 
	/// <summary>
	///  录入人
	/// </summary>
    	[Required(ErrorMessage="录入人不能为空")]
		public String CREATE_CODE { set; get; }
 
			 
	/// <summary>
	///  修改人
	/// </summary>
    	public String MODIFY_CODE { set; get; }
 
			 
	/// <summary>
	///  修改日期
	/// </summary>
    
	public DateTime ? MODIFY_DATE { set; get; }
 
			 
	/// <summary>
	///  审核人
	/// </summary>
    	public String CHECK_CODE { set; get; }
 
			 
	/// <summary>
	///  审核日期
	/// </summary>
    
	public DateTime ? CHECK_DATE { set; get; }
 
			 
	/// <summary>
	///  创建人名称
	/// </summary>
    	public String CREATE_NAME { set; get; }
 
			 
	/// <summary>
	///  修改人名称
	/// </summary>
    	public String MODIFY_NAME { set; get; }
 
			 
	/// <summary>
	///  审核人名称
	/// </summary>
    	public String CHECK_NAME { set; get; }
 
			 
	/// <summary>
	///  海关审批日期
	/// </summary>
    
	public DateTime ? APPR_DATE { set; get; }
 
			 
	/// <summary>
	///  数据来源:1=企业端；2=平台；
	/// </summary>
    	public String DATA_SOURCE { set; get; }
 
			   
		}
}
