using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table1 = new Table();

            table1[1, 1] = new Cell(1);
            table1[2, 1] = new Cell(2);
            table1[3, 1] = new Cell(3);
            table1[4, 1] = new Cell(4);
            table1[5, 1] = new Cell(5);

            table1["A", 2] = new Cell(1);
            table1["B", 2] = new Cell(2);
            table1["C", 2] = new Cell(3);
            table1["D", 2] = new Cell(4);
            table1["E", 2] = new Cell(5);

            table1["A3"] = new Cell(1);
            table1["B3"] = new Cell(2);
            table1["C3"] = new Cell(3);
            table1["D3"] = new Cell(4);
            table1["E3"] = new Cell(5);

            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.Tables.Add(table1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}

