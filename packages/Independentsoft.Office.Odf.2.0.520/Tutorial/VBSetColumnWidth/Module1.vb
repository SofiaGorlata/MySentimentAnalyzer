Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As New Spreadsheet()

        Dim columnStyle1 As New ColumnStyle("CO1")
        columnStyle1.Width = New Size(3, Unit.Inch)

        spreadsheet.AutomaticStyles.Styles.Add(columnStyle1)

        Dim column1 As New Column()
        column1.Style = "CO1"

        Dim sheet1 As New Table()
        sheet1.Columns.Add(column1)

        spreadsheet.Tables.Add(sheet1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
