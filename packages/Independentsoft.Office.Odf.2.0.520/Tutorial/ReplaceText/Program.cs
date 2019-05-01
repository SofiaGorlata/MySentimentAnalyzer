using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            doc.Replace("John Smith", "Mary Rose");

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
