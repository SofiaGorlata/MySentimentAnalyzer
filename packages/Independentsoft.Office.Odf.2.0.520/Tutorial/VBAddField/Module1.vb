Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Fields

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim dateField As Independentsoft.Office.Odf.Fields.Date = New Independentsoft.Office.Odf.Fields.Date
        Dim filNameField As FileName = New FileName

        Dim p1 As Paragraph = New Paragraph
        p1.Add("File name is: ")
        p1.Add(filNameField)

        Dim p2 As Paragraph = New Paragraph
        p2.Add("Current date is: ")
        p2.Add(dateField)

        doc.Body.Add(p1)
        doc.Body.Add(p2)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
