 
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
    /// 菜单操作的实体
    /// </summary>
    public partial class MenuOperationRelation
    {
         
        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuOperationRelation()
        {
                    }
 
	/// <summary>
	///  主键
	/// </summary>
    	[Required(ErrorMessage="id不能为空")]
		public Int32 id { set; get; }
 
				/// <summary>
	///  操作主键
	/// </summary>
    
	public Int32 ? OperationId { set; get; }
 
				/// <summary>
	///  菜单主键
	/// </summary>
    
	public Int32 ? MenuId { set; get; }
 
			   
		}
}
