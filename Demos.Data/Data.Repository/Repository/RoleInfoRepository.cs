//------------------------------------------------------------------------------
// 警告:
//     该代码由T4工具根据模板自动生成,直接在该代码上进行任何修改都将在重新生成后丢失!
//     如有需要应使用partial class或是继承该类进行自定义扩展。
//------------------------------------------------------------------------------
using System;
using Data.Entities.Models;
using SqlSugar;
using System.Collections.Generic;
using Demos.Entities.ResultModel;
using Demos.Entities.FilterModel;

namespace Data.Repository.Repository
{   
	 public partial class RoleInfoRepository : BaseRepository, IRoleInfoRepository
    {

        private SqlSugarClient _db;
        public RoleInfoRepository()
        {
            _db = GetInstance();
        }
		  /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public RoleInfo GetModel(System.Int32 Id) {
            return _db.Queryable<RoleInfo>().First(x=>x.Id == Id);

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">返回最新实体</param>
        /// <returns></returns>
        public RoleInfo Insert(RoleInfo model)
        {
            var _model = _db.Insertable(model).ExecuteReturnEntity();
            return _model;
        }
        /// <summary>
        /// 更新返回最新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public RoleInfo Update(RoleInfo entity)
        {
            var _entity = entity;
            var _num = _db.Updateable(entity).ExecuteCommand();
            if (_num > 0)
                _entity = _db.Queryable<RoleInfo>().Where(x => x.MenuId == entity.MenuId).First();
            return _entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(RoleInfo model)
        {
            var _res = _db.Deleteable<RoleInfo>().Where(x => x.MenuId == model.MenuId).ExecuteCommand();
            return _res > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public PagedResult<RoleInfo> PagerRoleInfoList(PagingInfo paging, string where)
        {
			var result = new PagedResult<RoleInfo>();
            int total = 0;
            result.Data = _db.Queryable<RoleInfo>().OrderBy(x => x.Id).ToPageList(paging.PageIndex, paging.PageSize, ref total);
            result.PageIndex = paging.PageIndex;
            result.PageSize = paging.PageSize;
            result.TotalPages = total;
            return result;

        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsert(List<RoleInfo> list)
        {
            var res = _db.Insertable(list.ToArray()).ExecuteCommand();
            return res > 0;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchUpdate(List<RoleInfo> list)
        {
            var res = _db.Updateable(list.ToArray()).ExecuteCommand();
            return res > 0;
        }
    }
}
	
