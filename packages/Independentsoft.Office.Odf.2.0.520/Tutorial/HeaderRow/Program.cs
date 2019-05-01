using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();
            
            Cell headerCell1 = new Cell("Header 1");
            Cell headerCell2 = new Cell("Header 2");
            Cell headerCell3 = new Cell("Header 3");

            Row headerRow = new Row();
            headerRow.IsHeader = true;
            headerRow.Cells.Add(headerCell1);
            headerRow.Cells.Add(headerCell2);
            headerRow.Cells.Add(headerCell3);

            Cell cell1 = new Cell("test1");
            Cell cell2 = new Cell("test2");
            Cell cell3 = new Cell("test3");

            Row row1 = new Row();
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell2);
            row1.Cells.Add(cell3);

            Table table1 = new Table();
            table1.HeaderRows.Add(headerRow);

            for (int i = 0; i < 200; i++)
            {
                table1.Rows.Add(row1);
            }

            Paragraph p1 = new Paragraph();
            p1.Add("Below is a table:");

            doc.Body.Add(p1);
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(table1);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
