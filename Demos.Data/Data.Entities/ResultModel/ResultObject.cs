using Core.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    /// <summary>
    /// 通用返回实体
    /// </summary>
    [DataContract]
    public class ResultObject
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
        public string Message { set; get; }

    }
    /// <summary>
    /// 通用返回实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultObject<T>
    {
        /// <summary>
        /// 自定义返回信息
        /// </summary>
        [DataMember]
        public T Data { set; get; }
    }

    /// <summary>
    /// 返回登陆信息
    /// </summary>
    public class ResultToken : ResultObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }

}
