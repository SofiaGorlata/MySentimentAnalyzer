Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As New Spreadsheet()

        Dim sheet1 As New Table("Sheet1")
        spreadsheet.Tables.Add(sheet1)

        Dim range1 As New NamedRange("MyRange")
        range1.CellRangeAddress = "$Sheet1.$A$1:.$C$1"
        range1.BaseCellAddress = "$Sheet1.$C$1"

        spreadsheet.NamedElements.Add(range1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
