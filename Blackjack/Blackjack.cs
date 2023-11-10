using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class Blackjack {
        private readonly Deck deck = new();
        private readonly Player player = new();
        private readonly Dealer dealer = new();

        public void Play() {
            // #1. 딜러와 플레이어에게 카드를 각각 2장씩 준다.
            DrawInitialCards();

            // #2. 카드 상태 출력.
            ShowState();

            // #3. 플레이어와 딜러가 각각 카드를 뽑는다.
            GamblerTurn();
            DealerTurn();

            // #4. 결과 판별.
            GameOver();
        }

        private void DrawInitialCards() {
            for (int i = 0; i < 2; i++) {
                player.Hand.AddCard(deck.Draw());
                dealer.Hand.AddCard(deck.Draw());
            }
        }

        private void ShowState() {
            Console.WriteLine($"불   렉   젞    을          해  ?  요 .");
            Console.WriteLine($"Player[{player.Hand}]: {player.Hand.Value}");
            Console.WriteLine($"Dealer[{dealer.Hand}]: {dealer.Hand.Value}");
        }

        private void GamblerTurn() {
            while (!player.Hand.IsBursted && player.ShouldDraw()) {
                player.Hand.AddCard(deck.Draw());
                Console.Clear();
                ShowState();
            }
        }

        private void DealerTurn() {
            while (!dealer.Hand.IsBursted && dealer.ShouldDraw()) {
                dealer.Hand.AddCard(deck.Draw());
                Console.Clear();
                ShowState();
            }
        }

        private void GameOver() {
            if (player.Hand.IsBursted)
                Console.WriteLine("카드 합이 21이 넘어갔습니다. 패 배  햇 읍 니 다 . . . . . .");
            else if (dealer.Hand.IsBursted || dealer.Hand.Value < player.Hand.Value)
                Console.WriteLine("당 신  의      승 리?입  니   다 !");
            else
                Console.WriteLine("딜    러 의    승 ? 리  입 니  다!  당 신은패   배햇    읍니  다 ;;;");
        }

    }
}
