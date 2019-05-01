Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Fields

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim p1 As New Paragraph()
        p1.Add("Hello World")

        doc.Body.Add(p1)

        Dim bookmarkText As New Text("Some text here")

        Dim bookmarkStart As New BookmarkStart()
        bookmarkStart.Name = "BookmarkName"
        bookmarkStart.Add(bookmarkText)

        Dim bookmarkEnd As New BookmarkEnd()
        bookmarkEnd.Name = "BookmarkName"

        p1.Add(bookmarkStart)
        p1.Add(bookmarkEnd)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
