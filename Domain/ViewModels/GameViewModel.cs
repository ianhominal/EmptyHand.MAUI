using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private readonly GameModel gameModel;
        public GameViewModel(GameModel gameModel, string userId)
        {
            this.gameModel = gameModel;
            ActualPlayer = userId == gameModel.Player1.PlayerId ? gameModel.Player1.ToCardViewModel() : gameModel.Player2.ToCardViewModel();
            EnemyPlayer = userId == gameModel.Player1.PlayerId ? gameModel.Player2.ToCardViewModel() : gameModel.Player1.ToCardViewModel();

            AvailableCards = new ObservableCollection<CardViewModel>(gameModel.AvailableCards.Select(c => c.ToCardViewModel()));

            CardPits = new ObservableCollection<KeyValuePair<string, ObservableCollection<CardViewModel>>>();

            foreach (var pit in gameModel.CardPits)
            {
                var observableCards = new ObservableCollection<CardViewModel>(pit.Value.Select(c => c.ToCardViewModel()));
                CardPits.Add(new KeyValuePair<string, ObservableCollection<CardViewModel>>(pit.Key, observableCards));
            }
        }

        public string PlayerTurnId
        {
            get => gameModel.PlayerTurnId;
            set
            {
                gameModel.PlayerTurnId = value;
                OnPropertyChanged(nameof(PlayerTurnId));
            }
        }

        public PlayerViewModel ActualPlayer { get; set; }
        public PlayerViewModel EnemyPlayer { get; set; }
        public ObservableCollection<CardViewModel> AvailableCards { get;}
        public ObservableCollection<KeyValuePair<string, ObservableCollection<CardViewModel>>> CardPits { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
