Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim spreadsheet As New Spreadsheet()

        Dim annotation1 As New Annotation()
        annotation1.Creator = "John"
        annotation1.CreationDate = DateTime.Now

        Dim commentParagraph As New Paragraph()
        commentParagraph.Add("My comment text.")

        annotation1.Content.Add(commentParagraph)

        Dim a1 As New Cell(100)
        a1.Content.Add(annotation1)

        Dim sheet1 As New Table()
        sheet1("A1") = a1

        spreadsheet.Tables.Add(sheet1)

        spreadsheet.Save("c:\test\output.ods", True)

    End Sub
End Module
