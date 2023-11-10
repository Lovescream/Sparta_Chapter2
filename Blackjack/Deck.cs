using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class Deck {
        private Stack<Card> cards = new();

        public Deck() {
            // #1. 카드 생성.
            List<Card> cardList = Enum.GetValues<Suit>()
                .SelectMany(suit => Enum.GetValues<Rank>(), (suit, rank) => new Card(suit, rank))
                .ToList();

            // #2. 카드 섞기.
            Shuffle(cardList);

            // #3. 스택에 넣기.
            cardList.ForEach(cards.Push);
        }

        private void Shuffle(List<Card> cardList) {
            Random random = new();
            int n = cardList.Count;
            while (n > 1) {
                int k = random.Next(--n + 1);
                (cardList[n], cardList[k]) = (cardList[k], cardList[n]);
            }
        }

        public Card Draw() => cards.Pop();
    }
}
