using System;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    /// <summary>
    /// Set text font, underline and bold. You have to create style and assign style to paragraph.
    /// </summary>
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

            ParagraphStyle style1 = new ParagraphStyle("MyStyle1");
            style1.TextProperties.Font = "Arial";
            style1.TextProperties.FontSize = new Size(12, Unit.Point);
            style1.TextProperties.FontWeight = FontWeight.Bold;
            style1.TextProperties.UnderlineType = UnderlineType.Single;

            doc.AutomaticStyles.Styles.Add(style1);

            Paragraph p1 = new Paragraph();
            p1.Add("Hello");
            p1.Style = "MyStyle1";

            Paragraph p2 = new Paragraph();
            p2.Add("World");

            doc.Body.Add(p1);
            doc.Body.Add(p2);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
