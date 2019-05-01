using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            Hyperlink link = new Hyperlink();
            link.Add("Independentsoft");
            link.Location = "http://www.independentsoft.com";

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(link);

            doc.Body.Add(paragraph1);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
