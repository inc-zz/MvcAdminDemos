
//------------------------------------------------------------------------------
// 警告:
//     该代码由T4工具根据模板自动生成,直接在该代码上进行任何修改都将在重新生成后丢失!
//     如有需要应使用partial class或是继承该类进行自定义扩展。
//------------------------------------------------------------------------------
using System;
using Data.Entities.Models;
using SqlSugar; 
using System.Collections.Generic; 
using Data.Entities;

namespace Data.Repository.Repository
{   
	public partial interface ITRANSAPPLYHEADINPUTRepository 
	{		

		  /// <summary>
        /// 判断是否存在改记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool IsExists(Guid ID);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        TRANSAPPLYHEADINPUT GetTRANSAPPLYHEADINPUT(Guid ID);

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        ModelResult<TRANSAPPLYHEADINPUT> SaveTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model);

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        ModelResult<TRANSAPPLYHEADINPUT> AddTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="addList"></param>
        /// <returns></returns>
        bool BatchAddTRANSAPPLYHEADINPUT(List<TRANSAPPLYHEADINPUT> addList);

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool RemoveTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model);
        
         /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool RemoveTRANSAPPLYHEADINPUT(PagingInfo pagingInfo);

        /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="IDList">字符串列表</param>
        /// <returns></returns>
        bool RemoveTRANSAPPLYHEADINPUTList(string IDList);
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        IPageOfItems<TRANSAPPLYHEADINPUT> GetTRANSAPPLYHEADINPUTs();

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        IPageOfItems<TRANSAPPLYHEADINPUT> GetTRANSAPPLYHEADINPUTsList(PagingInfo pagingInfo);

	}
}
	
