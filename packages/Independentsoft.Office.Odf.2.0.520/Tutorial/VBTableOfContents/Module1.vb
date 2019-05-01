Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New TextDocument()

        Dim tocParagraph As New Paragraph()
        tocParagraph.Add("Table of Contents")

        Dim p1 As New Paragraph()
        p1.Add("First chapter")
        p1.AddTab()
        p1.Add("2")

        Dim p2 As New Paragraph()
        p2.Add("Second chapter")
        p2.AddTab()
        p2.Add("3")

        Dim indexTitle As New IndexTitle()
        indexTitle.Content.Add(tocParagraph)

        Dim indexBody As New IndexBody()
        indexBody.Content.Add(indexTitle)
        indexBody.Content.Add(New Paragraph())
        'empty paragraph
        indexBody.Content.Add(p1)
        indexBody.Content.Add(p2)

        Dim indexTitleTemplate As New IndexTitleTemplate()
        indexTitleTemplate.Value = "Table of Contents"

        Dim tabStopIndexEntry As New TabStopIndexEntry()
        tabStopIndexEntry.LeaderCharacter = "."
        tabStopIndexEntry.Type = TabStopIndexEntryType.Right

        Dim entry1 As New TableOfContentsEntryTemplate()
        entry1.OutlineLevel = 1
        entry1.Content.Add(New ChapterIndexEntry())
        entry1.Content.Add(New TextIndexEntry())
        entry1.Content.Add(tabStopIndexEntry)
        entry1.Content.Add(New PageNumberIndexEntry())

        Dim tocSource As New TableOfContentsSource()
        tocSource.OutlineLevel = 10
        tocSource.IndexTitleTemplate = indexTitleTemplate
        tocSource.EntryTemplates.Add(entry1)

        Dim toc As New TableOfContents()
        toc.IsProtected = True
        toc.IndexBody = indexBody
        toc.Source = tocSource

        Dim heading1 As New Heading()
        heading1.Level = 1
        heading1.Add("First chapter")

        Dim heading2 As New Heading()
        heading2.Level = 1
        heading2.Add("Second chapter")

        Dim style1 As New ParagraphStyle("MyStyle")
        style1.ParagraphProperties.BreakAfter = Break.Page

        Dim pageBreakParagraph As New Paragraph()
        pageBreakParagraph.Style = "MyStyle"

        doc.AutomaticStyles.Styles.Add(style1)

        doc.Body.Add(toc)
        doc.Body.Add(pageBreakParagraph)
        doc.Body.Add(heading1)
        doc.Body.Add(pageBreakParagraph)
        doc.Body.Add(heading2)


        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
