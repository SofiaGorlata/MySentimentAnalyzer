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

            DecimalNumber decimalNumber1 = new DecimalNumber();
            decimalNumber1.DecimalPlaces = 2;
            decimalNumber1.MinIntegerDigits = 1;
            decimalNumber1.Grouping = true;

            NumberStyle numberStyle1 = new NumberStyle("N1");
            numberStyle1.Number = decimalNumber1;

            CellStyle cellStyle1 = new CellStyle("CS1");
            cellStyle1.DataStyle = "N1";

            spreadsheet.AutomaticStyles.Styles.Add(numberStyle1);
            spreadsheet.AutomaticStyles.Styles.Add(cellStyle1);

            Cell a1 = new Cell(9999999);
            a1.Style = "CS1";

            Table sheet1 = new Table();
            sheet1["A1"] = a1;
            
            spreadsheet.Tables.Add(sheet1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}