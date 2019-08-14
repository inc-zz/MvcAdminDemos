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
using System.Linq;

namespace Data.Repository.Repository
{   
	 public partial class TRANSAPPLYHEADINPUTRepository : BaseRepository, ITRANSAPPLYHEADINPUTRepository
    {

        private SqlSugarClient _db;
        public TRANSAPPLYHEADINPUTRepository()
        {
            _db = GetInstance();
        }
 
        /// <summary>
        /// 判断是否存在改记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool IsExists(System.Guid ID)
        {
            return _db.Queryable<TRANSAPPLYHEADINPUT>().Where(x => x.ID == ID) != null;

        }

		/// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        public TRANSAPPLYHEADINPUT GetTRANSAPPLYHEADINPUT(System.Guid ID)
        {
            return _db.Queryable<TRANSAPPLYHEADINPUT>().First(x => x.ID == ID);
        }

          /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public ModelResult<TRANSAPPLYHEADINPUT> SaveTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model)
        {
            var result = new ModelResult<TRANSAPPLYHEADINPUT>();
            var r = _db.Updateable<TRANSAPPLYHEADINPUT>().Where(x => x.ID == model.ID).ExecuteCommand();
            if (r > 0)
            {
                var resModel = _db.Queryable<TRANSAPPLYHEADINPUT>().InSingle(model.ID);
                result.Item = resModel;
            }
            return result;
        }

       /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public ModelResult<TRANSAPPLYHEADINPUT> AddTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model)
        {
            var result = new ModelResult<TRANSAPPLYHEADINPUT>();
            var r = _db.Insertable(model).ExecuteCommand();
            if (r > 0)
            {
                var resModel = _db.Queryable<TRANSAPPLYHEADINPUT>().InSingle(model.ID);
                result.Item = resModel;
            }
            return result;
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="addList"></param>
        /// <returns></returns>
        public bool BatchAddTRANSAPPLYHEADINPUT(List<TRANSAPPLYHEADINPUT> addList)
        {
            var res = _db.Insertable(addList.ToArray()).ExecuteCommand();
            return res > 0;
        }

         /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool RemoveTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model)
        {
            var res = _db.Deleteable<TRANSAPPLYHEADINPUT>().Where(x => x.ID == model.ID).ExecuteCommand();
            return res > 0;
        }

       /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool RemoveTRANSAPPLYHEADINPUT(PagingInfo pagingInfo)
        {
            var res = _db.Ado.ExecuteCommand("DELETE FROM TRANS_APPLY_HEAD_INPUT WHERE 1=1 @DelWhere", new
            {
                DelWhere = pagingInfo.SqlWhere.ToString()
            });
            return res > 0;
        }

		  /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="IDList">字符串列表</param>
        /// <returns></returns>
        public bool RemoveTRANSAPPLYHEADINPUTList(string IDList)
        {
            if (string.IsNullOrWhiteSpace(IDList))
                return false;
            var newIds = IDList.Split(',');
            var res = _db.Ado.ExecuteCommand("DELETE FROM TRANS_APPLY_HEAD_INPUT WHERE ID IN @DELWhere", new
            {
                DelWhere = newIds.ToArray()
            });
            return res > 0;
        }

		/// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        public IPageOfItems<TRANSAPPLYHEADINPUT> GetTRANSAPPLYHEADINPUTs()
        {
            var list = _db.Queryable<TRANSAPPLYHEADINPUT>().ToList();
            var _ienumList = list.AsEnumerable();
            return new PageOfItems<TRANSAPPLYHEADINPUT>(_ienumList, 1, list.Count, list.Count);

        }

		/// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        public IPageOfItems<TRANSAPPLYHEADINPUT> GetTRANSAPPLYHEADINPUTsList(PagingInfo pagingInfo)
        {
            int totalCount = 0;

            var list = _db.Queryable<TRANSAPPLYHEADINPUT>(pagingInfo.TableName).OrderBy(x => x.ID).ToPageList(pagingInfo.PageIndex, pagingInfo.PageSize, ref totalCount);
            var newList = list.AsEnumerable();

            return new PageOfItems<TRANSAPPLYHEADINPUT>(newList, pagingInfo.PageIndex, pagingInfo.PageSize, totalCount);

        }

    }
}
	
