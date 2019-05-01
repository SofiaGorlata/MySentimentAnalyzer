Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim headerParagraph As Paragraph = New Paragraph
        headerParagraph.Add("Header text")

        Dim header1 As Header = New Header
        header1.Content.Add(headerParagraph)

        Dim footerParagraph As Paragraph = New Paragraph
        footerParagraph.Add("Footer text")

        Dim footer1 As Footer = New Footer
        footer1.Content.Add(footerParagraph)

        Dim headerStyle1 As HeaderStyle = New HeaderStyle
        headerStyle1.BottomMargin = New Size(0.1965, Unit.Inch)

        Dim footerStyle1 As FooterStyle = New FooterStyle
        footerStyle1.TopMargin = New Size(0.1965, Unit.Inch)

        Dim pageLayout1 As PageLayout = New PageLayout
        pageLayout1.Name = "Layout1"
        pageLayout1.HeaderStyle = headerStyle1
        pageLayout1.FooterStyle = footerStyle1

        doc.CommonStyles.AutomaticStyles = New AutomaticStyles
        doc.CommonStyles.AutomaticStyles.PageLayouts.Add(pageLayout1)

        Dim masterPage1 As MasterPage = New MasterPage
        masterPage1.Name = "Standard"
        masterPage1.PageLayout = "Layout1"
        masterPage1.Header = header1
        masterPage1.Footer = footer1

        doc.CommonStyles.MasterStyles = New MasterStyles
        doc.CommonStyles.MasterStyles.MasterPages.Add(masterPage1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
