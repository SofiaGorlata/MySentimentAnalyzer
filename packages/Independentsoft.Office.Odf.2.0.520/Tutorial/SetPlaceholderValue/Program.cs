using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Fields;

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
                    if (paragraphElement is Placeholder)
                    {
                        Placeholder placeholder = (Placeholder)paragraphElement;

                        if (placeholder.Value == "<PhoneNumber>")
                        {
                            placeholder.Value = "<12345678>";
                        }
                    }
                }
            }

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
