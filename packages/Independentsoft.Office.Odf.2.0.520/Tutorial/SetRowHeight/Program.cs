using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Spreadsheet spreadsheet = new Spreadsheet();

            RowStyle rowStyle1 = new RowStyle("RS1");
            rowStyle1.Height = new Size(1, Unit.Inch);

            spreadsheet.AutomaticStyles.Styles.Add(rowStyle1);

            Row row1 = new Row();
            row1.Style = "RS1";

            Row row2 = new Row();
            row2.Style = "RS1";

            Row row3 = new Row();
            row3.Style = "RS1";

            Table sheet1 = new Table();
            sheet1.Rows.Add(row1);
            sheet1.Rows.Add(row2);
            sheet1.Rows.Add(row3);

            spreadsheet.Tables.Add(sheet1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}