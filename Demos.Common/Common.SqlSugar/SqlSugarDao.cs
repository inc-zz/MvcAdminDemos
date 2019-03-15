using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SqlSugar
{
    public class SqlSugarDao
    {
        public  SqlSugarDao()
        {

        }
        public static SqlSugarClient GetInstance()
        {
            var connectionConfig = new ConnectionConfig();
            connectionConfig.ConnectionString = ConfigurationManager.AppSettings[@"MySqlConnection"]; //这里可以动态根据cookies或session实现多库切换
            connectionConfig.DbType = DbType.SqlServer;
            connectionConfig.IsAutoCloseConnection = true;
            return new SqlSugarClient(connectionConfig);
        }
    }
}
