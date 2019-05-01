using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Spreadsheet spreadsheet = new Spreadsheet("c:\\test\\input.ods");

            IList<Table> sheets = spreadsheet.GetTables();

            foreach (Table sheet in sheets)
            {
                foreach (Row row in sheet.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        Console.WriteLine(cell.Value);
                    }
                }
            }

            Console.Read();
        }
    }
}

