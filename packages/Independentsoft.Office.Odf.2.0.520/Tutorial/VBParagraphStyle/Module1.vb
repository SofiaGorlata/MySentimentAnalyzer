Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

''' <summary>
''' Set text font, underline and bold. You have to create style and assign style to paragraph.
''' </summary>
''' <remarks></remarks>
Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument()

        Dim arial As Font = New Font()
        arial.Name = "Arial"
        arial.Family = "Arial"
        arial.GenericFontFamily = GenericFontFamily.Swiss
        arial.Pitch = FontPitch.Variable

        doc.Fonts.Add(arial)

        Dim style1 As ParagraphStyle = New ParagraphStyle("MyStyle1")
        style1.TextProperties.Font = "Arial"
        style1.TextProperties.FontSize = New Size(12, Unit.Point)
        style1.TextProperties.FontWeight = FontWeight.Bold
        style1.TextProperties.UnderlineType = UnderlineType.Single

        doc.AutomaticStyles.Styles.Add(style1)

        Dim p1 As Paragraph = New Paragraph()
        p1.Add("Hello")
        p1.Style = "MyStyle1"

        Dim p2 As Paragraph = New Paragraph()
        p2.Add("World")

        doc.Body.Add(p1)
        doc.Body.Add(p2)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
