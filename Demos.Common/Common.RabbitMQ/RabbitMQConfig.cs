using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RabbitMQ
{
    public class RabbitMQConfig
    {
        /// <summary>
        /// 服务链接
        /// </summary>
        public static string HostName
        {
            get { return GetConfigValue("RabbitMQ_HostName","localhost"); }
        }
        /// <summary>
        /// 账户
        /// </summary>
        public static string UserName
        {
            get { return GetConfigValue("RabbitMQ_UserName","zlj"); }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public static string Password
        {
            get { return GetConfigValue("RabbitMQ_Password","123456"); }
        }
        /// <summary>
        /// 虚拟主机名称
        /// </summary>
        public static string VirtualHost
        {
            get { return GetConfigValue("RabbitMQ_VirtualHost","Demo"); }
        }


        private static string GetConfigValue(string key, string defaultValue = "")
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                // ignored
            }
            return defaultValue;
        }
    }
}
