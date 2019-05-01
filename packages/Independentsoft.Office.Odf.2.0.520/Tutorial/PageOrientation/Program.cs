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
            
            PageLayout pageLayout1 = new PageLayout();
            pageLayout1.Name = "Layout1";
            pageLayout1.PageLayoutProperties.PrintOrientation = PrintOrientation.Landscape;
            pageLayout1.PageLayoutProperties.PageHeight = new Size(11.69, Unit.Inch);
            pageLayout1.PageLayoutProperties.PageWidth = new Size(8.26, Unit.Inch);

            doc.CommonStyles.AutomaticStyles = new AutomaticStyles();
            doc.CommonStyles.AutomaticStyles.PageLayouts.Add(pageLayout1);

            MasterPage masterPage1 = new MasterPage();
            masterPage1.Name = "Standard";
            masterPage1.PageLayout = "Layout1";

            doc.CommonStyles.MasterStyles = new MasterStyles();
            doc.CommonStyles.MasterStyles.MasterPages.Add(masterPage1);


            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
