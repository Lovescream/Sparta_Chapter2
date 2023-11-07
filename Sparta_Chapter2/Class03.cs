using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Chapter2 {
    //#region Snake
    //public class Class03 {
    //    private int gameSpeed = 100;
    //    private int mapWidth = 80;
    //    private int mapHeight = 20;

    //    private int foodCount = 0;

    //    public void Main03_01() {
    //        // #1. 벽 그리기.
    //        DrawWalls();

    //        // #2. 뱀 그리기.
    //        Snake snake = new(new(4, 5, '*'), 4, '*', Direction.RIGHT);
    //        snake.Draw();

    //        // #3. 음식 그리기.
    //        FoodSpawner foodSpawner = new(mapWidth, mapHeight, '$');
    //        Point food = foodSpawner.CreateFood();
    //        food.Draw();

    //        // #4. 게임 진행.
    //        while (true) {
    //            // #A. 키 입력이 있는 경우, 방향 변경.
    //            if (Console.KeyAvailable) {
    //                snake.SetDirection(Console.ReadKey(true).Key switch { 
    //                    ConsoleKey.UpArrow => Direction.UP,
    //                    ConsoleKey.DownArrow => Direction.DOWN,
    //                    ConsoleKey.LeftArrow => Direction.LEFT,
    //                    ConsoleKey.RightArrow => Direction.RIGHT,
    //                    _ => Direction.NONE,
    //                });
    //            }

    //            // #B. 음식을 먹었는지 확인.
    //            if (snake.CheckEat(food)) {
    //                foodCount++;
    //                food.Draw();

    //                food = foodSpawner.CreateFood();
    //                food.Draw();

    //                if (gameSpeed > 10) gameSpeed -= 10;
    //            }
    //            else {
    //                snake.Move();
    //            }
    //            Thread.Sleep(gameSpeed);

    //            if (snake.IsHit()) break;

    //            Console.SetCursorPosition(0, mapHeight + 1);
    //            Console.WriteLine($"먹은 음식 수: {foodCount}");
    //        }
    //        DrawGameOver();
    //        Console.ReadLine();
    //    }

    //    private void DrawWalls() {
    //        for (int i = 0; i < mapWidth; i++) {
    //            Draw(i, 0, '#');
    //            Draw(i, 20, '#');
    //        }
    //        for (int i = 0;i<mapHeight; i++) {
    //            Draw(0, i, '#');
    //            Draw(80, i, '#');
    //        }
    //    }
    //    private void Draw(int x, int y, char character) {
    //        Console.SetCursorPosition(x, y);
    //        Console.Write(character);
    //    }
    //    private void WriteText(string text, int x, int y) {
    //        Console.SetCursorPosition(x, y);
    //        Console.WriteLine(text);
    //    }
    //    private void DrawGameOver() {
    //        int xOffset = 25;
    //        int yOffset = 22;
    //        Console.SetCursorPosition(xOffset, yOffset++);
    //        WriteText("============================", xOffset, yOffset++);
    //        WriteText("         GAME OVER", xOffset, yOffset++);
    //        WriteText("============================", xOffset, yOffset++);
    //    }
    //}

    //public class Snake {
    //    private List<Point> body;
    //    private Direction direction;
    //    private char sym;

    //    public Snake(Point tail, int length, char sym, Direction direction) {
    //        body = new();
    //        this.direction = direction;
    //        for (int i = 0; i < length; i++) {
    //            Point p = new Point(tail.X, tail.Y, sym);
    //            body.Add(p);
    //            tail.X += 1;
    //        }
    //    }

    //    public void SetDirection(Direction direction) {
    //        if (direction == Direction.NONE) return;
    //        this.direction = direction;
    //    }

    //    public void Draw() {
    //        body.ForEach(x => x.Draw());
    //    }

    //    public void Move() {
    //        Point tail = body.First();
    //        body.Remove(tail);
    //        Point head = GetNextPoint();
    //        body.Add(head);
    //        tail.Remove();
    //        head.Draw();
    //    }

    //    public bool CheckEat(Point point) {
    //        if (GetNextPoint().IsEquals(point)) {
    //            point.Sym = GetNextPoint().Sym;
    //            body.Add(point);
    //            return true;
    //        }
    //        else return false;
    //    }

    //    public Point GetNextPoint() {
    //        Point head = body.Last();
    //        Point nextPoint = new(head.X, head.Y, head.Sym);
    //        switch (direction) {
    //            case Direction.LEFT: nextPoint.X -= 1; break;
    //            case Direction.RIGHT: nextPoint.X += 1; break;
    //            case Direction.UP: nextPoint.Y -= 1;break;
    //            case Direction.DOWN: nextPoint.Y += 1; break;
    //        }
    //        return nextPoint;
    //    }

    //    public bool IsHit() {
    //        Point head = body.Last();
    //        if (head.X <= 0 || head.X >= 80 || head.Y <= 0 || head.Y >= 20) return true;
    //        for (int i = 0; i < body.Count - 2; i++) {
    //            if (head.IsEquals(body[i])) return true;
    //        }
    //        return false;
    //    }
    //}

    //public class FoodSpawner {
    //    private int mapWidth;
    //    private int mapHeight;
    //    private char sym;

    //    public FoodSpawner(int width, int height, char sym) {
    //        this.mapWidth = width;
    //        this.mapHeight = height;
    //        this.sym = sym;
    //    }

    //    public Point CreateFood() {
    //        int x = new Random().Next(2, mapWidth - 2);
    //        int y = new Random().Next(2, mapHeight - 2);
    //        return new Point(x, y, sym);
    //    }

    //}

    //public class Point {
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public char Sym { get; set; }

    //    public Point(int x, int y, char sym) {
    //        X = x;
    //        Y = y;
    //        Sym = sym;
    //    }

    //    public void Draw() {
    //        Console.SetCursorPosition(X, Y);
    //        Console.Write(Sym);
    //    }

    //    public void Remove() {
    //        Sym = ' ';
    //        Draw();
    //    }

    //    public bool IsEquals(Point p) => p.X == X && p.Y == Y;

    //}

    //public enum Direction {
    //    NONE,
    //    LEFT,
    //    RIGHT,
    //    UP,
    //    DOWN,
    //}
    //#endregion

    //#region Blackjack

    //public enum Suit { Spades, Clubs, Hearts, Diamonds, }
    //public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace, } 

    //public class Card {
    //    public Suit Suit { get; private set; }
    //    public Rank Rank { get; private set; }

    //    public Card(Suit suit, Rank rank) {
    //        Suit = suit;
    //        Rank = rank;
    //    }

    //    public int GetValue() {
    //        int cardValue = Math.Clamp((int)Rank, 2, 10);
    //        if (Rank == Rank.Ace) cardValue += 1;
    //        return cardValue;
    //    }

    //    public override string ToString() => $"{Rank} of {Suit}";
    //}

    //public class Deck {
    //    private List<Card> cards;

    //    public Deck() {
    //        cards = new();
    //        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
    //            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
    //                cards.Add(new(suit, rank));

    //        Shuffle();
    //    }

    //    public void Shuffle() {
    //        for (int i = 0; i <cards.Count;i++) {
    //            int j = new Random().Next(i, cards.Count);
    //            (cards[i], cards[j]) = (cards[j], cards[i]);
    //        }
    //    }

    //    public Card DrawCard() {
    //        Card card = cards[0];
    //        cards.RemoveAt(0);
    //        return card;
    //    }
    //}

    //public class Hand {
    //    private List<Card> cards;

    //    public Hand() {
    //        cards = new();
    //    }

    //    public void AddCard(Card card) => cards.Add(card);

    //    public int GetTotalValue() {
    //        int total = 0;
    //        int aceCount = 0;

    //        foreach (Card card in cards) {
    //            if (card.Rank == Rank.Ace) aceCount++;
    //            total += card.GetValue();
    //        }
    //        while (total > 21 && aceCount > 0) {
    //            total -= 10;
    //            aceCount--;
    //        }
    //        return total;
    //    }
    //}

    //public class Player {
    //    public Hand Hand { get; private set; }

    //    public Player() {
    //        Hand = new();
    //    }

    //    public Card DrawCardFromDeck(Deck deck) {
    //        Card drawnCard = deck.DrawCard();
    //        Hand.AddCard(drawnCard);
    //        return drawnCard;
    //    }
    //}

    //public class Dealer : Player {
    //    public void DealerTurn(Deck deck) {
    //        while (Hand.GetTotalValue() < 17) {
    //            Card drawnCard = DrawCardFromDeck(deck);
    //            Console.WriteLine($"딜러가 뽑은 카드는 {drawnCard.GetValue()}입니다. 현재 딜러의 총 합은 {Hand.GetTotalValue()}입니다.");
    //        }
    //    }
    //}

    //public class Blackjack {

    //    private Player player;
    //    private Dealer dealer;
    //    private Deck deck;

    //    public void PlayGame() {
    //        player = new();
    //        dealer = new();
    //        deck = new();

    //        Console.WriteLine("게임 시작!");
    //        Console.WriteLine("Player와 Dealer는 각각 두 장의 카드를 받습니다.");
    //        for (int i = 0; i < 2; i++) {
    //            player.DrawCardFromDeck(deck);
    //            dealer.DrawCardFromDeck(deck);
    //        }

    //        Console.WriteLine($"Player: {player.Hand.GetTotalValue()}");
    //        Console.WriteLine($"Dealer: {dealer.Hand.GetTotalValue()}");
    //        Console.WriteLine("[Player Turn]");
    //        while (player.Hand.GetTotalValue() < 21) {
    //            Console.Write("카드를 뽑으려면 O를, 그렇지 않으면 X를 입력해주세요: ");
    //            string? input = Console.ReadLine();
    //            if (input == "O" || input == "o") {
    //                Card drawnCard = player.DrawCardFromDeck(deck);
    //                Console.WriteLine($"뽑은 카드는 {drawnCard.GetValue()}입니다. 현재 총 합은 {player.Hand.GetTotalValue()}입니다.");
    //            }
    //            else if (input == "X" || input == "x") {
    //                break;
    //            }
    //            else {
    //                Console.WriteLine("다시 입력해주세요.");
    //            }
    //        }
    //        if (player.Hand.GetTotalValue() > 21) {
    //            Console.WriteLine("Player의 카드 합이 21을 초과하였습니다. Dealer의 승리입니다.");
    //            return;
    //        }

    //        Console.WriteLine("[Dealer Turn]");
    //        dealer.DealerTurn(deck);
    //        Console.WriteLine("[게임 종료]\n");

    //        if (dealer.Hand.GetTotalValue() > 21) {
    //            Console.WriteLine("Dealer의 카드 합이 21을 초과하였습니다. Player의 승리입니다.");
    //        }
    //        else if (dealer.Hand.GetTotalValue() >= player.Hand.GetTotalValue()) {
    //            Console.WriteLine("Dealer의 카드 합이 더 높거나 같습니다. Dealer의 승리입니다.");
    //        }
    //        else {
    //            Console.WriteLine("Player의 카드 합이 더 높습니다. Player의 승리입니다.");
    //        }
    //    }

    //}
    //#endregion

}
