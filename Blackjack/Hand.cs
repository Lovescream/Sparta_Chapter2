using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class Hand {

        public int Value {
            get {
                // #1. ACE = 11로 하여 총 합 계산.
                int totalValue = cards.Sum(x => x.Value);
                int aceCount = cards.Count(x => x.Rank == Rank.Ace);

                // #2. 필요에 따라 ACE = 1로 하여 총 합 보정.
                while (totalValue > 21 && aceCount > 0) {
                    totalValue -= 10;
                    aceCount--;
                }

                return totalValue;
            }
        }
        public bool IsBursted => Value > 21;

        private List<Card> cards = new();


        public void AddCard(Card card) => cards.Add(card);

        public override string ToString() => string.Join(", ", cards);
    }
}
