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

            NumberLevelStyle numberLevelStyle1 = new NumberLevelStyle();
            numberLevelStyle1.Level = 1;
            numberLevelStyle1.SuffixCharacter = ")";
            numberLevelStyle1.NumberFormat = "1";
            numberLevelStyle1.ListLevelProperties.StartIndent = new Size(0.25, Unit.Inch);
            numberLevelStyle1.ListLevelProperties.MinimumLabelWidth = new Size(0.25, Unit.Inch);

            BulletLevelStyle bulletLevelStyle1 = new BulletLevelStyle();
            bulletLevelStyle1.Level = 1;
            bulletLevelStyle1.SuffixCharacter = ".";
            bulletLevelStyle1.BulletCharacter = "●";
            bulletLevelStyle1.ListLevelProperties.StartIndent = new Size(0.25, Unit.Inch);
            bulletLevelStyle1.ListLevelProperties.MinimumLabelWidth = new Size(0.25, Unit.Inch);

            ListStyle listStyle1 = new ListStyle("L1");
            listStyle1.Styles.Add(numberLevelStyle1);

            ListStyle listStyle2 = new ListStyle("L2");
            listStyle2.Styles.Add(bulletLevelStyle1);

            ParagraphStyle paragraphStyle1 = new ParagraphStyle("P1");
            paragraphStyle1.ListStyle = "L1";

            ParagraphStyle paragraphStyle2 = new ParagraphStyle("P2");
            paragraphStyle2.ListStyle = "L2";

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Style = "P1";
            paragraph1.Add("First");

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Style = "P1";
            paragraph2.Add("Second");

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Style = "P1";
            paragraph3.Add("Third");

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Style = "P2";
            paragraph4.Add("First");

            Paragraph paragraph5 = new Paragraph();
            paragraph5.Style = "P2";
            paragraph5.Add("Second");

            Paragraph paragraph6 = new Paragraph();
            paragraph6.Style = "P2";
            paragraph6.Add("Third");

            ListItem item11 = new ListItem();
            item11.Content.Add(paragraph1);

            ListItem item12 = new ListItem();
            item12.Content.Add(paragraph2);

            ListItem item13 = new ListItem();
            item13.Content.Add(paragraph3);

            List list1 = new List();
            list1.Style = "L1";
            list1.Add(item11);
            list1.Add(item12);
            list1.Add(item13);

            ListItem item21 = new ListItem();
            item21.Content.Add(paragraph4);

            ListItem item22 = new ListItem();
            item22.Content.Add(paragraph5);

            ListItem item23 = new ListItem();
            item23.Content.Add(paragraph6);

            List list2 = new List();
            list2.Style = "L2";
            list2.Add(item21);
            list2.Add(item22);
            list2.Add(item23);

            doc.AutomaticStyles.Styles.Add(listStyle1);
            doc.AutomaticStyles.Styles.Add(listStyle2);
            doc.AutomaticStyles.Styles.Add(paragraphStyle1);
            doc.AutomaticStyles.Styles.Add(paragraphStyle2);

            doc.Body.Add(list1);
            doc.Body.Add(new Paragraph());
            doc.Body.Add(list2);

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
