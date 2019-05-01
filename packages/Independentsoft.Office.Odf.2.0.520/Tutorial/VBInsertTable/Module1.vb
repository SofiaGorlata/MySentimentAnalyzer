Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument

        Dim cell1 As Cell = New Cell("test1")
        Dim cell2 As Cell = New Cell("test2")
        Dim cell3 As Cell = New Cell("test3")

        Dim row1 As Row = New Row
        row1.Cells.Add(cell1)
        row1.Cells.Add(cell2)
        row1.Cells.Add(cell3)

        Dim table1 As Table = New Table
        table1.Rows.Add(row1)
        table1.Rows.Add(row1)
        table1.Rows.Add(row1)
        table1.Rows.Add(row1)
        table1.Rows.Add(row1)

        Dim p1 As Paragraph = New Paragraph
        p1.Add("Below is a table:")

        Dim p2 As Paragraph = New Paragraph

        doc.Body.Add(p1)
        doc.Body.Add(p2)
        doc.Body.Add(table1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
