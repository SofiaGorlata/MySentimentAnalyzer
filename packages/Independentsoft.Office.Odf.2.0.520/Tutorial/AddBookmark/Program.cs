using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Fields;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            Paragraph p1 = new Paragraph();
            p1.Add("Hello World");

            doc.Body.Add(p1);

            Text bookmarkText = new Text("Some text here");

            BookmarkStart bookmarkStart = new BookmarkStart();
            bookmarkStart.Name = "BookmarkName";
            bookmarkStart.Add(bookmarkText);

            BookmarkEnd bookmarkEnd = new BookmarkEnd();
            bookmarkEnd.Name = "BookmarkName";

            p1.Add(bookmarkStart);
            p1.Add(bookmarkEnd);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
