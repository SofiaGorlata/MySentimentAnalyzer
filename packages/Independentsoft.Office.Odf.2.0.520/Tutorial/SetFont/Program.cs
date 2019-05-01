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

            Font arial = new Font();
            arial.Name = "Arial";
            arial.Family = "Arial";
            arial.GenericFontFamily = GenericFontFamily.Swiss;
            arial.Pitch = FontPitch.Variable;

            doc.Fonts.Add(arial);

            ParagraphStyle style1 = new ParagraphStyle("P100");
            style1.TextProperties.Font = "Arial";
            style1.TextProperties.FontSize = new Size(28, Unit.Point);
            style1.TextProperties.FontWeight = FontWeight.Bold;

            doc.AutomaticStyles.Styles.Add(style1);

            Paragraph p1 = new Paragraph();
            p1.Add("Hello World");
            p1.Style = "P100";

            doc.Body.Add(p1);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
