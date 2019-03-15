using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.EnumType
{
    /// <summary>
    /// 返回状态码
    /// </summary>
    [DataContract]
    public enum StatusCodeEnum
    {
        /// <summary>
        ///处理成功
        /// </summary>
        [TextAttribute("处理成功")]
        [EnumMember]
        Success = 200,

        /// <summary>
        ///手机号已被注册
        /// </summary>
        [TextAttribute("手机号已被注册")]
        [EnumMember]
        IsRegisterMobile = 201,
        /// <summary>
        ///用户不存在
        /// </summary>
        [TextAttribute("用户不存在")]
        [EnumMember]
        NoFoundUser = 202,
        /// <summary>
        /// 内部请求出错
        /// </summary>
        [TextAttribute("内部请求出错")]
        [EnumMember]
        Error = 500,
        /// <summary>
        /// 未授权标识
        /// </summary>
        [TextAttribute("未授权标识")]
        [EnumMember]
        Unauthorized = 401,
        /// <summary>
        /// 请求参数不完整或不正确
        /// </summary>
        [TextAttribute("请求参数不完整或不正确")]
        [EnumMember]
        ParameterError = 400,
        /// <summary>
        /// 请求TOKEN失效
        /// </summary>
        [TextAttribute("请求TOKEN失效")]
        [EnumMember]
        TokenInvalid = 403,
        /// <summary>
        /// HTTP请求类型不合法
        /// </summary>
        [TextAttribute("HTTP请求类型不合法")]
        [EnumMember]
        HttpMehtodError = 405,
        /// <summary>
        /// HTTP请求不合法,请求参数可能被篡改
        /// </summary>
        [TextAttribute("HTTP请求不合法,请求参数可能被篡改")]
        [EnumMember]
        HttpRequestError = 406,
        /// <summary>
        /// 该URL已经失效
        /// </summary>
        [TextAttribute("该URL已经失效")]
        [EnumMember]
        URLExpireError = 407,

        /// <summary>
        /// 短信发送失败
        /// </summary>
        [TextAttribute("短信发送失败")]
        [EnumMember]
        SMSSendError = 408,

        /// <summary>
        /// 验证码错误
        /// </summary>
        [TextAttribute("验证码错误")]
        [EnumMember]
        IdentifyingCodeError = 409,

    }
}
