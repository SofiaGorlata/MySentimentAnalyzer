Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument

        Dim pageLayout1 As New PageLayout()
        pageLayout1.Name = "Layout1"
        pageLayout1.PageLayoutProperties.PrintOrientation = PrintOrientation.Landscape
        pageLayout1.PageLayoutProperties.PageHeight = New Size(11.69, Unit.Inch)
        pageLayout1.PageLayoutProperties.PageWidth = New Size(8.26, Unit.Inch)

        doc.CommonStyles.AutomaticStyles = New AutomaticStyles()
        doc.CommonStyles.AutomaticStyles.PageLayouts.Add(pageLayout1)

        Dim masterPage1 As New MasterPage()
        masterPage1.Name = "Standard"
        masterPage1.PageLayout = "Layout1"

        doc.CommonStyles.MasterStyles = New MasterStyles()
        doc.CommonStyles.MasterStyles.MasterPages.Add(masterPage1)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
