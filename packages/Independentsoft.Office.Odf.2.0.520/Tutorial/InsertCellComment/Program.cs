using System;
using Independentsoft.Office.Odf;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Spreadsheet spreadsheet = new Spreadsheet();

            Annotation annotation1 = new Annotation();
            annotation1.Creator = "John";
            annotation1.CreationDate = DateTime.Now;

            Paragraph commentParagraph = new Paragraph();
            commentParagraph.Add("My comment text.");

            annotation1.Content.Add(commentParagraph);

            Cell a1 = new Cell(100);
            a1.Content.Add(annotation1);
            
            Table sheet1 = new Table();
            sheet1["A1"] = a1;

            spreadsheet.Tables.Add(sheet1);

            spreadsheet.Save("c:\\test\\output.ods", true);
        }
    }
}