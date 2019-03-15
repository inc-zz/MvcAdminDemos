 
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
    /// 后台人员的实体
    /// </summary>
    public partial class PersonInfo
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonInfo()
        {
                        this. CreatedOn = DateTime.Now;
                        this. UpdatedOn = DateTime.Now;
                    }
 
	/// <summary>
	///  人员表主键
	/// </summary>
    	[Required(ErrorMessage="PersonId不能为空")]
		public Int32 PersonId { set; get; }
 
				/// <summary>
	///  职位Id
	/// </summary>
    	[Required(ErrorMessage="PositionId不能为空")]
		public Int32 PositionId { set; get; }
 
				/// <summary>
	///  部门表主键
	/// </summary>
    
	public Int64 ? DepartmentId { set; get; }
 
				/// <summary>
	///  帐号
	/// </summary>
    	[Required(ErrorMessage="Account不能为空")]
		public String Account { set; get; }
 
				/// <summary>
	///  昵称
	/// </summary>
    	public String nickname { set; get; }
 
				/// <summary>
	///  姓名
	/// </summary>
    	public String Name { set; get; }
 
				/// <summary>
	///  密码
	/// </summary>
    	[Required(ErrorMessage="Password不能为空")]
		public String Password { set; get; }
 
				/// <summary>
	///  性别
 ///   0：女
 ///   1：男
	/// </summary>
    
	public Boolean ? Sex { set; get; }
 
				/// <summary>
	///  手机号码
	/// </summary>
    	public String MobilePhoneNumber { set; get; }
 
				/// <summary>
	///  办公电话
	/// </summary>
    	public String PhoneNumber { set; get; }
 
				/// <summary>
	///  联系地址
	/// </summary>
    	public String Address { set; get; }
 
				/// <summary>
	///  邮箱
	/// </summary>
    	public String EmailAddress { set; get; }
 
				/// <summary>
	///  备注
	/// </summary>
    	public String Remark { set; get; }
 
				/// <summary>
	///  状态
 ///   100:禁用
 ///   200:启用
	/// </summary>
    
	public Int16 ? Status { set; get; }
 
				/// <summary>
	///  是否删除
 ///   0:否
 ///   1:是
	/// </summary>
    	[Required(ErrorMessage="IsRemove不能为空")]
		public Boolean IsRemove { set; get; }
 
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
