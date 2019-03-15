
//------------------------------------------------------------------------------
// 警告:
//     该代码由T4工具根据模板自动生成,直接在该代码上进行任何修改都将在重新生成后丢失!
//     如有需要应使用partial class或是继承该类进行自定义扩展。
//------------------------------------------------------------------------------
using System;
using Data.Entities.Models;
using SqlSugar;
using Webdiyer.WebControls.Mvc;
using System.Collections.Generic;
using Demos.Entities.ResultModel;
using Demos.Entities.FilterModel;	

namespace Data.Repository.Repository
{   
	public partial interface IRoleInfoRepository 
	{		

		/// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		RoleInfo GetModel(System.Int32 Id);
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		RoleInfo Insert(RoleInfo model);
		/// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		 RoleInfo Update(RoleInfo entity);
		 /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(RoleInfo model);
		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PagedResult<RoleInfo> PagerMenuInfoList(PagingInfo paging, string where);
		/// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool BatchInsert(List<RoleInfo> list);
		/// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool BatchUpdate(List<RoleInfo> list);

	}
}
	
