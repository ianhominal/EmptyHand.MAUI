using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PlayerModel
    {
        public PlayerModel(string playerId, string playerName, string playerPhotoURL, string playerMail)
        {
            this.PlayerId = playerId;
            this.PlayerName = playerName;
            this.PlayerPhoto = playerPhotoURL;

            PlayerPoints = 0;
            PlayerRoundsWins = 0;
            PlayerMail = playerMail;

            PlayerCards = new List<CardModel>();
            PlayerLifeCards = new List<CardModel>();
        }

        public string PlayerId { get; set; }
        public string PlayerHubId { get; set; }
        public List<CardModel> PlayerCards { get; set; }
        public List<CardModel> PlayerLifeCards { get; set; }
        public int PlayerPoints { get; set; }
        public int PlayerRoundsWins { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPhoto { get; set; }
        public string PlayerMail { get; set; }

        // Método para convertir de CardModel a CardViewModel
        public PlayerViewModel ToCardViewModel()
        {
            return new PlayerViewModel(this);
        }


    }
}
