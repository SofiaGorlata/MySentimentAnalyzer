using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            ParagraphStyle style1 = new ParagraphStyle("Style1");
            style1.ParagraphProperties.TextAlignment = TextAlignment.Center;

            ParagraphStyle style2 = new ParagraphStyle("Style2");
            style2.ParagraphProperties.TextAlignment = TextAlignment.Left;

            ParagraphStyle style3 = new ParagraphStyle("Style3");
            style3.ParagraphProperties.TextAlignment = TextAlignment.Right;

            doc.AutomaticStyles.Styles.Add(style1);
            doc.AutomaticStyles.Styles.Add(style2);
            doc.AutomaticStyles.Styles.Add(style3);

            Paragraph p1 = new Paragraph();
            p1.Add("Center alignment");
            p1.Style = "Style1";

            Paragraph p2 = new Paragraph();
            p2.Add("Left alignment");
            p2.Style = "Style2";

            Paragraph p3 = new Paragraph();
            p3.Add("Right alignment");
            p3.Style = "Style3";

            doc.Body.Add(p1);
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(p2);
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(p3);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
