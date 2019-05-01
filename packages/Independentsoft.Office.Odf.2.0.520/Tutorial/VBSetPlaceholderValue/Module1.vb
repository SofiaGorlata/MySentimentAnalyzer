Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Fields

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim paragraphs As IList(Of Paragraph) = doc.GetParagraphs()

        For i As Integer = 0 To paragraphs.Count - 1

            For Each paragraphElement As IParagraphContent In paragraphs(i).Content
                If TypeOf paragraphElement Is Placeholder Then
                    Dim placeholder As Placeholder = DirectCast(paragraphElement, Placeholder)

                    If placeholder.Value = "<PhoneNumber>" Then
                        placeholder.Value = "<12345678>"
                    End If
                End If
            Next

        Next

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
