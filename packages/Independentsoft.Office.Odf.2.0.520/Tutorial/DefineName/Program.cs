using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Spreadsheet spreadsheet = new Spreadsheet();

            Table sheet1 = new Table("Sheet1");
            spreadsheet.Tables.Add(sheet1);

            NamedRange range1 = new NamedRange("MyRange");
            range1.CellRangeAddress = "$Sheet1.$A$1:.$C$1";
            range1.BaseCellAddress = "$Sheet1.$C$1";

            spreadsheet.NamedElements.Add(range1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}