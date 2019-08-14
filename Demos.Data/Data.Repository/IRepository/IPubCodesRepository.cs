
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
	public partial interface IPubCodesRepository 
	{		

		  /// <summary>
        /// 判断是否存在改记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool IsExists(Guid PID);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="PID">主键</param>
        /// <returns></returns>
        PubCodes GetPubCodes(Guid PID);

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        ModelResult<PubCodes> SavePubCodes(PubCodes model);

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        ModelResult<PubCodes> AddPubCodes(PubCodes model);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="addList"></param>
        /// <returns></returns>
        bool BatchAddPubCodes(List<PubCodes> addList);

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool RemovePubCodes(PubCodes model);
        
         /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool RemovePubCodes(PagingInfo pagingInfo);

        /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="PIDList">字符串列表</param>
        /// <returns></returns>
        bool RemovePubCodesList(string PIDList);
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        IPageOfItems<PubCodes> GetPubCodess();

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        IPageOfItems<PubCodes> GetPubCodessList(PagingInfo pagingInfo);

	}
}
	
