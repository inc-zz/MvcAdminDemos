
/*
*此代码由T4模板自动生成，所有在此基础上的更改将被覆盖，
*请勿在此文件添加自己的代码
*生成时间2019/05/29 08:26:18
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TZ.Modules.PTS.Models
{
    /// <summary>
    /// 公用代码分类编号的实体
    /// </summary>
    public partial class PubCodes 
    {
          
        /// <summary>
        /// 构造函数
        /// </summary>
        public PubCodes()
        {
                    }

         /// <summary>
        ///   
        /// </summary>
        public Guid PID { set; get; }

        /// <summary>
        ///  公用代码分类编号 
        /// </summary>
        public String PCClass { set; get; }

        /// <summary>
        ///  TZ编号 
        /// </summary>
        public String ParaGroup { set; get; }

        /// <summary>
        ///  公用代码编号 
        /// </summary>
        public String PCNo { set; get; }

        /// <summary>
        ///  公用代码名称 
        /// </summary>
        public String PCName { set; get; }

        /// <summary>
        ///  公用代码别称 
        /// </summary>
        public String PCNameA { set; get; }

        /// <summary>
        ///  公用代码全称 
        /// </summary>
        public String PCFullName { set; get; }

        /// <summary>
        ///  公用代码第三方编号 
        /// </summary>
        public String PCOtherNo { set; get; }

        /// <summary>
        ///  公代扩展属性 
        /// </summary>
        public String PCUserIntf { set; get; }

        /// <summary>
        ///   
        /// </summary>
        public DateTime? CreateTime { set; get; }

        /// <summary>
        ///   
        /// </summary>
        public String CreateUser { set; get; }

            
    }
}
