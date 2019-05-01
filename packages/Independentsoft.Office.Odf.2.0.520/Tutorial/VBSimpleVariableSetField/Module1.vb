Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Fields

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim paragraphs As IList(Of Paragraph) = doc.GetParagraphs()

        For i As Integer = 0 To paragraphs.Count - 1
            For j As Integer = paragraphs(i).Content.Count - 1 To 0 Step -1

                If TypeOf paragraphs(i).Content(j) Is SimpleVariableSetField Then
                    Dim field As SimpleVariableSetField = DirectCast(paragraphs(i).Content(j), SimpleVariableSetField)

                    If field.Name = "CustomerID" Then
                        field.Value = "12345"
                    End If
                End If

            Next
        Next

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
