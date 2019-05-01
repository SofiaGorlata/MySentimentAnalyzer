Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As New Spreadsheet()

        Dim decimalNumber1 As New DecimalNumber()
        decimalNumber1.DecimalPlaces = 2
        decimalNumber1.MinIntegerDigits = 1
        decimalNumber1.Grouping = True

        Dim numberStyle1 As New NumberStyle("N1")
        numberStyle1.Number = decimalNumber1

        Dim cellStyle1 As New CellStyle("CS1")
        cellStyle1.DataStyle = "N1"

        spreadsheet.AutomaticStyles.Styles.Add(numberStyle1)
        spreadsheet.AutomaticStyles.Styles.Add(cellStyle1)

        Dim a1 As New Cell(9999999)
        a1.Style = "CS1"

        Dim sheet1 As New Table()
        sheet1("A1") = a1

        spreadsheet.Tables.Add(sheet1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
