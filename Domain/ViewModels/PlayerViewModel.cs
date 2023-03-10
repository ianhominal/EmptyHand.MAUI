using Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Domain.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private readonly PlayerModel playerModel;

        public PlayerViewModel(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
            PlayerCards = new ObservableCollection<CardViewModel>(playerModel.PlayerCards.Select( c => c.ToCardViewModel())); 
            PlayerLifeCards = new ObservableCollection<CardViewModel>(playerModel.PlayerCards.Select(c => c.ToCardViewModel()));
        }

        public string PlayerId => playerModel.PlayerId;

        public string PlayerName
        {
            get => playerModel.PlayerName;
            set
            {
                playerModel.PlayerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public string PlayerPhoto => playerModel.PlayerPhoto;

        public int PlayerPoints
        {
            get => playerModel.PlayerPoints;
            set
            {
                playerModel.PlayerPoints = value;
                OnPropertyChanged(nameof(PlayerPoints));
            }
        }

        public int PlayerRoundsWins
        {
            get => playerModel.PlayerRoundsWins;
            set
            {
                playerModel.PlayerRoundsWins = value;
                OnPropertyChanged(nameof(PlayerRoundsWins));
            }
        }

        public ObservableCollection<CardViewModel> PlayerCards { get; }

        public ObservableCollection<CardViewModel> PlayerLifeCards { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdatePlayerCards(IEnumerable<CardViewModel> playerCards, IEnumerable<CardViewModel> playerLifeCards)
        {
            PlayerCards.Clear();
            foreach (var card in playerCards)
            {
                PlayerCards.Add(card);
            }

            PlayerLifeCards.Clear();
            foreach (var card in playerLifeCards)
            {
                PlayerLifeCards.Add(card);
            }
        }

    }
}