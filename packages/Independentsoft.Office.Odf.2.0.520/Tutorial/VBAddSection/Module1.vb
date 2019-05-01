Imports System
Imports System.Drawing
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim column1 As SectionColumn = New SectionColumn
        column1.RelativeWidth = 32767
        column1.LeftSpace = New Independentsoft.Office.Odf.Size(0, Unit.Inch)
        column1.RightSpace = New Independentsoft.Office.Odf.Size(0, Unit.Inch)

        Dim column2 As SectionColumn = New SectionColumn
        column2.RelativeWidth = 32767
        column2.LeftSpace = New Independentsoft.Office.Odf.Size(0, Unit.Inch)
        column2.RightSpace = New Independentsoft.Office.Odf.Size(0, Unit.Inch)

        Dim sectionStyle1 As SectionStyle = New SectionStyle("Style1")
        sectionStyle1.Columns.Add(column1)
        sectionStyle1.Columns.Add(column2)

        Dim sectionStyle2 As SectionStyle = New SectionStyle("Style2")
        sectionStyle2.BackgroundColor = "#FFFF00" ''yellow
        doc.AutomaticStyles.Styles.Add(sectionStyle1)
        doc.AutomaticStyles.Styles.Add(sectionStyle2)

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add("Text in the first section.")

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Add("Text in the second section.")

        Dim emptyParagraph As Paragraph = New Paragraph

        Dim section1 As Section = New Section
        section1.Name = "Section1"
        section1.Style = "Style1"
        section1.Add(paragraph1)
        section1.Add(paragraph1)
        section1.Add(paragraph1)
        section1.Add(emptyParagraph)
        section1.Add(emptyParagraph)
        section1.Add(paragraph1)

        Dim section2 As Section = New Section
        section2.Name = "Section2"
        section2.Style = "Style2"
        section2.Add(paragraph2)
        section2.Add(paragraph2)
        section2.Add(paragraph2)
        section2.Add(paragraph2)
        section2.Add(paragraph2)
        section2.Add(paragraph2)

        doc.Body.Add(section1)
        doc.Body.Add(section2)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
