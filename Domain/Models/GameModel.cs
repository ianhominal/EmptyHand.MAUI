using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GameModel
    {
        public Guid GameId { get; set; }
        public PlayerModel Player1 { get; set; }
        public PlayerModel Player2 { get; set; }
        public string PlayerTurnId { get; set; }
        public string InitialPlayerTurnId { get; set; }
        public List<CardModel> AvailableCards { get; set; }
        public Dictionary<string, List<CardModel>> CardPits { get; set; }
    }
}
