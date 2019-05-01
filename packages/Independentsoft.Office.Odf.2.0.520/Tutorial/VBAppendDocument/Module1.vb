Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim first As New TextDocument("c:\test\first.odt")
        Dim second As New TextDocument("c:\test\second.odt")

        For Each bodyElement As ITextContent In second.Body.Content
            first.Body.Add(bodyElement)
        Next

        first.Save("c:\test\output.odt", True)

    End Sub
End Module
