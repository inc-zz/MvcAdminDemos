using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// 搜索参数实体接口
    /// </summary>
    public abstract class IFilterModel : PagingInfo
    {
        /// <summary>
        /// 兼容easyui
        /// </summary>
        public int page
        {
            set { this.PageIndex = value; }
            get { return this.PageIndex; }
        }

        /// <summary>
        /// 兼容easyui
        /// </summary>
        public int rows
        {
            set { this.PageSize = value; }
            get { return this.PageSize; }
        }

        public string sort { get; set; }
        public string order { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PagingInfo
    {
        public string FieldList
        {
            get;
            set;
        }
        public Hashtable OrderByList
        {
            get;
            set;
        }
        public bool AllowPaging
        {
            get;
            set;
        }
        public int PageSize
        {
            get;
            set;
        }
        public int PageIndex
        {
            get;
            set;
        }
        public StringBuilder SqlWhere
        {
            get;
            set;
        }
        public string Comond
        {
            get;
            set;
        }
        public bool IsReCount
        {
            get;
            set;
        }
        public string TableName
        {
            get;
            set;
        }
        public Hashtable Params
        {
            get;
            set;
        }
        public PagingInfo()
        {
            this.PageSize = 10;
            this.PageIndex = 1;
            this.OrderByList = new Hashtable();
            this.SqlWhere = new StringBuilder();
            this.IsReCount = true;
            this.AllowPaging = true;
            this.TableName = string.Empty;
            this.Comond = string.Empty;
            this.FieldList = "*";
            this.Params = new Hashtable();
        }
    }
}

