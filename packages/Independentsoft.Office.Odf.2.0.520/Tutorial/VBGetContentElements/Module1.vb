Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim elements As IList(Of IContentElement) = doc.GetContentElements()

        For Each element As IContentElement In elements
            If TypeOf element Is ListItem Then

                Dim item As ListItem = DirectCast(element, ListItem)

                Dim itemElements As IList(Of IContentElement) = item.GetContentElements()

                Console.WriteLine("")
                Console.Write("-")

                For Each itemElement As IContentElement In itemElements

                    If TypeOf itemElement Is Text Then
                        Dim text As Text = DirectCast(itemElement, Text)
                        Console.Write(text.Value)
                    End If

                Next

            End If
        Next

        Console.Read()

    End Sub
End Module
