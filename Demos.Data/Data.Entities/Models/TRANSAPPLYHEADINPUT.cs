 
/*
*此代码由T4模板自动生成，所有在此基础上的更改将被覆盖，
*请勿在此文件添加自己的代码
*生成时间 2019/05/28 08:34:12
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 
namespace Data.Entities.Models
{
    /// <summary>
    /// 深加工结转申请表表头的实体
    /// </summary>
    public partial class TRANSAPPLYHEADINPUT
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public TRANSAPPLYHEADINPUT()
        {
                        this. CREATE_DATE = DateTime.Now;
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
	///  转入转出类型
	/// </summary>
    	[Required(ErrorMessage="转入转出类型不能为空")]
		public Int32 TRANS_TYPE { set; get; }
 
			 
	/// <summary>
	///  流转申报预录入编号
	/// </summary>
    	public String ROTATE_DCL_PREENT_NO { set; get; }
 
			 
	/// <summary>
	///  流转申报编号
	/// </summary>
    	public String ROTATE_DCL_NO { set; get; }
 
			 
	/// <summary>
	///  变更次数
	/// </summary>
    	[Required(ErrorMessage="变更次数不能为空")]
		public Int32 CHG_TMS_CNT { set; get; }
 
			 
	/// <summary>
	///  流转类型代码
	/// </summary>
    	[Required(ErrorMessage="流转类型代码不能为空")]
		public String ROTATE_TYPECD { set; get; }
 
			 
	/// <summary>
	///  申报表有效时间
	/// </summary>
    
	public DateTime ? DCL_TB_VALID_TIME { set; get; }
 
			 
	/// <summary>
	///  转入底账编号
	/// </summary>
    	public String TRFIN_ORIACT_NO { set; get; }
 
			 
	/// <summary>
	///  转入企业内部编号
	/// </summary>
    	public String TRFIN_ETPS_INNER_NO { set; get; }
 
			 
	/// <summary>
	///  转入地关区代码
	/// </summary>
    	public String TRFIN_PLC_CUSCD { set; get; }
 
			 
	/// <summary>
	///  转入地区代码
	/// </summary>
    	public String TRFIN_DSTCD { set; get; }
 
			 
	/// <summary>
	///  转入企业编号
	/// </summary>
    	public String TRFIN_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  转入企业社会信用代码
	/// </summary>
    	public String TRFIN_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  转入企业名称
	/// </summary>
    	public String TRFIN_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  转入录入企业海关编号
	/// </summary>
    	public String TRFIN_INPUT_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  转入录入企业统一社会信用代码
	/// </summary>
    	public String TRFIN_INPUT_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  转入录入企业名称
	/// </summary>
    	public String TRFIN_INPUT_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  转入申报企业海关编号
	/// </summary>
    	public String TRFIN_DCL_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  转入申报企业社会信用代码
	/// </summary>
    	public String TRFIN_DCL_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  转入申报企业名称
	/// </summary>
    	public String TRFIN_DCL_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  转入企业法人/联系电话
	/// </summary>
    	public String TRFIN_ETPS_CONC_NAME { set; get; }
 
			 
	/// <summary>
	///  转入申报人/联系电话
	/// </summary>
    	public String TRFIN_DCL_CONC_NAME { set; get; }
 
			 
	/// <summary>
	///  转出企业海关编码
	/// </summary>
    	public String TRFOUT_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  转出企业社会信用代码
	/// </summary>
    	public String TRFOUT_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  转出企业名称
	/// </summary>
    	public String TRFOUT_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  预计运输耗时
	/// </summary>
    
	public Decimal ? PREDCT_TRSP_USEUP_DESC { set; get; }
 
			 
	/// <summary>
	///  送货距离
	/// </summary>
    
	public Decimal ? DLVGDS_DIST_DESC { set; get; }
 
			 
	/// <summary>
	///  转入录入日期
	/// </summary>
    
	public DateTime ? TRFIN_INPUT_TIME { set; get; }
 
			 
	/// <summary>
	///  转入申报日期
	/// </summary>
    
	public DateTime ? TRFIN_DCL_TIME { set; get; }
 
			 
	/// <summary>
	///  转入地企业备注
	/// </summary>
    	public String TRFIN_PLC_ETPS_RMK { set; get; }
 
			 
	/// <summary>
	///  转出地海关
	/// </summary>
    	public String TRFOUT_PLC_CUSCD { set; get; }
 
			 
	/// <summary>
	///  转出账册编号
	/// </summary>
    	public String TRFOUT_ORIACT_NO { set; get; }
 
			 
	/// <summary>
	///  转出企业内部编号
	/// </summary>
    	public String TRFOUT_ETPS_INNER_NO { set; get; }
 
			 
	/// <summary>
	///  转出地区代码
	/// </summary>
    	public String TRFOUT_DSTCD { set; get; }
 
			 
	/// <summary>
	///  转出录入企业海关编号
	/// </summary>
    	public String TRFOUT_INPUT_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  转出录入企业社会信用代码
	/// </summary>
    	public String TRFOUT_INPUT_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  转出录入企业名称
	/// </summary>
    	public String TRFOUT_INPUT_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  转出录入企业IC卡号
	/// </summary>
    	public String TRFOUT_DCL_IC_CARDNO { set; get; }
 
			 
	/// <summary>
	///  转出申报企业代码
	/// </summary>
    	public String TRFOUT_DCL_ETPSNO { set; get; }
 
			 
	/// <summary>
	///  转出申报企业社会信用代码
	/// </summary>
    	public String TRFOUT_DCL_ETPS_SCCD { set; get; }
 
			 
	/// <summary>
	///  转出申报企业名称
	/// </summary>
    	public String TRFOUT_DCL_ETPS_NM { set; get; }
 
			 
	/// <summary>
	///  转出企业法人/联系电话
	/// </summary>
    	public String TRFOUT_ETPS_CONC_ER_NAME { set; get; }
 
			 
	/// <summary>
	///  转出申报人/联系电话
	/// </summary>
    	public String TRFOUT_DCL_CONC_ER_NAME { set; get; }
 
			 
	/// <summary>
	///  转出录入日期
	/// </summary>
    
	public DateTime ? TRFOUT_INPUT_TIME { set; get; }
 
			 
	/// <summary>
	///  转出申报日期
	/// </summary>
    
	public DateTime ? TRFOUT_DCL_TIME { set; get; }
 
			 
	/// <summary>
	///  转出地企业备注
	/// </summary>
    	public String TRFOUT_PLC_ETPS_RMK { set; get; }
 
			 
	/// <summary>
	///  申报类型
	/// </summary>
    	public String DCL_TYPECD { set; get; }
 
			 
	/// <summary>
	///  备注
	/// </summary>
    	public String RMK { set; get; }
 
			 
	/// <summary>
	///  录入人
	/// </summary>
    	[Required(ErrorMessage="录入人不能为空")]
		public String CREATE_CODE { set; get; }
 
			 
	/// <summary>
	///  录入人名称
	/// </summary>
    	[Required(ErrorMessage="录入人名称不能为空")]
		public String CREATE_NAME { set; get; }
 
			 
	/// <summary>
	///  录入日期
	/// </summary>
    	[Required(ErrorMessage="录入日期不能为空")]
		public DateTime CREATE_DATE { set; get; }
 
			 
	/// <summary>
	///  修改人
	/// </summary>
    	public String MODIFY_CODE { set; get; }
 
			 
	/// <summary>
	///  修改人名称
	/// </summary>
    	public String MODIFY_NAME { set; get; }
 
			 
	/// <summary>
	///  修改日期
	/// </summary>
    
	public DateTime ? MODIFY_DATE { set; get; }
 
			 
	/// <summary>
	///  审核人
	/// </summary>
    	public String CHECK_CODE { set; get; }
 
			 
	/// <summary>
	///  审核人名称
	/// </summary>
    	public String CHECK_NAME { set; get; }
 
			 
	/// <summary>
	///  审核日期
	/// </summary>
    
	public DateTime ? CHECK_DATE { set; get; }
 
			 
	/// <summary>
	///  审批状态
	/// </summary>
    	[Required(ErrorMessage="审批状态不能为空")]
		public String APPR_STATUS { set; get; }
 
			 
	/// <summary>
	///  审批日期
	/// </summary>
    
	public DateTime ? APPR_DATE { set; get; }
 
			 
	/// <summary>
	///  审批备注
	/// </summary>
    	public String APPR_NOTE { set; get; }
 
			 
	/// <summary>
	///  数据记录状态：0=软删除，1=正常，2=停用
	/// </summary>
    	[Required(ErrorMessage="数据记录状态：0=软删除，1=正常，2=停用不能为空")]
		public Int32 ROW_STATUS { set; get; }
 
			 
	/// <summary>
	///  转入状态
	/// </summary>
    	public String TRFIN_STATUS { set; get; }
 
			 
	/// <summary>
	///  转出状态
	/// </summary>
    	public String TRFOUT_STATUS { set; get; }
 
			 
	/// <summary>
	///  数据来源:1=企业端；2=平台；
	/// </summary>
    	public String DATA_SOURCE { set; get; }
 
			 
	/// <summary>
	///  录入人公司ID
	/// </summary>
    	public String CREATE_ETPSID { set; get; }
 
			 
	/// <summary>
	///  
	/// </summary>
    	public String SUPPCODE { set; get; }
 
			   
		}
}
