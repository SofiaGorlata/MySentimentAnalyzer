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

                        Console.WriteLine("Bookmark: " + bookmark.Name);
                    }
                    else if (paragraphElement is BookmarkStart)
                    {
                        BookmarkStart bookmarkStart = (BookmarkStart)paragraphElement;

                        Console.WriteLine("BookmarkStart: " + bookmarkStart.Name);
                    }
                    else if (paragraphElement is BookmarkEnd)
                    {
                        BookmarkEnd bookmarkEnd = (BookmarkEnd)paragraphElement;

                        Console.WriteLine("BookmarkEnd: " + bookmarkEnd.Name);
                    }
                }
            }

            Console.WriteLine("Pess any key to close.");
            Console.Read();
        }
    }
}
