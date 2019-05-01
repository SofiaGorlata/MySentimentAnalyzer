using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MySentimentLibraryRegression.Trainer
{
    class Correlation
    {
        public int count;
        public string word;
        public bool isPositive;
        public Correlation(int count, string word, bool isPositive)
        {
            this.count = count;
            this.word = word;
            this.isPositive = isPositive;
        }
    }

    class WordCorrelation
    {
        public double correl;
        public string word;
        public WordCorrelation(double correl, string word)
        {
            this.correl = correl;
            this.word = word;
        }
    }
    class Trainer
    {
        static void Main(string[] args)
        {
            //Get file names
            string[] filePaths = Directory.GetFiles(@"C:\Users\skyrocker\Course Work\Trainer\reviews");
            foreach (var FilePath in filePaths)
            {
                Console.WriteLine(FilePath);
                GenerateXmlFromFile(FilePath);
            }
            GenerateMatrixOfDocuments();
        }

        private static void GenerateMatrixOfDocuments()
        {
            // Достаем текст из XML, выбираем самые часто встречающиеся в положительных и негативных
            var xmlDoc = new XmlDocument();
            string[] filePaths = Directory.GetFiles(@"C:\Users\skyrocker\Course Work\Trainer\xml");
            foreach (string filePath in filePaths)
            {
                xmlDoc.Load(filePath);
                XmlNodeList advantages = xmlDoc.GetElementsByTagName("advantages");
                XmlNodeList disadvantages = xmlDoc.GetElementsByTagName("disadvantages");
                XmlNodeList comments = xmlDoc.GetElementsByTagName("comments");
                XmlNodeList grade = xmlDoc.GetElementsByTagName("grade");
                //Put text to advantages.txt and disadvantages.txt
                StreamWriter fileAdvantages = new StreamWriter("advantages.txt", true);
                fileAdvantages.WriteLine(advantages[0].InnerText + "\n");
                fileAdvantages.Close();
                if (disadvantages.Count != 0)
                {
                    StreamWriter fileDisadvantages = new StreamWriter("disadvantages.txt", true);
                    fileDisadvantages.WriteLine(disadvantages[0].InnerText + "\n");
                    fileDisadvantages.Close();
                }
                if (grade.Count != 0 && comments.Count != 0)
                {
                    if (grade[0].InnerText == "1" || grade[0].InnerText == "2" || grade[0].InnerText == "3")
                    {
                        StreamWriter fileComments = new StreamWriter("disadvantages.txt", true);
                        fileComments.WriteLine(comments[0].InnerText + "\n");
                        fileComments.Close();
                    }
                }
            }

            // Теперь подсчитаем число вхождений слов в файлы
            StreamReader readerAdvantages = new StreamReader("advantages.txt");
            var linesAdvantages = readerAdvantages.ReadToEnd();
            var wordsAdvantages = linesAdvantages.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var groupsAdvantages = wordsAdvantages.GroupBy(w => w);
            StreamWriter writerImportantWords = new StreamWriter("important.txt");
            List<Correlation> correlations = new List<Correlation>(); ; ;
            foreach (var item in groupsAdvantages)
            {
                {
                    writerImportantWords.WriteLine(item.Key + " " + item.Count().ToString() + " positive");
                    correlations.Add(new Correlation(item.Count(), item.Key, true));
                }
            }

            StreamReader readerDisadvantages = new StreamReader("disadvantages.txt");
            var linesDisadvantages = readerDisadvantages.ReadToEnd();
            var wordsDisadvantages = linesDisadvantages.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var groupsDisadvantages = wordsDisadvantages.GroupBy(w => w);
            foreach (var item in groupsDisadvantages)
            {

                {
                    writerImportantWords.WriteLine(item.Key + " " + item.Count().ToString() + " negative");
                    correlations.Add(new Correlation(item.Count(), item.Key, false));
                }
            }
            writerImportantWords.Close();
            List<WordCorrelation> wordsCorrelations = new List<WordCorrelation>();

            for (int i = 0; i < correlations.Count; i++)
            {
                double correlation = 0;
                bool isRepeatedWord = false;
                for (int j = i; j < correlations.Count; j++)
                {
                    if (correlations[i].word == correlations[j].word)
                    {
                        correlation = (Convert.ToDouble(correlations[i].count) - Convert.ToDouble(correlations[j].count)) / Convert.ToDouble(correlations.Count);
                        isRepeatedWord = true;
                    }

                }
                if (isRepeatedWord)
                {
                    wordsCorrelations.Add(new WordCorrelation(correlation, correlations[i].word));
                }
                else
                {
                    if (correlations[i].isPositive)
                    {
                        correlation = (Convert.ToDouble(correlations[i].count)) / (Convert.ToDouble(correlations.Count));
                    }
                    else
                    {
                        correlation = -(Convert.ToDouble(correlations[i].count) * 10) / (Convert.ToDouble(correlations.Count));
                    }
                    wordsCorrelations.Add(new WordCorrelation(correlation, correlations[i].word));
                }
            }
            StreamWriter correlationsWriter = new StreamWriter("correlations.txt");
            foreach (var wordCorrelation in wordsCorrelations)
            {
                if (wordCorrelation.correl >= 0.01 || wordCorrelation.correl < 0)
                    correlationsWriter.WriteLine(wordCorrelation.word + " " + wordCorrelation.correl);
            }
            correlationsWriter.Close();
            Console.ReadLine();
        }

        private static void GenerateXmlFromFile(string fileName)
        {
            Stemmer stemmer = new Stemmer();
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(fileName, Encoding.UTF8);
            var rootNode = htmlDoc.DocumentNode;
            var marksText = rootNode.SelectNodes("//span[@class='grade-label']");
            List<int> grades = new List<int>();
            // Get marks list
            if (marksText != null)
            {
                foreach (var mark in marksText)
                {
                    switch (mark.InnerText)
                    {
                        case "отличная модель":
                            grades.Add(5); break;
                        case "хорошая модель":
                            grades.Add(4); break;
                        case "обычная модель":
                            grades.Add(3); break;
                        case "плохая модель":
                            grades.Add(2); break;
                        case "ужасная модель":
                            grades.Add(1); break;
                        default: break;
                    }
                }
                //Get texts for marks
                List<string> advantages = new List<string>();
                List<string> disadvantages = new List<string>();
                List<string> comments = new List<string>();
                var texts = rootNode.SelectNodes("//div[@class='data']");
                foreach (var text in texts)
                {

                    if (text.ChildNodes[2].Name == "div")
                    {
                        //Достоинства
                        advantages.Add(text.ChildNodes[3].InnerText);
                        //Недостатки
                        if (text.ChildNodes.Count == 5)
                        {
                            disadvantages.Add(text.ChildNodes[4].InnerText);
                        }
                        //Комментарий
                        if (text.ChildNodes.Count == 6)
                        {
                            comments.Add(text.ChildNodes[5].InnerText);
                        }
                    }
                    else
                    {
                        //Достоинства
                        advantages.Add(text.ChildNodes[2].InnerText);
                        //Недостатки
                        if (text.ChildNodes.Count == 4)
                        {
                            disadvantages.Add(text.ChildNodes[3].InnerText);
                        }
                        //Комментарий
                        if (text.ChildNodes.Count == 5)
                        {
                            comments.Add(text.ChildNodes[4].InnerText);
                        }
                    }
                }

                //Generating XML 
                for (int i = 0; i < advantages.Count; i++)
                {
                    var xml = new XmlDocument();
                    var xmlNode = xml.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    xml.AppendChild(xmlNode);
                    var xmlElem = xml.CreateElement("", "review", "");
                    xml.AppendChild(xmlElem);

                    char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

                    if (advantages.Count > i)
                    {
                        string result_advantages = String.Empty;
                        string[] advantages_split = advantages[i].Split(delimiterChars);
                        foreach (var word in advantages_split)
                        {
                            result_advantages = String.Concat(result_advantages, " ", stemmer.Stem(word));
                        }
                        var xmlAdvantages = xml.CreateElement("", "advantages", "");
                        var xmlAdvatagesText = xml.CreateTextNode(result_advantages);
                        xmlAdvantages.AppendChild(xmlAdvatagesText);
                        xml.LastChild.AppendChild(xmlAdvantages);
                    }

                    if (disadvantages.Count > i)
                    {
                        string result_disadvantages = String.Empty;
                        string[] disadvantages_split = disadvantages[i].Split(delimiterChars);
                        foreach (var word in disadvantages_split)
                        {
                            result_disadvantages = String.Concat(result_disadvantages, " ", stemmer.Stem(word));
                        }
                        var xmlDisadvantages = xml.CreateElement("", "disadvantages", "");
                        var xmlDisadvantagesText = xml.CreateTextNode(stemmer.Stem(result_disadvantages));
                        xmlDisadvantages.AppendChild(xmlDisadvantagesText);
                        xml.LastChild.AppendChild(xmlDisadvantages);
                    }

                    if (comments.Count > i)
                    {
                        string result_comments = String.Empty;
                        string[] comments_split = comments[i].Split(delimiterChars);
                        foreach (var word in comments_split)
                        {
                            result_comments = String.Concat(result_comments, " ", stemmer.Stem(word));
                        }
                        var xmlComments = xml.CreateElement("", "comments", "");
                        var xmlCommentsText = xml.CreateTextNode(result_comments);
                        xmlComments.AppendChild(xmlCommentsText);
                        xml.LastChild.AppendChild(xmlComments);
                    }
                    if (grades.Count > i)
                    {
                        var xmlGrade = xml.CreateElement("", "grade", "");
                        var xmlGradeText = xml.CreateTextNode(grades[i].ToString());
                        xmlGrade.AppendChild(xmlGradeText);
                        xml.LastChild.AppendChild(xmlGrade);
                    }
                    //generate path!
                    string path = String.Concat("c:\\xml\\", "xml_", Path.GetFileName(fileName), i.ToString(), ".xml");
                    xml.Save(path);

                }
            }
        }
    }
}
