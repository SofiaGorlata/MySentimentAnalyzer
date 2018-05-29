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
        private string response;
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
        public string Response
        {
            get
            {
                return response;
            }
            set
            {
                response = value;
                OnPropertyChanged(nameof(Response));
            }
        }

        public Comment()
        {
        }

        public Comment(int _id, string _text, string _response)
        {
            Id = _id;
            Text = _text;
            Response = _response;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
