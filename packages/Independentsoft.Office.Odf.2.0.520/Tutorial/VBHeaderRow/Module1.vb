Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument()

        Dim headerCell1 As New Cell("Header 1")
        Dim headerCell2 As New Cell("Header 2")
        Dim headerCell3 As New Cell("Header 3")

        Dim headerRow As New Row()
        headerRow.IsHeader = True
        headerRow.Cells.Add(headerCell1)
        headerRow.Cells.Add(headerCell2)
        headerRow.Cells.Add(headerCell3)

        Dim cell1 As New Cell("test1")
        Dim cell2 As New Cell("test2")
        Dim cell3 As New Cell("test3")

        Dim row1 As New Row()
        row1.Cells.Add(cell1)
        row1.Cells.Add(cell2)
        row1.Cells.Add(cell3)

        Dim table1 As New Table()
        table1.HeaderRows.Add(headerRow)

        For i As Integer = 0 To 199
            table1.Rows.Add(row1)
        Next

        Dim p1 As New Paragraph()
        p1.Add("Below is a table:")

        doc.Body.Add(p1)
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(table1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
