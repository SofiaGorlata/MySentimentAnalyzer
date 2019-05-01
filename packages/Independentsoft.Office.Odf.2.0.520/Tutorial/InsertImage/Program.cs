using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;
using Independentsoft.Office.Odf.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            Image image1 = new Image("c:\\test\\image.gif");

            Frame frame1 = new Frame();
            frame1.Width = new Size(6.67, Unit.Inch); //640 pixels
            frame1.Height = new Size(5, Unit.Inch); //480 pixels
            frame1.Add(image1);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add("Below is an image:");

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(frame1);

            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
