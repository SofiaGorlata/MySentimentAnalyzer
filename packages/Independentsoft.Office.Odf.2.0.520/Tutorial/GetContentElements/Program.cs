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

            IList<IContentElement> elements = doc.GetContentElements();

            foreach(IContentElement element in elements)
            {
                if (element is ListItem)
                {
                    ListItem item = (ListItem)element;

                    IList<IContentElement> itemElements = item.GetContentElements();

                    Console.WriteLine("");
                    Console.Write("-");

                    foreach (IContentElement itemElement in itemElements)
                    {
                        if (itemElement is Text)
                        {
                            Text text = (Text)itemElement;
                            Console.Write(text.Value);
                        }
                    }
                }

            }

            Console.Read();
        }
    }
}
