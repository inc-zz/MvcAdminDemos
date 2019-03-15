 
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
    /// 角色的实体
    /// </summary>
    public partial class RoleInfo
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleInfo()
        {
                        this. CreatedOn = DateTime.Now;
                        this. UpdatedOn = DateTime.Now;
                    }
 
	/// <summary>
	///  角色主键
	/// </summary>
    	[Required(ErrorMessage="Id不能为空")]
		public Int32 Id { set; get; }
 
				/// <summary>
	///  应用表主键
	/// </summary>
    
	public Int32 ? ApplicationId { set; get; }
 
				/// <summary>
	///  分组类型:
 ///   1.管理员
 ///   2.公司
 ///   3.运营中心
 ///   4.渠道商
	/// </summary>
    	[Required(ErrorMessage="GroupType不能为空")]
		public Int32 GroupType { set; get; }
 
				/// <summary>
	///  角色类型
 ///   1.管理员
 ///   2.客服
 ///   3.财务
	/// </summary>
    	[Required(ErrorMessage="RoleType不能为空")]
		public Int16 RoleType { set; get; }
 
				/// <summary>
	///  名称
	/// </summary>
    	[Required(ErrorMessage="Name不能为空")]
		public String Name { set; get; }
 
				/// <summary>
	///  状态
 ///   0:禁用
 ///   1:启用
	/// </summary>
    	[Required(ErrorMessage="Status不能为空")]
		public Boolean Status { set; get; }
 
				/// <summary>
	///  描述
	/// </summary>
    	public String Description { set; get; }
 
				/// <summary>
	///  创建时间
	/// </summary>
    	[Required(ErrorMessage="CreatedOn不能为空")]
		public DateTime CreatedOn { set; get; }
 
				/// <summary>
	///  创建人
	/// </summary>
    	public String CreatedBy { set; get; }
 
				/// <summary>
	///  编辑时间
	/// </summary>
    	[Required(ErrorMessage="UpdatedOn不能为空")]
		public DateTime UpdatedOn { set; get; }
 
				/// <summary>
	///  编辑人
	/// </summary>
    	public String UpdatedBy { set; get; }
 
			   
		}
}
