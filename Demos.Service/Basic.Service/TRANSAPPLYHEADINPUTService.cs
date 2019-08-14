
using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using Data.Entities.Models;
using Data.Repository.Repository;

namespace Data.Entities.Service
{

    /// <summary>
    /// 深加工结转申请表表头表服务接口
    /// </summary>
    public partial class TRANSAPPLYHEADINPUTService: ITRANSAPPLYHEADINPUTService
    {

	    private ITRANSAPPLYHEADINPUTRepository repository;

        public TRANSAPPLYHEADINPUTService(ITRANSAPPLYHEADINPUTRepository _repository)
        {
            repository = _repository;
        }


		#region ITRANSAPPLYHEADINPUTService Members
       
        /// <summary>
        /// 判断是否存在改记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool IsExists(Guid ID){
			return false;
		}
       
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        public TRANSAPPLYHEADINPUT GetTRANSAPPLYHEADINPUT(Guid ID)
        {
            return repository.GetTRANSAPPLYHEADINPUT(ID);
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public ModelResult<TRANSAPPLYHEADINPUT> SaveTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model)
        {
             return repository.SaveTRANSAPPLYHEADINPUT(model); 
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public ModelResult<TRANSAPPLYHEADINPUT> AddTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model)
        {
            return repository.AddTRANSAPPLYHEADINPUT(model); 
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="addList"></param>
        /// <returns></returns>
        public bool BatchAddTRANSAPPLYHEADINPUT(List<TRANSAPPLYHEADINPUT> addList) {

            return repository.BatchAddTRANSAPPLYHEADINPUT(addList);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool RemoveTRANSAPPLYHEADINPUT(PagingInfo pagingInfo)
        {
            return repository.RemoveTRANSAPPLYHEADINPUT(pagingInfo);
        }
        
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool RemoveTRANSAPPLYHEADINPUT(TRANSAPPLYHEADINPUT model)
        {
            return repository.RemoveTRANSAPPLYHEADINPUT(model);
        }
        
        /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="IDList">字符串列表</param>
        /// <returns></returns>
        public bool RemoveTRANSAPPLYHEADINPUTList(string IDList)
        {
           return repository.RemoveTRANSAPPLYHEADINPUTList(IDList);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        public IPageOfItems<TRANSAPPLYHEADINPUT> GetTRANSAPPLYHEADINPUTs()
        {
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.PageSize = 100000;
            return repository.GetTRANSAPPLYHEADINPUTsList(pagingInfo);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagingInfo">Index:第几条开始,Size:获取几条</param>
        /// <returns></returns>
        public IPageOfItems<TRANSAPPLYHEADINPUT> GetTRANSAPPLYHEADINPUTsList(PagingInfo pagingInfo)
        {
            return repository.GetTRANSAPPLYHEADINPUTsList(pagingInfo);
        }	

		#endregion

    }
}
