using Data.Entities.Models;
using Data.Repository.Repository;
using Demos.Entities.FilterModel;
using Demos.Entities.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Service
{
    public class MemberService : IMemberService
    {

        private IMenuInfoRepository _menuInfoRepository;
        public MemberService(IMenuInfoRepository menuInfoRepository)
        {
            _menuInfoRepository = menuInfoRepository;

        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuInfo GetModel(int id)
        {
            return _menuInfoRepository.GetModel(id);
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MenuInfo AddModel(MenuInfo model)
        {
            return _menuInfoRepository.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MenuInfo EditModel(MenuInfo model)
        {
            return _menuInfoRepository.Update(model);
        }
        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool BatchAddModel(List<MenuInfo> modelList)
        {
            return _menuInfoRepository.BatchInsert(modelList);
        }
        /// <summary>
        /// 批量修改实体
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool BatchEditModel(List<MenuInfo> modelList)
        {
            return _menuInfoRepository.BatchUpdate(modelList);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PagedResult<MenuInfo> PagerMenuInfoList(PagingInfo paging) {
            return _menuInfoRepository.PagerMenuInfoList(paging);
        }
    }

}
