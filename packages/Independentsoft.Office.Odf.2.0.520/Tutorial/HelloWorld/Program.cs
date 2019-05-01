using System;
using Independentsoft.Office.Odf;

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

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
