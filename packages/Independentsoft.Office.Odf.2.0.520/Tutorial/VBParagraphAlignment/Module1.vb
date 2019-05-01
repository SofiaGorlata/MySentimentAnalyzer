Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim style1 As ParagraphStyle = New ParagraphStyle("Style1")
        style1.ParagraphProperties.TextAlignment = TextAlignment.Center

        Dim style2 As ParagraphStyle = New ParagraphStyle("Style2")
        style2.ParagraphProperties.TextAlignment = TextAlignment.Left

        Dim style3 As ParagraphStyle = New ParagraphStyle("Style3")
        style3.ParagraphProperties.TextAlignment = TextAlignment.Right

        doc.AutomaticStyles.Styles.Add(style1)
        doc.AutomaticStyles.Styles.Add(style2)
        doc.AutomaticStyles.Styles.Add(style3)

        Dim p1 As Paragraph = New Paragraph()
        p1.Add("Center alignment")
        p1.Style = "Style1"

        Dim p2 As Paragraph = New Paragraph()
        p2.Add("Left alignment")
        p2.Style = "Style2"

        Dim p3 As Paragraph = New Paragraph()
        p3.Add("Right alignment")
        p3.Style = "Style3"

        doc.Body.Add(p1)
        doc.Body.Add(New Paragraph()) ''empty paragraph
        doc.Body.Add(p2)
        doc.Body.Add(New Paragraph()) ''empty paragraph
        doc.Body.Add(p3)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
