using Hangfire;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace Demos.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageController : ApiController
    {
        /// <summary>
        /// 这个是用来发送消息的静态方法
        /// </summary>
        /// <param name="message"></param>
        public static void Send(string message)
        {
            EventLog.WriteEntry("EventSystem", string.Format("这是由Hangfire后台任务发送的消息:{0},时间为:{1}", message, DateTime.Now));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IHttpActionResult Post(string content)
        {
            //这里可以做一些业务判断或操作

            //然后需要推送的时候，调用下面的方法即可
            //BackgroundJob.Enqueue(() => Send(content));

            //最后返回（这里是立即返回，不会阻塞）
            return Ok();
        }
    }
}