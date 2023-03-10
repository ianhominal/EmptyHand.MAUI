using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CardModel
    {
        private string suit;
        private string rank;

        public CardModel(string suit, string rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }
}
