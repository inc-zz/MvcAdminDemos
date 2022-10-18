using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.ExcelHelper
{

    /// <summary>
    /// 
    /// </summary>
    public class ExcelReadByOldeb
    {

        /// <summary>
        /// 获取指定路径、指定工作簿名称的Excel数据
        /// </summary>
        /// <param name="FilePath">文件存储路径</param>
        /// <param name="WorkSheetName">工作簿名称</param>
        /// <returns>如果争取找到了数据会返回一个完整的Table，否则返回异常</returns>
        public static DataTable ReadExcelToDataTable(string filePath, string workSheetName)
        {
            DataTable dtExcel = new DataTable();
            OleDbConnection con = new OleDbConnection(GetExcelConnection(filePath));
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [" + workSheetName + "$]", con);
            //读取
            con.Open();
            adapter.FillSchema(dtExcel, SchemaType.Mapped);
            adapter.Fill(dtExcel);
            con.Close();
            dtExcel.TableName = workSheetName;
            //返回
            return dtExcel;

        }
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static string GetExcelConnection(string strFilePath)
        {
            if (!File.Exists(strFilePath))
            {
                throw new Exception("指定的Excel文件不存在！");
            }
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Server.MapPath("ExcelFiles/MyExcelFile.xls") + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
            return "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + strFilePath + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)

        }
    }
}