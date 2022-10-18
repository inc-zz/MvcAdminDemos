using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Core.Utility.ExcelHelper
{
    public class ExcelHelperForCs
    {
        public static string DataTableToExcel(DataTable tempDataTable, string path, bool is2007 = true)
        {
            try
            {
                //创建工作薄
                var wk = GetWorkbook(is2007);
                SetHssfWorkbook(wk, tempDataTable);
                var outPath = string.Format(@"{0}.{1}", path, is2007 ? @"xlsx" : @"xls");
                using (var file = new FileStream(outPath, FileMode.Create))
                {
                    wk.Write(file);
                }
                return outPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MemoryStream DataTableToExcel(DataTable tempDataTable)
        {
            try
            {
                //创建工作薄
                var wk = new HSSFWorkbook();
                SetHssfWorkbook(wk, tempDataTable);
                var file = new MemoryStream();
                wk.Write(file);
                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// DataTable数据集合写入到Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static MemoryStream DataTableToExcel(DataSet ds)
        {
            try
            {
                var wk = new HSSFWorkbook();
                //创建工作薄
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    SetHssfWorkbook(wk, ds.Tables[i]);
                }
                var file = new MemoryStream();
                wk.Write(file);
                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// DataTable数据集合写入到Excel(2003以上版本)
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static MemoryStream DataTableToExcel_Xlsx(DataSet ds)
        {
            try
            {
                var wk = new XSSFWorkbook();
                //创建工作薄
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    SetHssfWorkbook(wk, ds.Tables[i]);
                }
                var file = new MemoryStream();
                wk.Write(file);
                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取Excel数据写入DataTable（从指定列开始读）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public static DataTable GetFromExcel(string filePath, bool isFirstRowColumn = true)
        {
            try
            {
                ISheet sheet = null;
                DataTable data = new DataTable();
                int startRow = 0;

                var workbook = GetWorkbook(filePath);

                sheet = workbook.GetSheetAt(0);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 读取Excel数据写入DataTable(指定页签指定列)
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetIndex"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public static DataTable GetFromExcel(string filePath, int sheetIndex, bool isFirstRowColumn = true)
        {
            try
            {
                ISheet sheet = null;
                DataTable data = new DataTable();
                int startRow = 0;

                var workbook = GetWorkbook(filePath);

                sheet = workbook.GetSheetAt(sheetIndex);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row.Cells.Count == 0) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public static DataTable GetFromExcel(Stream stream, bool isFirstRowColumn = true)
        {
            try
            {
                ISheet sheet = null;
                DataTable data = new DataTable();
                int startRow = 0;

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(stream); // 2007 格式

                sheet = workbook.GetSheetAt(0);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除空数据行
        /// </summary>
        /// <param name="dt"></param>
        public static void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }

        #region Private

        public static IWorkbook GetWorkbook(string path)
        {
            try
            {
                IWorkbook userModel;
                using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        userModel = new NPOI.XSSF.UserModel.XSSFWorkbook(file); // 2007 格式
                    }
                    catch (Exception)
                    {
                        userModel = new NPOI.HSSF.UserModel.HSSFWorkbook(file); // 2003 格式
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                return userModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static IWorkbook GetWorkbook(bool is2007 = true)
        {
            try
            {
                IWorkbook userModel;
                if (is2007)
                    userModel = new NPOI.XSSF.UserModel.XSSFWorkbook(); // 2007 格式
                else
                    userModel = new NPOI.HSSF.UserModel.HSSFWorkbook(); // 2003 格式

                return userModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void SetHssfWorkbook(IWorkbook hssfWorkbook, DataTable tempDataTable)
        {
            try
            {
                //创建一个名称为mySheet的表
                var tb = hssfWorkbook.CreateSheet(tempDataTable.TableName);
                //标题行
                var rowhead = tb.CreateRow(0);

                for (var i = 0; i < tempDataTable.Columns.Count; i++) //写入字段
                {
                    var cell = rowhead.CreateCell(i); //在第二行中创建单元格
                    cell.SetCellValue(tempDataTable.Columns[i].Caption); //循环往第二行的单元格中添加数据
                }

                for (var y = 0; y < tempDataTable.Rows.Count; y++)
                {
                    var rowcontent = tb.CreateRow(y + 1);
                    for (int i = 0; i < tempDataTable.Columns.Count; i++)
                    {
                        var cell = rowcontent.CreateCell(i); //在第二行中创建单元格
                        cell.SetCellValue(tempDataTable.Rows[y][tempDataTable.Columns[i].ToString()].ToString());
                        //循环往第二行的单元格中添加数据
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}