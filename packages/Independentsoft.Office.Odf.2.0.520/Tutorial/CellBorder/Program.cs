using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    /// <summary>
    /// See cell borders and background color
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TableStyle tableStyle1 = new TableStyle("TableStyle1");
            tableStyle1.Width = new Size(6.3, Unit.Inch);
            tableStyle1.Alignment = TableAlignment.Left;
            tableStyle1.LeftMargin = new Size(0, Unit.Inch);

            ColumnStyle columnStyle1 = new ColumnStyle("ColumnStyle1");
            columnStyle1.Width = new Size(1.2, Unit.Inch);

            ColumnStyle columnStyle2 = new ColumnStyle("ColumnStyle2");
            columnStyle2.Width = new Size(1.3, Unit.Inch);

            CellStyle cellStyle1 = new CellStyle("CellStyle1");
            cellStyle1.CellProperties.BackgroundColor = "#CCCCCC"; //gray
            cellStyle1.CellProperties.Border = new Border(new Size(0.0069, Unit.Inch), BorderStyle.Solid, "#000000");

            CellStyle cellStyle2 = new CellStyle("CellStyle2");
            cellStyle2.CellProperties.Border = new Border(new Size(0.0069, Unit.Inch), BorderStyle.Solid, "#000000");

            TextDocument doc = new TextDocument();
            doc.AutomaticStyles.Styles.Add(tableStyle1);
            doc.AutomaticStyles.Styles.Add(columnStyle1);
            doc.AutomaticStyles.Styles.Add(columnStyle2);
            doc.AutomaticStyles.Styles.Add(cellStyle1);
            doc.AutomaticStyles.Styles.Add(cellStyle2);

            Column column1 = new Column();
            column1.Style = "ColumnStyle1";

            Column column2 = new Column();
            column2.Style = "ColumnStyle1";

            Column column3 = new Column();
            column3.Style = "ColumnStyle2";

            Column column4 = new Column();
            column4.Style = "ColumnStyle2";

            Column column5 = new Column();
            column5.Style = "ColumnStyle2";

            Table table1 = new Table();
            table1.Style = "TableStyle1";

            table1.Columns.Add(column1);
            table1.Columns.Add(column2);
            table1.Columns.Add(column3);
            table1.Columns.Add(column4);
            table1.Columns.Add(column5);

            Cell cell11 = new Cell("A");
            cell11.Style = "CellStyle1";

            Cell cell12 = new Cell("B");
            cell12.Style = "CellStyle1";

            Cell cell13 = new Cell("C");
            cell13.Style = "CellStyle1";

            Cell cell14 = new Cell("D");
            cell14.Style = "CellStyle1";

            Cell cell15 = new Cell("E");
            cell15.Style = "CellStyle1";

            Row row1 = new Row();
            row1.Cells.Add(cell11);
            row1.Cells.Add(cell12);
            row1.Cells.Add(cell13);
            row1.Cells.Add(cell14);
            row1.Cells.Add(cell15);

            Cell cell21 = new Cell("1");
            cell21.Style = "CellStyle2";

            Cell cell22 = new Cell("2");
            cell22.Style = "CellStyle2";

            Cell cell23 = new Cell("3");
            cell23.Style = "CellStyle2";

            Cell cell24 = new Cell("4");
            cell24.Style = "CellStyle2";

            Cell cell25 = new Cell("5");
            cell25.Style = "CellStyle2";

            Row row2 = new Row();
            row2.Cells.Add(cell21);
            row2.Cells.Add(cell22);
            row2.Cells.Add(cell23);
            row2.Cells.Add(cell24);
            row2.Cells.Add(cell25);

            table1.Rows.Add(row1);
            table1.Rows.Add(row2);
            table1.Rows.Add(row2);
            table1.Rows.Add(row2);

            Paragraph p1 = new Paragraph();
            p1.Add("Table with style");

            Paragraph p2 = new Paragraph();

            doc.Body.Add(p1);
            doc.Body.Add(p2);
            doc.Body.Add(table1);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
