using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Common.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : Entity, new()
    {
        protected SqlSugarClient _db;

        public Repository(SqlSugarClient db)
        {
            _db = db;
        }
        /// <summary>
        /// 根据SQL语句将结果集映射到List&lt;T&gt;
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <returns>T的集合</returns>
        public List<T> SqlQuery<T>(string sql, object whereObj = null)
        {
            return _db.Queryable<T>(sql, whereObj);
        }
        /// <summary>
        /// 单表查询对象
        /// </summary>
        /// <returns></returns>
        public Queryable<TEntity> Queryable()
        {
            return _db.Queryable<TEntity>();
        }
        /// <summary>
        ///  单表查询对象
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public Queryable<TEntity> Queryable(string tableName)
        {
            return _db.Queryable<TEntity>(tableName);
        }

        /// <summary>
        /// 根据SQL语句将结果集映射到List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="whereObj"></param>
        /// <returns></returns>
        public List<TEntity> SqlQuery(string sql, object whereObj = null)
        {
            return _db.SqlQuery<TEntity>(sql, whereObj);
        }

        /// <summary>
        /// 根据SQL语句将结果集映射到dynamic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="whereObj"></param>
        /// <returns></returns>
        public dynamic SqlQueryDynamic(string sql, object whereObj = null)
        {
            return _db.SqlQueryDynamic(sql, whereObj);
        }

        /// <summary>
        /// 根据SQL语句将结果集映射到json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="whereObj"></param>
        /// <returns></returns>
        public string SqlQueryJson(string sql, object whereObj = null)
        {
            return _db.SqlQueryJson(sql, whereObj);
        }

        /// <summary>
        /// 根据SQL语句将结果集映射到List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public List<TEntity> SqlQuery(string sql, MySqlParameter[] pars)
        {
            return _db.SqlQuery<TEntity>(sql, pars);
        }

        /// <summary>
        /// 根据SQL语句将结果集映射到List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="reader"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public List<TEntity> SqlQuery(string sql, List<MySqlParameter> pars)
        {
            return _db.SqlQuery<TEntity>(sql, pars);
        }

        /// <summary>
        /// 批量插入
        /// 使用说明:sqlSugar.Insert(List《entity》);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="isIdentity">主键是否为自增长,true可以不填,false必填</param>
        /// <returns></returns>
        public List<object> InsertRange(List<TEntity> entities, bool isIdentity = true)
        {
            return _db.InsertRange<TEntity>(entities, isIdentity);
        }

        /// <summary>
        /// 插入
        /// 使用说明:sqlSugar.Insert(entity);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="isIdentity">该属性已经作废可以不填，主键是否为自增长,true可以不填,false必填</param>
        /// <returns></returns>
        public object Insert(TEntity entity, bool isIdentity = true)
        {
            return _db.Insert(entity, isIdentity);
        }

        /// <summary>
        /// 更新
        /// 注意：rowObj为T类型将更新该实体的非主键所有列，如果rowObj类型为匿名类将更新指定列
        /// 使用说明:sqlSugar.Update《T》(rowObj,whereObj);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rowObj">new T(){name="张三",sex="男"}或者new {name="张三",sex="男"}</param>
        /// <param name="expression">it.id=100</param>
        /// <returns></returns>
        public bool Update(object rowObj, Expression<Func<TEntity, bool>> expression)
        {
            return _db.Update(rowObj, expression);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rowObj">实体必须包含主键</param>
        /// <returns></returns>
        public bool Update(TEntity rowObj)
        {
            return _db.Update(rowObj);
        }

        /// <summary>
        /// 更新
        /// 注意：rowObj为T类型将更新该实体的非主键所有列，如果rowObj类型为匿名类将更新指定列
        /// 使用说明:sqlSugar.Update《T》(rowObj,whereObj);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rowObj">new T(){name="张三",sex="男"}或者new {name="张三",sex="男"}</param>
        /// <param name="whereIn">new int[]{1,2,3}</param>
        /// <returns></returns>
        public bool Update<FiledType>(object rowObj, params FiledType[] whereIn)
        {
            return _db.Update<TEntity, FiledType>(rowObj, whereIn);
        }

        /// <summary>
        /// 删除,根据表达示
        /// 使用说明:
        /// Delete《T》(it=>it.id=100) 或者Delete《T》(3)
        /// </summary>
        /// <param name="expression">筛选表达示</param>
        public bool Delete<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            return _db.Delete(expression);
        }

        /// <summary>
        /// 批量删除
        /// 注意：whereIn 主键集合  
        /// 使用说明:Delete《T》(new int[]{1,2,3}) 或者  Delete《T》(3)
        /// </summary>
        /// <param name="whereIn"> delete ids </param>
        public bool Delete<FiledType>(params FiledType[] whereIn)
        {
            return _db.Delete<TEntity, FiledType>(whereIn);
        }

        /// <summary>
        /// 批量假删除
        /// 使用说明::
        /// FalseDelete《T》("is_del",new int[]{1,2,3})或者Delete《T》("is_del",3)
        /// </summary>
        /// <param name="field">更新删除状态字段</param>
        /// <param name="whereIn">delete ids</param>
        public bool FalseDelete<FiledType>(string field, params FiledType[] whereIn)
        {
            return _db.FalseDelete<TEntity, FiledType>(field, whereIn);
        }

        /// <summary>
        /// 假删除，根据表达示
        /// 使用说明::
        /// FalseDelete《T》(new int[]{1,2,3})或者Delete《T》(3)
        /// </summary>
        /// <param name="field">更新删除状态字段</param>
        /// <param name="expression">筛选表达示</param>
        public bool FalseDelete(string field, Expression<Func<TEntity, bool>> expression)
        {
            return _db.FalseDelete(field, expression);
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTran()
        {
            _db.BeginTran();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTran()
        {
            _db.CommitTran();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTran()
        {
            _db.RollbackTran();
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}
