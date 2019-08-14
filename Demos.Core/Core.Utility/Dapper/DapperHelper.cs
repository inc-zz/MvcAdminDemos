using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public class ConnectionConfig
    {
        public static string ConnectionString = "";//ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public static string GetConn()
        {
            return ConnectionString;
        }
    }

    public class DapperHelper
    {
        public static string ConnectionString = "";
        static DapperHelper()
        {
            ConnectionString = ConnectionConfig.GetConn();
        }

        /// <summary>
        /// 执行SQL返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public static List<T> Query<T>(string strSql)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<T>(strSql, null).ToList();
            }
        }

        /// <summary>
        /// 执行SQL返回集合
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="obj">参数model</param>
        /// <returns></returns>
        public static List<T> Query<T>(string strSql, object param, string con = "")
        {
            using (IDbConnection conn = new SqlConnection(string.IsNullOrEmpty(con) ? ConnectionString : con))
            {
                return conn.Query<T>(strSql, param).ToList();
            }
        }

        /// <summary>
        /// 执行SQL返回一个对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="obj">参数model</param>
        /// <returns></returns>
        public static T QueryFirst<T>(string strSql, object param, string con = "")
        {
            using (IDbConnection conn = new SqlConnection(string.IsNullOrEmpty(con) ? ConnectionString : con))
            {
                return conn.Query<T>(strSql, param).FirstOrDefault<T>();
            }
        }

        /// <summary>
        /// 执行SQL返回单个对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public static T QuerySingle<T>(string strSql, string con = "")
        {
            using (IDbConnection conn = new SqlConnection(string.IsNullOrEmpty(con) ? ConnectionString : con))
            {
                return conn.Query<T>(strSql).SingleOrDefault<T>();
            }
        }

        public static T QuerySingle<T>(string strSql, object param, string con = "")
        {
            using (IDbConnection conn = new SqlConnection(string.IsNullOrEmpty(con) ? ConnectionString : con))
            {
                return conn.Query<T>(strSql, param).SingleOrDefault<T>();
            }
        }

        /// <summary>
        /// 查询一组SQL语句并返回值
        /// </summary>
        /// <typeparam name="T1">第一条语句返回单个字段值</typeparam>
        /// <typeparam name="T2">第二条语句返回集合类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数化值</param>
        /// <returns></returns>
        public static Tuple<T1, IEnumerable<T2>> QueryFristSingle<T1, T2>(string sql, object param)
        {
            T1 _item1 = default(T1);
            IEnumerable<T2> _item2 = null;
            if (!string.IsNullOrEmpty(sql))
            {
                try
                {
                    using (var multi = new SqlConnection(ConnectionString).QueryMultiple(sql, param))
                    {
                        var t = multi.Read<T1>();
                        if (t != null)
                        {
                            var tVal = t.ToList();
                            if (tVal != null && tVal.Count >= 0)
                            {
                                _item1 = tVal[0];
                            }
                        }

                        _item2 = multi.Read<T2>();
                    }
                }
                catch (Exception ex)
                { throw ex; }
            }
            return Tuple.Create<T1, IEnumerable<T2>>(_item1, _item2);
        }

        /// <summary>
        /// 查询一组SQL语句并返回值
        /// </summary>
        /// <typeparam name="T1">第一条语句返回集合类型</typeparam>
        /// <typeparam name="T2">第二条语句返回集合类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数化值</param>
        /// <returns></returns>
        public static Tuple<IEnumerable<T1>, IEnumerable<T2>> Query<T1, T2>(string sql, object param)
        {
            IEnumerable<T1> _item1 = null;
            IEnumerable<T2> _item2 = null;
            if (!string.IsNullOrEmpty(sql))
            {
                try
                {
                    using (var multi = new SqlConnection(ConnectionString).QueryMultiple(sql, param))
                    {
                        _item1 = multi.Read<T1>();
                        _item2 = multi.Read<T2>();
                    }
                }
                catch (Exception ex)
                { throw ex; }
            }
            return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>>(_item1, _item2);
        }

        /// <summary>
        /// 查询一组SQL语句并返回值
        /// </summary>
        /// <typeparam name="T1">第一条语句返回集合类型</typeparam>
        /// <typeparam name="T2">第二条语句返回集合类型</typeparam>
        /// <typeparam name="T3">第三条语句返回集合类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数化值</param>
        /// <returns></returns>
        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Query<T1, T2, T3>(string sql, object param)
        {
            IEnumerable<T1> _item1 = null;
            IEnumerable<T2> _item2 = null;
            IEnumerable<T3> _item3 = null;
            if (!string.IsNullOrEmpty(sql))
            {
                try
                {
                    using (var multi = new SqlConnection(ConnectionString).QueryMultiple(sql, param))
                    {
                        _item1 = multi.Read<T1>();
                        _item2 = multi.Read<T2>();
                        _item3 = multi.Read<T3>();
                    }
                }
                catch (Exception ex)
                { throw ex; }
            }
            return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(_item1, _item2, _item3);
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static bool Execute(string strSql, object param, string con = "")
        {
            using (IDbConnection conn = new SqlConnection(string.IsNullOrEmpty(con) ? ConnectionString : con))
            {
                try
                {
                    return conn.Execute(strSql, param) > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="strProcedure">过程名</param>
        /// <returns></returns>
        public static bool ExecuteStoredProcedure(string strProcedure)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    return conn.Execute(strProcedure, null, null, null, CommandType.StoredProcedure) == 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="strProcedure">过程名</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static bool ExecuteStoredProcedure(string strProcedure, object param)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    return conn.Execute(strProcedure, param, null, null, CommandType.StoredProcedure) == 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool ExecuteStoredProcedure(string strProcedure, DynamicParameters param)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int rel = conn.Execute(strProcedure, param, null, null, CommandType.StoredProcedure);
                    return rel == 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 查询存储过程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strProcedure"></param>
        /// <returns></returns>
        public static List<T> QueryStoredProcedure<T>(string strProcedure)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<T>(strProcedure, null, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// 查询存储过程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strProcedure"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> QueryStoredProcedure<T>(string strProcedure, object param)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<T>(strProcedure, param, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }

        public static DataTable Query(string strSql)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    DataTable table = new DataTable("myTable1");
                    using (var reader = conn.ExecuteReader(strSql))
                    {
                        table.Load(reader);
                    }
                    return table;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataTable Query(string strSql, object param, string con = "")
        {
            using (IDbConnection conn = new SqlConnection(string.IsNullOrEmpty(con) ? ConnectionString : con))
            {
                try
                {
                    DataTable table = new DataTable("myTable1");
                    using (var reader = conn.ExecuteReader(strSql, param))
                    {
                        table.Load(reader);
                    }
                    return table;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataSet Query(string strSql, object param, DataTable[] dts)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    DataSet ds = new DataSet("myDataSet");
                    foreach (DataTable dt in dts)
                    {
                        ds.Tables.Add(dt);
                    }
                    using (var reader = conn.ExecuteReader(strSql, param))
                    {
                        ds.Load(reader, LoadOption.OverwriteChanges, dts);
                    }
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}