using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordCount = 0;
            string[] separator = new string[] { " " };

            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            IList<Text> texts = doc.GetTexts();

            for (int i = 0; i < texts.Count; i++)
            {
                string[] words = texts[i].Value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                wordCount += words.Length;
            }

            IList<Paragraph> paragraphs = doc.GetParagraphs();

            int emptyParagraphCount = 0;

            for (int j = 0; j < paragraphs.Count; j++)
            {
                if(paragraphs[j].Content.Count == 0)
                {
                    emptyParagraphCount++;
                }
            }

            Console.WriteLine("Paragraphs=" + paragraphs.Count);
            Console.WriteLine("Empty paragraphs=" + emptyParagraphCount);
            Console.WriteLine("Words=" + wordCount);

            Console.Read();
        }
    }
}
