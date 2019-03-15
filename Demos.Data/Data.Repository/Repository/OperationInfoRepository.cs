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
	 public partial class OperationInfoRepository : BaseRepository, IOperationInfoRepository
    {

        private SqlSugarClient _db;
        public OperationInfoRepository()
        {
            _db = GetInstance();
        }
		  /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public OperationInfo GetModel(System.Int32 OperationId) {
            return _db.Queryable<OperationInfo>().First(x=>x.OperationId == OperationId);

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">返回最新实体</param>
        /// <returns></returns>
        public OperationInfo Insert(OperationInfo model)
        {
            var _model = _db.Insertable(model).ExecuteReturnEntity();
            return _model;
        }
        /// <summary>
        /// 更新返回最新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public OperationInfo Update(OperationInfo entity)
        {
            var _entity = entity;
            var _num = _db.Updateable(entity).ExecuteCommand();
            if (_num > 0)
                _entity = _db.Queryable<OperationInfo>().Where(x => x.MenuId == entity.MenuId).First();
            return _entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(OperationInfo model)
        {
            var _res = _db.Deleteable<OperationInfo>().Where(x => x.MenuId == model.MenuId).ExecuteCommand();
            return _res > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public PagedResult<OperationInfo> PagerOperationInfoList(PagingInfo paging, string where)
        {
			var result = new PagedResult<OperationInfo>();
            int total = 0;
            result.Data = _db.Queryable<OperationInfo>().OrderBy(x => x.OperationId).ToPageList(paging.PageIndex, paging.PageSize, ref total);
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
        public bool BatchInsert(List<OperationInfo> list)
        {
            var res = _db.Insertable(list.ToArray()).ExecuteCommand();
            return res > 0;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchUpdate(List<OperationInfo> list)
        {
            var res = _db.Updateable(list.ToArray()).ExecuteCommand();
            return res > 0;
        }
    }
}
	
