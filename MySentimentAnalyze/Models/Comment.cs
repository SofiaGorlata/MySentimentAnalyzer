using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MySentimentAnalyze.Models
{
    [Serializable]
    public class Comment: INotifyPropertyChanged
    {
        private int id;
        private string text;
        private string naiveBayes;
        private string logisticRegression;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public string NaiveBayes
        {
            get
            {
                return naiveBayes;
            }
            set
            {
                naiveBayes = value;
                OnPropertyChanged(nameof(NaiveBayes));
            }
        }
        public string LogisticRegression
        {
            get
            {
                return logisticRegression;
            }
            set
            {
                logisticRegression = value;
                OnPropertyChanged(nameof(LogisticRegression));
            }
        }

        public Comment()
        {
        }

        public Comment(int _id, string _text, string _naiveBayes, string _logisticRegression)
        {
            Id = _id;
            Text = _text;
            NaiveBayes = _naiveBayes;
            LogisticRegression = _logisticRegression;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
