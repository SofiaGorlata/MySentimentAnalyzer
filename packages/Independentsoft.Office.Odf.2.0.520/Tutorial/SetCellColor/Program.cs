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

            CellStyle style1 = new CellStyle("CS1");
            style1.CellProperties.BackgroundColor = "#FFFF00"; //yellow
            style1.TextProperties.Color = "#FF0000"; //red
            
            spreadsheet.AutomaticStyles.Styles.Add(style1);

            Cell a1 = new Cell(100);
            a1.Style = "CS1";

            Table sheet1 = new Table();
            sheet1["A1"] = a1;
            
            spreadsheet.Tables.Add(sheet1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}

