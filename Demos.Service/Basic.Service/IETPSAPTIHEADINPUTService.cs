
using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using Data.Entities.Models;

namespace Data.Entities.Service
{

    /// <summary>
    /// 企业资质申请表头表服务接口
    /// </summary>
    public partial interface IETPSAPTIHEADINPUTService
    {
		#region IETPSAPTIHEADINPUTService Members
       
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
        ETPSAPTIHEADINPUT GetETPSAPTIHEADINPUT(Guid ID);

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        ModelResult<ETPSAPTIHEADINPUT> SaveETPSAPTIHEADINPUT(ETPSAPTIHEADINPUT model);

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        ModelResult<ETPSAPTIHEADINPUT> AddETPSAPTIHEADINPUT(ETPSAPTIHEADINPUT model);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="addList"></param>
        /// <returns></returns>
        bool BatchAddETPSAPTIHEADINPUT(List<ETPSAPTIHEADINPUT> addList);

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool RemoveETPSAPTIHEADINPUT(ETPSAPTIHEADINPUT model);
        
         /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool RemoveETPSAPTIHEADINPUT(PagingInfo pagingInfo);

        /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="IDList">字符串列表</param>
        /// <returns></returns>
        bool RemoveETPSAPTIHEADINPUTList(string IDList);
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        IPageOfItems<ETPSAPTIHEADINPUT> GetETPSAPTIHEADINPUTs();

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        IPageOfItems<ETPSAPTIHEADINPUT> GetETPSAPTIHEADINPUTsList(PagingInfo pagingInfo);

		#endregion

    }
}
