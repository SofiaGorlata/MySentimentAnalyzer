using System;
using System.Drawing;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();

            SectionColumn column1 = new SectionColumn();
            column1.RelativeWidth = 32767;
            column1.LeftSpace = new Independentsoft.Office.Odf.Size(0, Unit.Inch);
            column1.RightSpace = new Independentsoft.Office.Odf.Size(0, Unit.Inch);

            SectionColumn column2 = new SectionColumn();
            column2.RelativeWidth = 32767;
            column2.LeftSpace = new Independentsoft.Office.Odf.Size(0, Unit.Inch);
            column2.RightSpace = new Independentsoft.Office.Odf.Size(0, Unit.Inch);

            SectionStyle sectionStyle1 = new SectionStyle("Style1");
            sectionStyle1.Columns.Add(column1);
            sectionStyle1.Columns.Add(column2);

            SectionStyle sectionStyle2 = new SectionStyle("Style2");
            sectionStyle2.BackgroundColor = "#FFFF00"; //yellow

            doc.AutomaticStyles.Styles.Add(sectionStyle1);
            doc.AutomaticStyles.Styles.Add(sectionStyle2);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add("Text in the first section.");

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add("Text in the second section.");

            Paragraph emptyParagraph = new Paragraph();

            Section section1 = new Section();
            section1.Name = "Section1";
            section1.Style = "Style1";
            section1.Add(paragraph1);
            section1.Add(paragraph1);
            section1.Add(paragraph1);
            section1.Add(emptyParagraph);
            section1.Add(emptyParagraph);
            section1.Add(paragraph1);

            Section section2 = new Section();
            section2.Name = "Section2";
            section2.Style = "Style2";
            section2.Add(paragraph2);
            section2.Add(paragraph2);
            section2.Add(paragraph2);
            section2.Add(paragraph2);
            section2.Add(paragraph2);
            section2.Add(paragraph2);

            doc.Body.Add(section1);
            doc.Body.Add(section2);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
