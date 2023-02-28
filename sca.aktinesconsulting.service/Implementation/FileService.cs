using OfficeOpenXml;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class FileService : IFileService
    {
        public List<DataTable> ExcelDataReader(string fileToRead, string sheetName, string col)
        {
            var dts = new List<DataTable>();
            using (FileStream file = new FileStream(fileToRead, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(file))
                {
                    using (var package = new ExcelPackage(file))
                    {

                        for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                        {
                            var worksheet = package.Workbook.Worksheets[i];
                            DataTable table = new DataTable();
                            if (string.IsNullOrEmpty(sheetName) || worksheet.Name.Equals(sheetName))
                            {
                                string sheet = worksheet.Name;
                                int colCount = worksheet.Dimension.End.Column;
                                for (int colinx = 1; colinx <= colCount; colinx++)
                                {
                                    table.Columns.Add("Col" + colinx);
                                }
                            }
                            var rowCount = worksheet.Dimension.Rows;
                            for (var rowNumber = 1; rowNumber <= rowCount; rowNumber++)
                            {
                                var cellText = worksheet.Cells[col + rowNumber + ":" + col + rowNumber].Text;
                                if (!string.IsNullOrEmpty(cellText))
                                {
                                    var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                                    var data = ((object[,])row.Value).Cast<dynamic>().ToArray();
                                    table.Rows.Add(data);
                                }

                            }
                            dts.Add(table);
                        }
                    }
                }
            }
            return dts;
        }

        public List<DataTable> ExcelDataReader(MemoryStream file, string sheetName, string col)
        {
            var dts = new List<DataTable>();
            using (var reader = new StreamReader(file))
            {
                using (var package = new ExcelPackage(file))
                {

                    for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                    {
                        var worksheet = package.Workbook.Worksheets[i];
                        DataTable table = new DataTable();
                        if (string.IsNullOrEmpty(sheetName) || worksheet.Name.Equals(sheetName))
                        {
                            string sheet = worksheet.Name;
                            int colCount = worksheet.Dimension.End.Column;
                            for (int colinx = 1; colinx <= colCount; colinx++)
                            {
                                table.Columns.Add("Col" + colinx);
                            }
                        }
                        var rowCount = worksheet.Dimension.Rows;
                        for (var rowNumber = 1; rowNumber <= rowCount; rowNumber++)
                        {
                            var cellText = worksheet.Cells[col + rowNumber + ":" + col + rowNumber].Text;
                            if (!string.IsNullOrEmpty(cellText))
                            {
                                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                                var data = ((object[,])row.Value).Cast<dynamic>().ToArray();
                                table.Rows.Add(data);
                            }

                        }
                        for (var r = 0; r < table.Rows.Count; r++)
                        {
                            for (var c = 0; c < table.Columns.Count; c++)
                            {
                                if (table.Rows[r][c] == DBNull.Value)
                                {
                                    table.Rows[r][c] = string.Empty;
                                }
                            }
                        }


                        dts.Add(table);
                    }
                }
            }
            return dts;
        }

        public void ExportToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                dtDataTable.Columns[i].ColumnName=dtDataTable.Columns[i].ColumnName.Replace(sw.NewLine,"").Replace(" ", "_").Replace("(","_").Replace(")", "_");
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(","))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }


    }
}
