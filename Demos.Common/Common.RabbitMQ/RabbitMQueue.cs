using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Common.RabbitMQ
{
    public class RabbitMQueue
    {
        private RabbitMQClientContext _context = new RabbitMQClientContext();


        public void PublishMessage(string queue, string messag)
        {
            string exChange = "topic";
            string exchangeType = "topic";
            this.PublishMessage(queue, messag, exChange, exchangeType);
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exChange"></param>
        /// <param name="exchangeType"></param>
        /// <param name="queue"></param>
        public void PublishMessage(string queueName, string message, string exChange, string exchangeType)
        {
            _context.SendConnection = RabbitMQClientFactory.CreateConnection();
            using (_context.SendConnection)
            {
                _context.SendChannel = RabbitMQClientFactory.CreateModel(_context.SendConnection);
                using (_context.SendChannel)
                {
                    //设置交换器的类型
                    _context.SendChannel.ExchangeDeclare(exChange, exchangeType);
                    //声明一个队列，设置队列是否持久化，排他性，与自动删除
                    _context.SendChannel.QueueDeclare(queueName, true, false, false, null);
                    _context.SendChannel.QueueBind(queueName, exChange, "");
                    var properties = _context.SendChannel.CreateBasicProperties();
                    properties.Persistent = true;
                    _context.SendChannel.BasicPublish(exChange, queueName, properties, Encoding.UTF8.GetBytes(message));
                }
            }
        }

        /// <summary>
        /// 侦听信息
        /// </summary>
        /// <param name="queueName"></param>
        public void ListenInit(string queueName)
        {
            _context.ListenConnection = RabbitMQClientFactory.CreateConnection();
            _context.ListenConnection.ConnectionShutdown += (o, e) =>
            {
                Console.WriteLine("connection shutdown");
            };
            _context.ListenChannel = RabbitMQClientFactory.CreateModel(_context.ListenConnection);

            var consumer = new EventingBasicConsumer(_context.ListenChannel);//创建时间驱动的消费类型
            consumer.Received += consumer_Received;
            _context.ListenChannel.BasicQos(0, 1, false);
            //false为手动应答，true为自动应答
            _context.ListenChannel.BasicConsume(queueName, false, consumer);
        }
        /// <summary>
        /// 侦听事件
        /// </summary>
        public Func<string, bool> ReceiveMessageCallback { get; set; }

        /// <summary>
        /// 接受信息处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Body);
                var result = ReceiveMessageCallback(message);
                //若消息已处理,并通道未关闭则移除从该队列中移除此消息
                if (result && !_context.ListenChannel.IsClosed)
                {
                    _context.ListenChannel.BasicReject(e.DeliveryTag, false);
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// 队列中消息总数
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public int Count(string queueName)
        {
            int count = 0;
            _context.SendConnection = RabbitMQClientFactory.CreateConnection();
            using (_context.SendConnection)
            {
                _context.SendChannel = RabbitMQClientFactory.CreateModel(_context.SendConnection);
                using (_context.SendChannel)
                {
                    var res = _context.SendChannel.BasicGet(queueName, false);
                    count = res == null ? 0 : (int)res.MessageCount+1;
                }
            }
            return count;
        }
    }
}
