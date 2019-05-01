using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            IList<Paragraph> paragraphs = doc.GetParagraphs();

            for (int i = 0; i < paragraphs.Count; i++)
            {
                foreach (IParagraphContent paragraphElement in paragraphs[i].Content)
                {
                    if (paragraphElement is Bookmark)
                    {
                        Bookmark bookmark = (Bookmark)paragraphElement;

                        if (bookmark.Name.IndexOf("BookmarkName") > -1)
                        {
                            foreach (IParagraphContent bookmarkElement in bookmark.Content)
                            {
                                if (bookmarkElement is Text)
                                {
                                    Text text = (Text)bookmarkElement;

                                    text.Value = "New Bookmark text";
                                }
                            }
                        }
                    }
                    else if (paragraphElement is BookmarkStart)
                    {
                        BookmarkStart bookmarkStart = (BookmarkStart)paragraphElement;

                        foreach (IParagraphContent bookmarkElement in bookmarkStart.Content)
                        {
                            if (bookmarkElement is Text)
                            {
                                Text text = (Text)bookmarkElement;

                                text.Value = "New Bookmark text";
                            }
                        }
                    }
                }
            }

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
