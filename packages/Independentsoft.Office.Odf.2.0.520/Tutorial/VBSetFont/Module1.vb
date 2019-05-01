Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument

        Dim arial As Font = New Font
        arial.Name = "Arial"
        arial.Family = "Arial"
        arial.GenericFontFamily = GenericFontFamily.Swiss
        arial.Pitch = FontPitch.Variable

        doc.Fonts.Add(arial)

        Dim style1 As ParagraphStyle = New ParagraphStyle("P1")
        style1.TextProperties.Font = "Arial"
        style1.TextProperties.FontSize = New Size(20, Unit.Point)
        style1.TextProperties.FontWeight = FontWeight.Bold

        doc.AutomaticStyles.Styles.Add(style1)

        Dim p1 As Paragraph = New Paragraph
        p1.Add("Hello World")
        p1.Style = "P1"

        doc.Body.Add(p1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
