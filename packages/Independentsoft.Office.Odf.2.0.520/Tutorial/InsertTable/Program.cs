using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            Cell cell1 = new Cell("test1");
            Cell cell2 = new Cell("test2");
            Cell cell3 = new Cell("test3");

            Row row1 = new Row();
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell2);
            row1.Cells.Add(cell3);

            Table table1 = new Table();
            table1.Rows.Add(row1);
            table1.Rows.Add(row1);
            table1.Rows.Add(row1);
            table1.Rows.Add(row1);
            table1.Rows.Add(row1);

            Paragraph p1 = new Paragraph();
            p1.Add("Below is a table:");

            Paragraph p2 = new Paragraph();

            doc.Body.Add(p1);
            doc.Body.Add(p2);
            doc.Body.Add(table1);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
