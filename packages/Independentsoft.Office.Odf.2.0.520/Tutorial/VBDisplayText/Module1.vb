Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim text As String = doc.ToText()

        Console.WriteLine(text)
        Console.Read()

    End Sub
End Module
