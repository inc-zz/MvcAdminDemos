using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        /// <summary>
        /// 单表查询对象
        /// </summary>
        /// <returns></returns>
        Queryable<TEntity> Queryable();


        /// <summary>
        ///  单表查询对象
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        Queryable<TEntity> Queryable(string tableName);

        /// <summary>
        /// 根据SQL语句将结果集映射到List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="whereObj"></param>
        /// <returns></returns>
        List<TEntity> SqlQuery(string sql, object whereObj = null);

        /// <summary>
        /// 根据SQL语句将结果集映射到dynamic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="whereObj"></param>
        /// <returns></returns>
        dynamic SqlQueryDynamic(string sql, object whereObj = null);

        /// <summary>
        /// 根据SQL语句将结果集映射到json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="whereObj"></param>
        /// <returns></returns>
        string SqlQueryJson(string sql, object whereObj = null);

        /// <summary>
        /// 根据SQL语句将结果集映射到List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        List<TEntity> SqlQuery(string sql, SqlParameter[] pars);

        /// <summary>
        /// 根据SQL语句将结果集映射到List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="reader"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        List<TEntity> SqlQuery(string sql, List<SqlParameter> pars);

        /// <summary>
        /// 批量插入
        /// 使用说明:sqlSugar.Insert(List《entity》);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="isIdentity">主键是否为自增长,true可以不填,false必填</param>
        /// <returns></returns>
        List<object> InsertRange(List<TEntity> entities, bool isIdentity = true);

        /// <summary>
        /// 插入
        /// 使用说明:sqlSugar.Insert(entity);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="isIdentity">该属性已经作废可以不填，主键是否为自增长,true可以不填,false必填</param>
        /// <returns></returns>
        object Insert(TEntity entity, bool isIdentity = true);

        /// <summary>
        /// 更新
        /// 注意：rowObj为T类型将更新该实体的非主键所有列，如果rowObj类型为匿名类将更新指定列
        /// 使用说明:sqlSugar.Update《T》(rowObj,whereObj);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rowObj">new T(){name="张三",sex="男"}或者new {name="张三",sex="男"}</param>
        /// <param name="expression">it.id=100</param>
        /// <returns></returns>
        bool Update(object rowObj, Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rowObj">实体必须包含主键</param>
        /// <returns></returns>
        bool Update(TEntity rowObj);

        /// <summary>
        /// 更新
        /// 注意：rowObj为T类型将更新该实体的非主键所有列，如果rowObj类型为匿名类将更新指定列
        /// 使用说明:sqlSugar.Update《T》(rowObj,whereObj);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rowObj">new T(){name="张三",sex="男"}或者new {name="张三",sex="男"}</param>
        /// <param name="whereIn">new int[]{1,2,3}</param>
        /// <returns></returns>
        bool Update<FiledType>(object rowObj, params FiledType[] whereIn);

        /// <summary>
        /// 删除,根据表达示
        /// 使用说明:
        /// Delete《T》(it=>it.id=100) 或者Delete《T》(3)
        /// </summary>
        /// <param name="expression">筛选表达示</param>
        bool Delete<TEntity>(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 批量删除
        /// 注意：whereIn 主键集合  
        /// 使用说明:Delete《T》(new int[]{1,2,3}) 或者  Delete《T》(3)
        /// </summary>
        /// <param name="whereIn"> delete ids </param>
        bool Delete<FiledType>(params FiledType[] whereIn);

        /// <summary>
        /// 批量假删除
        /// 使用说明::
        /// FalseDelete《T》("is_del",new int[]{1,2,3})或者Delete《T》("is_del",3)
        /// </summary>
        /// <param name="field">更新删除状态字段</param>
        /// <param name="whereIn">delete ids</param>
        bool FalseDelete<FiledType>(string field, params FiledType[] whereIn);

        /// <summary>
        /// 假删除，根据表达示
        /// 使用说明::
        /// FalseDelete《T》(new int[]{1,2,3})或者Delete《T》(3)
        /// </summary>
        /// <param name="field">更新删除状态字段</param>
        /// <param name="expression">筛选表达示</param>
        bool FalseDelete(string field, Expression<Func<TEntity, bool>> expression);
    }
}
