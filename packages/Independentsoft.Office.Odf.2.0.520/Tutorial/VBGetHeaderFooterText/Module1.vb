Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument("c:\\test\\input.odt")

        Dim masterPages As IList(Of MasterPage) = doc.CommonStyles.MasterStyles.MasterPages

        For Each masterPage As MasterPage In masterPages

            Dim header As Header = masterPage.Header
            Dim footer As Footer = masterPage.Footer

            If header IsNot Nothing Then
                Dim headerContent As IList(Of IHeaderFooterContent) = header.Content

                For Each headerContentElement As IHeaderFooterContent In headerContent
                    If TypeOf headerContentElement Is Paragraph Then

                        Dim paragraph As Paragraph = DirectCast(headerContentElement, Paragraph)

                        For j As Integer = 0 To paragraph.Content.Count - 1
                            If TypeOf paragraph.Content(j) Is AttributedText Then

                                Dim attributedText As AttributedText = DirectCast(paragraph.Content(j), AttributedText)

                                For a As Integer = 0 To attributedText.Content.Count - 1
                                    If TypeOf attributedText.Content(a) Is Text Then
                                        Dim text As Text = DirectCast(attributedText.Content(a), Text)
                                        Console.WriteLine(text.Value)
                                    End If
                                Next
                            ElseIf TypeOf paragraph.Content(j) Is Text Then
                                Dim text As Text = DirectCast(paragraph.Content(j), Text)
                                Console.WriteLine(text.Value)
                            End If
                        Next

                    End If
                Next
            End If

            If footer IsNot Nothing Then
                Dim footerContent As IList(Of IHeaderFooterContent) = footer.Content

                For Each footerContentElement As IHeaderFooterContent In footerContent
                    If TypeOf footerContentElement Is Paragraph Then

                        Dim paragraph As Paragraph = DirectCast(footerContentElement, Paragraph)

                        For j As Integer = 0 To paragraph.Content.Count - 1
                            If TypeOf paragraph.Content(j) Is AttributedText Then

                                Dim attributedText As AttributedText = DirectCast(paragraph.Content(j), AttributedText)

                                For a As Integer = 0 To attributedText.Content.Count - 1
                                    If TypeOf attributedText.Content(a) Is Text Then
                                        Dim text As Text = DirectCast(attributedText.Content(a), Text)
                                        Console.WriteLine(text.Value)
                                    End If
                                Next
                            ElseIf TypeOf paragraph.Content(j) Is Text Then
                                Dim text As Text = DirectCast(paragraph.Content(j), Text)
                                Console.WriteLine(text.Value)
                            End If
                        Next

                    End If
                Next
            End If
        Next

        Console.WriteLine("Pess any key to close.")
        Console.Read()

    End Sub
End Module
