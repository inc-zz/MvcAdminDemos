using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Common.RabbitMQ
{
    public class RabbitMQClientFactory
    {
        private static ConnectionFactory _factory = new ConnectionFactory();
        public static IConnection CreateConnection()
        {
            if (_factory == null)
            {

                const ushort heartbeat = 60;
                //主机地址

                _factory = new ConnectionFactory();
                //_factory.HostName = RabbitMQConfig.HostName;
                //用户名
                _factory.UserName = RabbitMQConfig.UserName;
                //密码
                _factory.Password = RabbitMQConfig.Password;
                //虚拟主机名
                _factory.VirtualHost = RabbitMQConfig.VirtualHost;
                //连接终端
                _factory.HostName = RabbitMQConfig.HostName;

                _factory.RequestedHeartbeat = heartbeat;
                //自动重连
                _factory.AutomaticRecoveryEnabled = true;
            }
            return _factory.CreateConnection();
        }

        public static IModel CreateModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}
