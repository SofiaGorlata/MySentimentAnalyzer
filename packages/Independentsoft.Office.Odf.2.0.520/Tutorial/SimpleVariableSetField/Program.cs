using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Fields;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            IList<Paragraph> paragraphs = doc.GetParagraphs();

            for (int i = 0; i < paragraphs.Count; i++)
            {
                for (int j = paragraphs[i].Content.Count - 1; j >= 0; j--)
                {
                    if (paragraphs[i].Content[j] is SimpleVariableSetField)
                    {
                        SimpleVariableSetField field = (SimpleVariableSetField)paragraphs[i].Content[j];

                        if (field.Name == "CustomerID")
                        {
                            field.Value = "12345";
                        }
                    }
                }
            }

            doc.Save("c:\\test\\output.odt", true);
        }
    }
}

