Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

''' <summary>
''' See cell borders and background color
''' </summary>
''' <remarks></remarks>
Module Module1
    Sub Main(ByVal args() As String)

        Dim tableStyle1 As TableStyle = New TableStyle("TableStyle1")
        tableStyle1.Width = New Size(6.3, Unit.Inch)
        tableStyle1.Alignment = TableAlignment.Left
        tableStyle1.LeftMargin = New Size(0, Unit.Inch)

        Dim columnStyle1 As ColumnStyle = New ColumnStyle("ColumnStyle1")
        columnStyle1.Width = New Size(1.2, Unit.Inch)

        Dim columnStyle2 As ColumnStyle = New ColumnStyle("ColumnStyle2")
        columnStyle2.Width = New Size(1.3, Unit.Inch)

        Dim cellStyle1 As CellStyle = New CellStyle("CellStyle1")
        cellStyle1.CellProperties.BackgroundColor = "#CCCCCC" ''gray
        cellStyle1.CellProperties.Border = New Border(New Size(0.0069, Unit.Inch), BorderStyle.Solid, "#000000")

        Dim cellStyle2 As CellStyle = New CellStyle("CellStyle2")
        cellStyle2.CellProperties.Border = New Border(New Size(0.0069, Unit.Inch), BorderStyle.Solid, "#000000")

        Dim doc As TextDocument = New TextDocument()
        doc.AutomaticStyles.Styles.Add(tableStyle1)
        doc.AutomaticStyles.Styles.Add(columnStyle1)
        doc.AutomaticStyles.Styles.Add(columnStyle2)
        doc.AutomaticStyles.Styles.Add(cellStyle1)
        doc.AutomaticStyles.Styles.Add(cellStyle2)

        Dim column1 As Column = New Column()
        column1.Style = "ColumnStyle1"

        Dim column2 As Column = New Column()
        column2.Style = "ColumnStyle1"

        Dim column3 As Column = New Column()
        column3.Style = "ColumnStyle2"

        Dim column4 As Column = New Column()
        column4.Style = "ColumnStyle2"

        Dim column5 As Column = New Column()
        column5.Style = "ColumnStyle2"

        Dim table1 As Table = New Table()
        table1.Style = "TableStyle1"

        table1.Columns.Add(column1)
        table1.Columns.Add(column2)
        table1.Columns.Add(column3)
        table1.Columns.Add(column4)
        table1.Columns.Add(column5)

        Dim cell11 As Cell = New Cell("A")
        cell11.Style = "CellStyle1"

        Dim cell12 As Cell = New Cell("B")
        cell12.Style = "CellStyle1"

        Dim cell13 As Cell = New Cell("C")
        cell13.Style = "CellStyle1"

        Dim cell14 As Cell = New Cell("D")
        cell14.Style = "CellStyle1"

        Dim cell15 As Cell = New Cell("E")
        cell15.Style = "CellStyle1"

        Dim row1 As Row = New Row()
        row1.Cells.Add(cell11)
        row1.Cells.Add(cell12)
        row1.Cells.Add(cell13)
        row1.Cells.Add(cell14)
        row1.Cells.Add(cell15)

        Dim cell21 As Cell = New Cell("1")
        cell21.Style = "CellStyle2"

        Dim cell22 As Cell = New Cell("2")
        cell22.Style = "CellStyle2"

        Dim cell23 As Cell = New Cell("3")
        cell23.Style = "CellStyle2"

        Dim cell24 As Cell = New Cell("4")
        cell24.Style = "CellStyle2"

        Dim cell25 As Cell = New Cell("5")
        cell25.Style = "CellStyle2"

        Dim row2 As Row = New Row()
        row2.Cells.Add(cell21)
        row2.Cells.Add(cell22)
        row2.Cells.Add(cell23)
        row2.Cells.Add(cell24)
        row2.Cells.Add(cell25)

        table1.Rows.Add(row1)
        table1.Rows.Add(row2)
        table1.Rows.Add(row2)
        table1.Rows.Add(row2)

        Dim p1 As Paragraph = New Paragraph()
        p1.Add("Table with style")

        Dim p2 As Paragraph = New Paragraph()

        doc.Body.Add(p1)
        doc.Body.Add(p2)
        doc.Body.Add(table1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
