using Data.Entities.Models;
using Demos.Entities.FilterModel;
using Demos.Entities.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Service
{
    public interface IMemberService
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MenuInfo GetModel(int Id);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MenuInfo AddModel(MenuInfo model);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MenuInfo EditModel(MenuInfo model);
        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        bool BatchAddModel(List<MenuInfo> modelList);
        /// <summary>
        /// 批量修改实体
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        bool BatchEditModel(List<MenuInfo> modelList);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PagedResult<MenuInfo> PagerMenuInfoList(PagingInfo paging);
    }
}
