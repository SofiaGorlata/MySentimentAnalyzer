Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As Spreadsheet = New Spreadsheet("c:\test\input.ods")

        Dim sheets As Table() = spreadsheet.GetTables()

        For Each sheet As Table In sheets
            For Each row As Row In sheet.Rows
                For Each cell As Cell In row.Cells
                    Console.WriteLine(cell.Value)
                Next
            Next
        Next

        Console.Read()

    End Sub
End Module
