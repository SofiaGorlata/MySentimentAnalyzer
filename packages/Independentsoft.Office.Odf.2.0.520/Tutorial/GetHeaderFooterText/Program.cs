using System;
using System.Collections.Generic;
using Independentsoft.Office.Odf;
using Independentsoft.Office.Odf.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument("c:\\test\\input.odt");

            IList<MasterPage> masterPages = doc.CommonStyles.MasterStyles.MasterPages;

            foreach (MasterPage masterPage in masterPages)
            {
                Header header = masterPage.Header;
                Footer footer = masterPage.Footer;

                if (header != null)
                {
                    IList<IHeaderFooterContent> headerContent = header.Content;

                    foreach (IHeaderFooterContent headerContentElement in headerContent)
                    {
                        if (headerContentElement is Paragraph)
                        {
                            Paragraph paragraph = (Paragraph)headerContentElement;

                            for (int j = 0; j < paragraph.Content.Count; j++)
                            {
                                if (paragraph.Content[j] is AttributedText)
                                {
                                    AttributedText attributedText = (AttributedText)paragraph.Content[j];

                                    for (int a = 0; a < attributedText.Content.Count; a++)
                                    {
                                        if (attributedText.Content[a] is Text)
                                        {
                                            Text text = (Text)attributedText.Content[a];
                                            Console.WriteLine(text.Value);
                                        }
                                    }
                                }
                                else if (paragraph.Content[j] is Text)
                                {
                                    Text text = (Text)paragraph.Content[j];
                                    Console.WriteLine(text.Value);
                                }
                            }
                        }
                    }
                }

                if (footer != null)
                {
                    IList<IHeaderFooterContent> footerContent = footer.Content;

                    foreach (IHeaderFooterContent footerContentElement in footerContent)
                    {
                        if (footerContentElement is Paragraph)
                        {
                            Paragraph paragraph = (Paragraph)footerContentElement;

                            for (int j = 0; j < paragraph.Content.Count; j++)
                            {
                                if (paragraph.Content[j] is AttributedText)
                                {
                                    AttributedText attributedText = (AttributedText)paragraph.Content[j];

                                    for (int a = 0; a < attributedText.Content.Count; a++)
                                    {
                                        if (attributedText.Content[a] is Text)
                                        {
                                            Text text = (Text)attributedText.Content[a];
                                            Console.WriteLine(text.Value);
                                        }
                                    }
                                }
                                else if (paragraph.Content[j] is Text)
                                {
                                    Text text = (Text)paragraph.Content[j];
                                    Console.WriteLine(text.Value);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Pess any key to close.");
            Console.Read();
        }
    }
}
