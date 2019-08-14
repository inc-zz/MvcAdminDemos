
using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using Data.Entities.Models;

namespace Data.Entities.Service
{

    /// <summary>
    /// 公用代码分类编号表服务接口
    /// </summary>
    public partial interface IPubCodesService
    {
		#region IPubCodesService Members
       
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

		#endregion

    }
}
