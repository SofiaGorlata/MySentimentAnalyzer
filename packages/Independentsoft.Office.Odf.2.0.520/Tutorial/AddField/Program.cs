using System;
using System.Drawing;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Fields;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            Date dateField = new Independentsoft.Office.Odf.Fields.Date();
            FileName fileNameField = new FileName();
            
            Paragraph p1 = new Paragraph();
            p1.Add("File name is: ");
            p1.Add(fileNameField);

            Paragraph p2 = new Paragraph();
            p2.Add("Current date is: ");
            p2.Add(dateField);
                     
            doc.Body.Add(p1);
            doc.Body.Add(p2);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
