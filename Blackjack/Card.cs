using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public enum Suit { Spades, Clubs, Hearts, Diamonds, };
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace, }

    public class Card {

        #region Properties

        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public int Value => Rank switch {
            Rank.Ace => 11,
            >= Rank.Ten => 10,
            _ => (int)Rank
        };

        

        #endregion

        public Card(Suit suit, Rank rank) {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString() => $"{Rank} of {Suit}";
    }
}
