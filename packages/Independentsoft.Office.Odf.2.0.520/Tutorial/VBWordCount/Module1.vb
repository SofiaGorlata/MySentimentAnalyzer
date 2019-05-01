Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim wordCount As Integer = 0
        Dim separator As String() = New String() {" "}

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim texts As Text() = doc.GetTexts()

        For i As Integer = 0 To texts.Length - 1
            Dim words As String() = texts(i).Value.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            wordCount += words.Length
        Next

        Dim paragraphs As Paragraph() = doc.GetParagraphs()

        Dim emptyParagraphCount As Integer = 0

        For j As Integer = 0 To paragraphs.Length - 1
            If paragraphs(j).Content.Count = 0 Then
                emptyParagraphCount += 1
            End If
        Next

        Console.WriteLine("Paragraphs=" & paragraphs.Length)
        Console.WriteLine("Empty paragraphs=" & emptyParagraphCount)
        Console.WriteLine("Words=" & wordCount)

        Console.Read()

    End Sub
End Module
