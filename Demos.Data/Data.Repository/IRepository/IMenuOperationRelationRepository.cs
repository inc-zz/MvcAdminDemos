
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
	public partial interface IMenuOperationRelationRepository 
	{		

		/// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		MenuOperationRelation GetModel(System.Int32 id);
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		MenuOperationRelation Insert(MenuOperationRelation model);
		/// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		 MenuOperationRelation Update(MenuOperationRelation entity);
		 /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(MenuOperationRelation model);
		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PagedResult<MenuOperationRelation> PagerMenuInfoList(PagingInfo paging, string where);
		/// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool BatchInsert(List<MenuOperationRelation> list);
		/// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool BatchUpdate(List<MenuOperationRelation> list);

	}
}
	
