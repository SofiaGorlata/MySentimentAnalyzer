using MySentimentAnalyze.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using VaderSharp;
using MySentimentLibraryRegression.Controller;

namespace MySentimentAnalyze.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string url;
        private ObservableCollection<Comment> comments;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                OnPropertyChanged(nameof(Url));
            }
        }
        public ObservableCollection<Comment> Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        public ICommand GetAllCommentsCommand { get; private set; }
        public ICommand AnalyzeCommand { get; private set; }

        public MainViewModel()
        {
            Comments = new ObservableCollection<Comment>();
            GetAllCommentsCommand = new RelayCommand(GetAllComments);
            AnalyzeCommand = new RelayCommand(Analyze);
        }

        private void GetAllComments(object parametr)
        {
            string strippedUrl = Url.Substring(0, Url.IndexOf("ref="));
            string dp = Regex.Match(strippedUrl, @"/[A-Z0-9]+/").Value;
            dp = dp.Substring(1, dp.Length - 2);
            strippedUrl = strippedUrl.Substring(0, strippedUrl.IndexOf("dp/"));
            HtmlWeb web = new HtmlWeb();
            web.UseCookies = true;

            int id = 1;
            for (int page = 1; page < 1000; ++page)
            {
                HtmlDocument doc = new HtmlDocument();
                string commentsUrl = String.Format("{0}product-reviews/{1}/ref=cm_cr_arp_d_paging_btm_2?ie=UTF8&reviewerType=all_reviews&pageNumber={2}", strippedUrl, dp, page);
                var data = new MyWebClient().DownloadString(commentsUrl);
                doc.LoadHtml(data);

                HtmlNodeCollection pageComments = doc.DocumentNode.SelectNodes("//span[@class='a-size-base review-text review-text-content']");

                if (pageComments == null)
                {
                    break;
                }
                foreach (HtmlNode elem in pageComments)
                {

                    Comments.Add(new Comment(id++, elem.InnerText, "Невизначено", "Невизначено"));
                }

            }
        }


        private void Analyze(object obj)
        {
            SentimentIntensityAnalyzer analyzer = new SentimentIntensityAnalyzer();
            SentimentAnalyzerController regression = new SentimentAnalyzerController();
            foreach (Comment comment in Comments)
            {
                var analyzed = analyzer.PolarityScores(comment.Text);
                comment.NaiveBayes = String.Format("Positive: {0} Neutral: {1} Negative: {2} Compound: {3}", analyzed.Positive, analyzed.Neutral, analyzed.Negative, analyzed.Compound);
                comment.LogisticRegression = regression.GetTextForMark(comment.Text).ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
