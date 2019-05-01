Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles
Imports Independentsoft.Office.Odf.Drawing

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument

        Dim image1 As Image = New Image("c:\test\image.gif")

        Dim frame1 As Frame = New Frame
        frame1.Width = New Size(6.67, Unit.Inch) '640 pixels
        frame1.Height = New Size(5, Unit.Inch) '480 pixels
        frame1.Add(image1)

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add("Below is an image:")

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Add(frame1)

        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
