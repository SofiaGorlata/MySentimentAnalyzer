using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            TableStyle style1 = new TableStyle("NewTableStyle");
            style1.BackgroundColor = "#FFFF00"; //yellow

            doc.AutomaticStyles.Styles.Add(style1);

            IList<Table> tables = doc.GetTables();

            for (int i = 0; i < tables.Count; i++)
            {
                tables[i].Style = "NewTableStyle";
            }

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}
