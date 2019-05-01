using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            Paragraph tocParagraph = new Paragraph();
            tocParagraph.Add("Table of Contents");

            Paragraph p1 = new Paragraph();
            p1.Add("First chapter");
            p1.AddTab();
            p1.Add("2");

            Paragraph p2 = new Paragraph();
            p2.Add("Second chapter");
            p2.AddTab();
            p2.Add("3");

            IndexTitle indexTitle = new IndexTitle();
            indexTitle.Content.Add(tocParagraph);

            IndexBody indexBody = new IndexBody();
            indexBody.Content.Add(indexTitle);
            indexBody.Content.Add(new Paragraph()); //empty paragraph
            indexBody.Content.Add(p1);
            indexBody.Content.Add(p2);

            IndexTitleTemplate indexTitleTemplate = new IndexTitleTemplate();
            indexTitleTemplate.Value = "Table of Contents";

            TabStopIndexEntry tabStopIndexEntry = new TabStopIndexEntry();
            tabStopIndexEntry.LeaderCharacter = ".";
            tabStopIndexEntry.Type = TabStopIndexEntryType.Right;

            TableOfContentsEntryTemplate entry1 = new TableOfContentsEntryTemplate();
            entry1.OutlineLevel = 1;
            entry1.Content.Add(new ChapterIndexEntry());
            entry1.Content.Add(new TextIndexEntry());
            entry1.Content.Add(tabStopIndexEntry);
            entry1.Content.Add(new PageNumberIndexEntry());

            TableOfContentsSource tocSource = new TableOfContentsSource();
            tocSource.OutlineLevel = 10;
            tocSource.IndexTitleTemplate = indexTitleTemplate;
            tocSource.EntryTemplates.Add(entry1);

            TableOfContents toc = new TableOfContents();
            toc.IsProtected = true;
            toc.IndexBody = indexBody;
            toc.Source = tocSource;

            Heading heading1 = new Heading();
            heading1.Level = 1;
            heading1.Add("First chapter");

            Heading heading2 = new Heading();
            heading2.Level = 1;
            heading2.Add("Second chapter");

            ParagraphStyle style1 = new ParagraphStyle("MyStyle");
            style1.ParagraphProperties.BreakAfter = Break.Page;

            Paragraph pageBreakParagraph = new Paragraph();
            pageBreakParagraph.Style = "MyStyle";

            doc.AutomaticStyles.Styles.Add(style1);

            doc.Body.Add(toc);
            doc.Body.Add(pageBreakParagraph);
            doc.Body.Add(heading1);
            doc.Body.Add(pageBreakParagraph);
            doc.Body.Add(heading2);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
