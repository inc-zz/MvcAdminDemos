 
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
    /// 菜单的实体
    /// </summary>
    public partial class MenuInfo
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuInfo()
        {
                        this. CreatedOn = DateTime.Now;
                        this. UpdatedOn = DateTime.Now;
                    }
 
	/// <summary>
	///  菜单主键
	/// </summary>
    	[Required(ErrorMessage="MenuId不能为空")]
		public Int32 MenuId { set; get; }
 
				/// <summary>
	///  父级菜单
	/// </summary>
    	[Required(ErrorMessage="ParentMenuId不能为空")]
		public Int32 ParentMenuId { set; get; }
 
				/// <summary>
	///  名称
	/// </summary>
    	[Required(ErrorMessage="Name不能为空")]
		public String Name { set; get; }
 
				/// <summary>
	///  网址
	/// </summary>
    	[Required(ErrorMessage="Url不能为空")]
		public String Url { set; get; }
 
				/// <summary>
	///  图标
	/// </summary>
    	public String Iconic { set; get; }
 
				/// <summary>
	///  排序
	/// </summary>
    
	public Int32 ? Sort { set; get; }
 
				/// <summary>
	///  状态
 ///   0:禁用
 ///   1:启用
	/// </summary>
    	[Required(ErrorMessage="Status不能为空")]
		public Boolean Status { set; get; }
 
				/// <summary>
	///  备注
	/// </summary>
    	public String Remark { set; get; }
 
				/// <summary>
	///  创建人
	/// </summary>
    	public String CreatedBy { set; get; }
 
				/// <summary>
	///  创建时间
	/// </summary>
    	[Required(ErrorMessage="CreatedOn不能为空")]
		public DateTime CreatedOn { set; get; }
 
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
