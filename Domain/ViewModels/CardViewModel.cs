using Domain.Models;
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
        private CardModel cardModel;
        private bool faceUp;
        private bool shadowVisible = true;
        private Thickness shadowMargin = new Thickness(4, 4, 0, 0);
        double rotation = 0;
        double rotationX = 0;
        double rotationY = 0;

        public CardViewModel(CardModel cardModel, bool faceUp = true)
        {
            this.cardModel = cardModel;
            this.faceUp = faceUp;
        }

        public int CardWidth => 66;

        public int CardHeight => 93;

        public bool FaceUp
        {
            get { return faceUp; }
            set
            {
                faceUp = value;
                UpdateCardView();
            }
        }

        public bool FaceDown => !faceUp;

        public bool ShadowVisible
        {
            get { return shadowVisible; }
            set
            {
                shadowVisible = value;
                UpdateCardView();
            }
        }

        public Thickness ShadowMargin
        {
            get { return shadowMargin; }
            set
            {
                shadowMargin = value;
                UpdateCardView();
            }
        }

        public string Rank => faceUp ? cardModel.Rank : "";

        public string SuitChar => faceUp ? GetSuitChar(cardModel.Suit) : "";

        public Color SuitColor => (cardModel.Suit == "Hearts" || cardModel.Suit == "Diamonds") ? Colors.Red : Colors.Black;

        public Color RankColor => (cardModel.Suit == "Hearts" || cardModel.Suit == "Diamonds") ? Colors.Red : Colors.Black;

        public double Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                OnPropertyChanged("Rotation");
            }
        }

        public double RotationX
        {
            get { return rotationX; }
            set
            {
                rotationX = value;
                OnPropertyChanged("RotationX");
            }
        }

        public double RotationY
        {
            get { return rotationY; }
            set
            {
                rotationY = value;
                OnPropertyChanged("RotationY");
            }
        }

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
                    return "♦";
                case "Hearts":
                    return "♥";
                case "Spades":
                    return "♠";
                default:
                    return "";
            }
        }

        public void Flip()
        {
            faceUp = !faceUp;
            UpdateCardView();
        }

        private void UpdateCardView()
        {
            RaisePropertyChanged("FaceUp");
            RaisePropertyChanged("FaceDown");
            RaisePropertyChanged("ShadowVisible");
            RaisePropertyChanged("ShadowMargin");
            RaisePropertyChanged("Rank");
            RaisePropertyChanged("SuitChar");
            RaisePropertyChanged("SuitColor");
            RaisePropertyChanged("RankColor");
        }
    }

}
