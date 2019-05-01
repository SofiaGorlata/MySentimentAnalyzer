using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            string text = doc.ToText();
           
            Console.WriteLine(text);
            Console.Read();
        }
    }
}
