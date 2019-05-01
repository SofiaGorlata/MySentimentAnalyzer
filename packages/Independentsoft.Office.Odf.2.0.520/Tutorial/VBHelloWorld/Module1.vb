Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim p1 As Paragraph = New Paragraph()
        p1.Add("Hello World")

        doc.Body.Add(p1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
