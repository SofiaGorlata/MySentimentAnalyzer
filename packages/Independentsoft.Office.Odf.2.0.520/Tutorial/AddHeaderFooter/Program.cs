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

            Paragraph headerParagraph = new Paragraph();
            headerParagraph.Add("Header text");

            Header header1 = new Header();
            header1.Content.Add(headerParagraph);

            Paragraph footerParagraph = new Paragraph();
            footerParagraph.Add("Footer text");

            Footer footer1 = new Footer();
            footer1.Content.Add(footerParagraph);

            HeaderStyle headerStyle1 = new HeaderStyle();
            headerStyle1.BottomMargin = new Size(0.1965, Unit.Inch);

            FooterStyle footerStyle1 = new FooterStyle();
            footerStyle1.TopMargin = new Size(0.1965, Unit.Inch);

            PageLayout pageLayout1 = new PageLayout();
            pageLayout1.Name = "Layout1";
            pageLayout1.HeaderStyle = headerStyle1;
            pageLayout1.FooterStyle = footerStyle1;

            doc.CommonStyles.AutomaticStyles = new AutomaticStyles();
            doc.CommonStyles.AutomaticStyles.PageLayouts.Add(pageLayout1);

            MasterPage masterPage1 = new MasterPage();
            masterPage1.Name = "Standard";
            masterPage1.PageLayout = "Layout1";
            masterPage1.Header = header1;
            masterPage1.Footer = footer1;

            doc.CommonStyles.MasterStyles = new MasterStyles();
            doc.CommonStyles.MasterStyles.MasterPages.Add(masterPage1);

            doc.Save("c:\\test\\output.odt", true);
        
        }
    }
}
