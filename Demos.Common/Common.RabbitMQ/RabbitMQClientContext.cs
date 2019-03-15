using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Common.RabbitMQ
{
    public class RabbitMQClientContext
    {
        /// <summary>
        /// 用于发送消息的Connection
        /// </summary>
        public IConnection SendConnection { set; internal get; }
        /// <summary>
        /// 用于发送消息的Channel
        /// </summary>
        public IModel SendChannel { set; internal get; }
        /// <summary>
        /// 用于侦听的Connection
        /// </summary>
        public IConnection ListenConnection { set; internal get; }
        /// <summary>
        /// 用于侦听的Channel
        /// </summary>
        public IModel ListenChannel { set; internal get; }
    }
}
