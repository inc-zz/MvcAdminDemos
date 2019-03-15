using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webdiyer.WebControls.Mvc
{
    /// <summary>
    /// 搜索参数实体接口
    /// </summary>
    public abstract class IFilterModel: IPaging
    {
        /// <summary>
        /// 兼容easyui
        /// </summary>
        public int page
        {
            set { this._pageIndex = value; }
            get { return this._pageIndex; }
        }
      
        /// <summary>
        /// 兼容easyui
        /// </summary>
        public int rows
        {
            set { this._pageSize = value; }
            get { return this._pageSize; }
        }

        public string sort { get; set; }
        public string order { get; set; }
    }

    /// <summary>
    /// 搜索参数实体接口
    /// </summary>
    public abstract class IPaging
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        protected int _pageIndex = 1;
        public int PageIndex
        {
            set { this._pageIndex = value; }
            get { return this._pageIndex; }
        }

        /// <summary>
        /// 当前显示页数.默认20
        /// </summary>
        protected int _pageSize = 20;
        public int PageSize
        {
            set { this._pageSize = value; }
            get { return this._pageSize; }
        }
    }
}
