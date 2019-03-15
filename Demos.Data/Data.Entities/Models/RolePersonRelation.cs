 
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
    /// 角色人员的实体
    /// </summary>
    public partial class RolePersonRelation
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public RolePersonRelation()
        {
                    }
 
	/// <summary>
	///  id
	/// </summary>
    	[Required(ErrorMessage="id不能为空")]
		public Int32 id { set; get; }
 
				/// <summary>
	///  人员表主键
	/// </summary>
    
	public Int32 ? PersonId { set; get; }
 
				/// <summary>
	///  角色_角色主键
	/// </summary>
    
	public Int32 ? Rol_Id { set; get; }
 
			   
		}
}
