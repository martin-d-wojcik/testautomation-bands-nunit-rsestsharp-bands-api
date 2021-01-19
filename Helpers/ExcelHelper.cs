using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace NUnitTestBandsApi.Helpers
{
    class ExcelHelper
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public ExcelHelper(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)(Worksheets)wb.Worksheets[sheet];
        }

        public string readCell(int row, int column)
        {
            if(ws.Cells[row, column].ToString() != null)
            {
                return ws.Cells[row, column].ToString();
            }
            else
            {
                return "Nothing found.";
            }
        }
    }
}
