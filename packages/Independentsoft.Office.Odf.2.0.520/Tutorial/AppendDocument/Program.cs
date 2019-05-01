using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument first = new TextDocument("c:\\test\\first.odt");
            TextDocument second = new TextDocument("c:\\test\\second.odt");

            foreach (ITextContent bodyElement in second.Body.Content)
            {
                first.Body.Add(bodyElement);
            }

            first.Save("c:\\test\\output.odt", true);
        }
    }
}
