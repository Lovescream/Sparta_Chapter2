using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Chapter2 {

    //public enum Suit { Spades, Clubs, Hearts, Diamonds, };
    //public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace, }

    //public class Card {
    //    public Suit Suit { get; private set; }
    //    public Rank Rank { get; private set; }
    //    public int Value {
    //        get {
    //            if ((int)Rank <= 10) return (int)Rank;
    //            else if (Rank == Rank.Ace) return 11;
    //            return 10;
    //        }
    //    }

    //    public Card(Suit suit, Rank rank) {
    //        Suit = suit;
    //        Rank = rank;
    //    }

    //    public override string ToString() => $"{Rank} of {Suit}";
    //}

    //public class Deck {
    //    private Stack<Card> cards = new();

    //    public Deck() {
    //        // #1. 카드 생성.
    //        List<Card> cardList = new();
    //        foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
    //            foreach (Rank rank in Enum.GetValues(typeof(Rank))) {
    //                cardList.Add(new(suit, rank));
    //            }
    //        }

    //        // #2. 카드 섞기.
    //        int n = cardList.Count;
    //        while (n > 1) {
    //            n--;
    //            int k = new Random().Next(0, n + 1);
    //            (cardList[n], cardList[k]) = (cardList[k], cardList[n]);
    //        }

    //        // #3. 스택에 넣기.
    //        cardList.ForEach(cards.Push);
    //    }

    //    public Card Draw() => cards.Pop();
    //}

    //public class Hand {

    //    public bool IsBursted => GetValue() > 21;

    //    private List<Card> cards = new();

    //    public int GetValue() {
    //        // #1. ACE = 11로 하여 총 합 계산.
    //        int totalValue = cards.Sum(x => x.Value);
    //        int aceCount = cards.Count(x => x.Rank == Rank.Ace);

    //        // #2. 필요에 따라 ACE = 1로 하여 총 합 보정.
    //        while (totalValue > 21 && aceCount > 0) {
    //            totalValue -= 10;
    //            aceCount--;
    //        }

    //        return totalValue;
    //    }

    //    public void AddCard(Card card) => cards.Add(card);

    //    public override string ToString() => string.Join(", ", cards.Select(card => card.ToString()));
    //}

    //public abstract class Player {
    //    public Hand Hand { get; private set; } = new();

    //    public abstract bool Draw();
    //}

    //public class Gambler : Player {
    //    public override bool Draw() {
    //        Console.Write("카드를 더 뽑으시겠습니까? (Y/N): ");
    //        while (true) {
    //            string? input = Console.ReadLine();
    //            if (input == null) continue;
    //            else if (input.ToUpper() == "Y") return true;
    //            else if (input.ToUpper() == "N") return false;
    //            else {
    //                Console.WriteLine("올바른 값을 입력해주세요!");
    //            }
    //        }
    //    }
    //}

    //public class Dealer : Player {
    //    public override bool Draw() => Hand.GetValue() < 17;
    //}

    //public class Class03_Blackjack {
    //    private readonly Deck deck = new();
    //    private readonly Gambler gambler = new();
    //    private readonly Dealer dealer = new();

    //    public void Play() {
    //        // #1. 딜러와 플레이어에게 카드를 각각 2장씩 준다.
    //        for (int i = 0; i < 2; i++) {
    //            gambler.Hand.AddCard(deck.Draw());
    //            dealer.Hand.AddCard(deck.Draw());
    //        }

    //        // #2. 카드 상태 출력.
    //        ShowState();

    //        // #3. 플레이어와 딜러가 각각 카드를 뽑는다.
    //        GamblerTurn();
    //        DealerTurn();

    //        // #4. 결과 판별.
    //        GameOver();
    //    }

    //    private void ShowState() {
    //        Console.WriteLine($"불   렉   젞    을          해  ?  요 .");
    //        Console.WriteLine($"Player[{gambler.Hand.GetValue()}]: {gambler.Hand}");
    //        Console.WriteLine($"Dealer[{dealer.Hand.GetValue()}]: {dealer.Hand}");
    //    }

    //    private void GamblerTurn() {
    //        while (!gambler.Hand.IsBursted && gambler.Draw()) {
    //            gambler.Hand.AddCard(deck.Draw());
    //            Console.Clear();
    //            ShowState();
    //        }
    //    }

    //    private void DealerTurn() {
    //        while (!dealer.Hand.IsBursted && dealer.Draw()) {
    //            dealer.Hand.AddCard(deck.Draw());
    //            Console.Clear();
    //            ShowState();
    //        }
    //    }

    //    private void GameOver() {
    //        if (gambler.Hand.IsBursted)
    //            Console.WriteLine("카드 합이 21이 넘어갔습니다. 패 배  햇 읍 니 다 . . . . . .");
    //        else if (dealer.Hand.IsBursted || dealer.Hand.GetValue() < gambler.Hand.GetValue())
    //            Console.WriteLine("당 신  의      승 리?입  니   다 !");
    //        else
    //            Console.WriteLine("딜    러 의    승 ? 리  입 니  다!  당 신은패   배햇    읍니  다 ;;;");
    //    }

    //}
}
