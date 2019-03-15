using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public interface ILog
    {
        /// <summary>
        /// 记录类型为[Info]的日志信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Info(string message);

        /// <summary>
        /// 记录类型为[Debug]的日志信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Debug(string message);

        /// <summary>
        /// 记录类型为[Warning]的日志信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Warning(string message);

        /// <summary>
        /// 记录类型为[Error]的日志信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Error(string message);

        /// <summary>
        /// 记录类型为[Exception]的日志信息
        /// </summary>
        /// <param name="exception">异常信息</param>
        void Exception(Exception exception);
    }
}
