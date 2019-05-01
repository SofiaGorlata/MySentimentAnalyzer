Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As New Spreadsheet()

        Dim style1 As New CellStyle("CS1")
        style1.CellProperties.BackgroundColor = "#FFFF00" ''yellow
        style1.TextProperties.Color = "#FF0000" ''red

        spreadsheet.AutomaticStyles.Styles.Add(style1)

        Dim a1 As New Cell(100)
        a1.Style = "CS1"

        Dim sheet1 As New Table()
        sheet1("A1") = a1

        spreadsheet.Tables.Add(sheet1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
