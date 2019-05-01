Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As New Spreadsheet()

        Dim rowStyle1 As New RowStyle("RS1")
        rowStyle1.Height = New Size(1, Unit.Inch)

        spreadsheet.AutomaticStyles.Styles.Add(rowStyle1)

        Dim row1 As New Row()
        row1.Style = "RS1"

        Dim row2 As New Row()
        row2.Style = "RS1"

        Dim row3 As New Row()
        row3.Style = "RS1"

        Dim sheet1 As New Table()
        sheet1.Rows.Add(row1)
        sheet1.Rows.Add(row2)
        sheet1.Rows.Add(row3)

        spreadsheet.Tables.Add(sheet1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
