Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Drawing

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim images As Image() = doc.GetImages

        For i As Integer = 0 To images.Length - 1
            images(i).Save("c:\test\" & images(i).FileName, True)
        Next

    End Sub
End Module
