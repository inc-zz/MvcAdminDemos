using Core.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResultModel.Dto
{
    /// <summary>
    /// 通用返回实体,分页类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultPaging<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [DataMember]
        public bool Result { set; get; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        [DataMember]
        public StatusCodeEnum StatusCode { get; set; }
        /// <summary>
        /// 返回提示信息
        /// </summary>
        [DataMember]
        public string Message { set; get; } = string.Empty;



        private int _pageIndex = 1;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            set
            {
                if (value > 0)
                    this._pageIndex = value;
                else
                    this._pageIndex = 1;
            }
            get { return this._pageIndex; }
        }


        private int _pageSize = 10;
        /// <summary>
        /// 当前显示页数.默认10
        /// </summary>
        public int PageSize
        {
            set { this._pageSize = value; }
            get { return this._pageSize; }
        }

        /// <summary>
        /// 总条数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 自定义返回信息
        /// </summary>
        public List<T> Data { set; get; }
    }
}
