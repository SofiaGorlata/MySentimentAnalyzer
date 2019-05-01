Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim table1 As Table = New Table()

        table1(1, 1) = New Cell(1)
        table1(2, 1) = New Cell(2)
        table1(3, 1) = New Cell(3)
        table1(4, 1) = New Cell(4)
        table1(5, 1) = New Cell(5)

        table1("A", 2) = New Cell(1)
        table1("B", 2) = New Cell(2)
        table1("C", 2) = New Cell(3)
        table1("D", 2) = New Cell(4)
        table1("E", 2) = New Cell(5)

        table1("A3") = New Cell(1)
        table1("B3") = New Cell(2)
        table1("C3") = New Cell(3)
        table1("D3") = New Cell(4)
        table1("E3") = New Cell(5)

        Dim spreadsheet As Spreadsheet = New Spreadsheet()
        spreadsheet.Tables.Add(table1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
