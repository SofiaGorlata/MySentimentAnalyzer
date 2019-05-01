Imports System
Imports Independentsoft.Office.Odf

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\test\input.odt")

        Dim paragraphs As IList(Of Paragraph) = doc.GetParagraphs()

        For i As Integer = 0 To paragraphs.Count - 1

            For Each paragraphElement As IParagraphContent In paragraphs(i).Content

                If TypeOf paragraphElement Is Bookmark Then

                    Dim bookmark As Bookmark = DirectCast(paragraphElement, Bookmark)

                    If bookmark.Name.IndexOf("BookmarkName") > -1 Then

                        For Each bookmarkElement As IParagraphContent In bookmark.Content

                            If TypeOf bookmarkElement Is Text Then

                                Dim text As Text = DirectCast(bookmarkElement, Text)
                                text.Value = "New Bookmark text"

                            End If
                        Next

                    End If
                ElseIf TypeOf paragraphElement Is BookmarkStart Then

                    Dim bookmarkStart As BookmarkStart = DirectCast(paragraphElement, BookmarkStart)

                    For Each bookmarkElement As IParagraphContent In bookmarkStart.Content
                        If TypeOf bookmarkElement Is Text Then

                            Dim text As Text = DirectCast(bookmarkElement, Text)
                            text.Value = "New Bookmark text"

                        End If
                    Next

                End If
            Next
        Next

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
