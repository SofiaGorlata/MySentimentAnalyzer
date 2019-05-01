Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        doc.Replace("John Smith", "Mary Rose")

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
