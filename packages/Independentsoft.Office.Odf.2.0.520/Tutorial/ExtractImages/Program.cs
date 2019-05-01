using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            IList<Image> images = doc.GetImages();

            for (int i = 0; i < images.Count; i++)
            {
                images[i].Save("c:\\test\\" + images[i].FileName, true);
            }
        }
    }
}
