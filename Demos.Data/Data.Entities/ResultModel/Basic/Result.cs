using Core.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Result
    {
        /// <summary>
        /// 返回提示信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回状态
        /// </summary>
        public StatusCodeEnum code { get; set; }
        /// <summary>
        /// 请求状态
        /// </summary>
        public bool result { get; set; }

    }

    public class Result<T> :Result
    {
        public object data { get; set; }
    }



}
