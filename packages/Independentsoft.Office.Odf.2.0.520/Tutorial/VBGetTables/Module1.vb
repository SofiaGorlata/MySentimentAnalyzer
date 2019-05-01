Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim style1 As New TableStyle("NewTableStyle")
        style1.BackgroundColor = "#FFFF00" ''yellow

        doc.AutomaticStyles.Styles.Add(style1)

        Dim tables As Table() = doc.GetTables()

        For i As Integer = 0 To tables.Length - 1
            tables(i).Style = "NewTableStyle"
        Next

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
