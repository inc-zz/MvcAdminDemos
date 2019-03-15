 
/*
*此代码由T4模板自动生成，所有在此基础上的更改将被覆盖，
*请勿在此文件添加自己的代码
*生成时间 2019/03/09 21:36:47
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 
namespace Data.Entities.Models
{
    /// <summary>
    /// 操作的实体
    /// </summary>
    public partial class OperationInfo
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationInfo()
        {
                        this. CreatedOn = DateTime.Now;
                    }
 
	/// <summary>
	///  操作主键
	/// </summary>
    	[Required(ErrorMessage="OperationId不能为空")]
		public Int32 OperationId { set; get; }
 
				/// <summary>
	///  名称
	/// </summary>
    	[Required(ErrorMessage="Name不能为空")]
		public String Name { set; get; }
 
				/// <summary>
	///  控制器名称
	/// </summary>
    	[Required(ErrorMessage="ControllerName不能为空")]
		public String ControllerName { set; get; }
 
				/// <summary>
	///  方法名称
	/// </summary>
    	[Required(ErrorMessage="ActionName不能为空")]
		public String ActionName { set; get; }
 
				/// <summary>
	///  
	/// </summary>
    	public String Attributes { set; get; }
 
				/// <summary>
	///  
	/// </summary>
    	public String Icon { set; get; }
 
				/// <summary>
	///  备注
	/// </summary>
    	public String Remark { set; get; }
 
				/// <summary>
	///  状态
 ///   0:禁用
 ///   1:启用
	/// </summary>
    	[Required(ErrorMessage="Status不能为空")]
		public Boolean Status { set; get; }
 
				/// <summary>
	///  创建时间
	/// </summary>
    	[Required(ErrorMessage="CreatedOn不能为空")]
		public DateTime CreatedOn { set; get; }
 
				/// <summary>
	///  创建人
	/// </summary>
    	public String CreatedBy { set; get; }
 
			   
		}
}
