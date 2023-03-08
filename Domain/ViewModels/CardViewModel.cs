using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CardViewModel : INotifyPropertyChanged
    {
        private const int cardWidth = 66;
        private const int cardHeight = 93;
        private string suit;
        private string rank;
        private bool faceUp;

        public CardViewModel(string suit, string rank, bool faceUp = true)
        {
            this.suit = suit;
            this.rank = rank;
            this.faceUp = faceUp;
        }

        public int CardWidth => cardWidth;

        public int CardHeight => cardHeight;

        public bool FaceUp => faceUp;
        public bool FaceDown => !faceUp;

        public bool CardColorVisible => faceUp;

        public bool Border2Visible => faceUp;

        public string Rank
        {
            get
            {
                return faceUp ? rank : "";
            }
            set { rank = value; }
        }

        public string SuitChar => faceUp ? GetSuitChar(suit) : "";

        public Color SuitColor => (suit == "Hearts" || suit == "Diamonds") ? Colors.Red : Colors.Black;


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        private static string GetSuitChar(string suit)
        {
            switch (suit)
            {
                case "Clubs":
                    return "♣";
                case "Diamonds":
                    return  "♦";
                case "Hearts":
                    return  "♥" ;
                case "Spades":
                    return "♠";
                default: 
                    return "";
            }
        }

        private Color GetRankColor()
        {
            return (suit == "Hearts" || suit == "Diamonds") ? Colors.Red : Colors.Black;
        }

        public void Flip()
        {
            faceUp = !faceUp;
            RaisePropertyChanged("FaceUp");
            RaisePropertyChanged("FaceDown");
            RaisePropertyChanged("CardColorVisible");
            RaisePropertyChanged("Border2Visible");
            RaisePropertyChanged("Rank");
            RaisePropertyChanged("SuitChar");
            RaisePropertyChanged("SuitColor");
            RaisePropertyChanged("RankColor");
        }
    }
}
