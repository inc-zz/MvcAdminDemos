﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demos.Admin.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {

        private static readonly string connectionString = ConfigurationManager.AppSettings["sqlConnectionString"];
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = connectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

    }
}