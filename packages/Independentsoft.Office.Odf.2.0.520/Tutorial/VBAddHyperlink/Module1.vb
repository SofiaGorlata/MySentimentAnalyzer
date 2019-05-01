Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim link As Hyperlink = New Hyperlink
        link.Add("Independentsoft")
        link.Location = "http://www.independentsoft.com"

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(link)

        doc.Body.Add(paragraph1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
