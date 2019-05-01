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

            ColumnStyle columnStyle1 = new ColumnStyle("CO1");
            columnStyle1.Width = new Size(3, Unit.Inch);

            spreadsheet.AutomaticStyles.Styles.Add(columnStyle1);

            Column column1 = new Column();
            column1.Style = "CO1";

            Table sheet1 = new Table();
            sheet1.Columns.Add(column1);

            spreadsheet.Tables.Add(sheet1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}