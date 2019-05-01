Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim paragraphs As IList(Of Paragraph) = doc.GetParagraphs()

        For i As Integer = 0 To paragraphs.Count - 1
            For Each paragraphElement As IParagraphContent In paragraphs(i).Content
                If TypeOf paragraphElement Is Bookmark Then
                    Dim bookmark As Bookmark = DirectCast(paragraphElement, Bookmark)

                    Console.WriteLine("Bookmark: " + bookmark.Name)
                ElseIf TypeOf paragraphElement Is BookmarkStart Then
                    Dim bookmarkStart As BookmarkStart = DirectCast(paragraphElement, BookmarkStart)

                    Console.WriteLine("BookmarkStart: " + bookmarkStart.Name)
                ElseIf TypeOf paragraphElement Is BookmarkEnd Then
                    Dim bookmarkEnd As BookmarkEnd = DirectCast(paragraphElement, BookmarkEnd)

                    Console.WriteLine("BookmarkEnd: " + bookmarkEnd.Name)
                End If
            Next
        Next

        Console.WriteLine("Pess any key to close.")
        Console.Read()

    End Sub
End Module
