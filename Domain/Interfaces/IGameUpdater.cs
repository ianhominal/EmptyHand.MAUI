using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGame
    {
        Guid GameId { get; }
        PlayerViewModel Player1 { get; }
        PlayerViewModel Player2 { get; }
        string PlayerTurnId { get; }
        string InitialPlayerTurnId { get; }
        ObservableCollection<CardViewModel> AvailableCards { get; }
        ObservableCollection<ObservableCollection<CardViewModel>> CardPits { get; }
        
        void UpdateGame(GameModel gameState);
        void ForceEndTurn();

        void CloseGame();
    }
}
