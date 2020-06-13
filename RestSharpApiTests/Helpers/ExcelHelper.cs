using OfficeOpenXml;
using System;
using System.Data;
using static System.Configuration.ConfigurationManager;
namespace RestSharpApiTests
{
    public static class ExcelHelper
    {
        // Reads Excel and return datatable 
        public static DataTable ExcelRead(string excelFilePath = "")
        {
            if (excelFilePath == "")
                excelFilePath = AppSettings["TestDataPath"];
                
            ExcelPackage excel = new ExcelPackage(new System.IO.FileInfo(excelFilePath));
            var xlSheet = excel.Workbook.Worksheets["Sheet1"];

            DataTable dt = new DataTable();
            return dt = ToDataTable(xlSheet);
        }

        // Convert Excel Data to datatable
        public static DataTable ToDataTable(this ExcelWorksheet ws, bool hasHeaderRow = true)
        {
            var tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                tbl.Columns.Add(hasHeaderRow ?
                    firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            var startRow = hasHeaderRow ? 2 : 1;
            for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                var row = tbl.NewRow();
                foreach (var cell in wsRow) row[cell.Start.Column - 1] = cell.Text;
                tbl.Rows.Add(row);
            }
            return tbl;
        }

        // Return ExcelData for specific test case
        public static ExcelProperties GetExcelDataRelativeToTc()
        {
            var dt = ExcelRead();
            var excelProperties = new ExcelProperties();
            foreach (DataRow row in dt.Rows)
            {
                if (requres.testCaseName == row[ExcelColumnsEnum.Name.ToString()].ToString().Replace(" ", ""))
                {
                    excelProperties.Name = row[ExcelColumnsEnum.Name.ToString()].ToString();
                    excelProperties.RestClient = row[ExcelColumnsEnum.RestClient.ToString()].ToString();
                    excelProperties.RestRequest = row[ExcelColumnsEnum.RestRequest.ToString()].ToString();
                    excelProperties.RequestMethod = row[ExcelColumnsEnum.RequestMethod.ToString()].ToString();
                    excelProperties.JsonRequest = row[ExcelColumnsEnum.JsonRequest.ToString()].ToString();
                    excelProperties.ExpectedResponseJson = row[ExcelColumnsEnum.ExpectedResponseJson.ToString()].ToString();
                    excelProperties.ExpectedResponseCode = Convert.ToInt32(row[ExcelColumnsEnum.ExpectedResponseCode.ToString()]);
                    excelProperties.RunFlag = Convert.ToBoolean(row[ExcelColumnsEnum.RunFlag.ToString()].ToString());
                    break;
                }
            }
            return excelProperties;
        }
    }
}
