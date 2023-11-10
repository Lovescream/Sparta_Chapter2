using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Chapter2 {

    //public enum Direction { Up, Down, Left, Right }
    //public class Class03_Snake {

    //    #region Fields

    //    // Const.
    //    private readonly int width = 80;
    //    private readonly int height = 20;

    //    // Objects.
    //    private Snake snake;
    //    private Point food;

    //    // State.
    //    private bool isOver;
    //    private Direction direction;

    //    #endregion

    //    #region Initialize / Constructor

    //    public Class03_Snake() {
    //        this.snake = new();
    //        direction = Direction.Right;
    //        SpawnFood();
    //        isOver = false;
    //    }

    //    #endregion

    //    #region Game

    //    public void Game() {
    //        while (!isOver) {
    //            if (Console.KeyAvailable) direction = ReadInput(Console.ReadKey(true).Key);

    //            snake.Move(direction);
    //            CheckCollision();
    //            if (snake.Head.Equals(food)) EatFood();

    //            DrawGame();
    //            Thread.Sleep(100);
    //        }

    //        Console.SetCursorPosition(width / 2, height / 2);
    //        Console.WriteLine("Game Over");
    //        Console.ReadKey();
    //    }

    //    #endregion

    //    private bool CheckCollision() {
    //        if (!snake.Head.IsInBounds(width, height)) return false;
    //        if (snake.CheckCollisionSelf()) return false;
    //        return true;
    //    }

    //    private void EatFood() {
    //        snake.Grow(direction);
    //        SpawnFood();
    //    }

    //    private void SpawnFood() {
    //        while (true) {
    //            food = new(new Random().Next(1, width - 2), new Random().Next(1, height - 2));
    //            if (!snake.Contains(food)) break;
    //        }
    //    }
        
    //    private Direction ReadInput(ConsoleKey key) {
    //        return key switch {
    //            ConsoleKey.UpArrow when direction != Direction.Down => Direction.Up,
    //            ConsoleKey.DownArrow when direction != Direction.Up => Direction.Down,
    //            ConsoleKey.LeftArrow when direction != Direction.Right => Direction.Left,
    //            ConsoleKey.RightArrow when direction != Direction.Left => Direction.Right,
    //            _ => direction
    //        };
    //    }

    //    private void DrawGame() {
    //        Console.Clear();
    //        for (int y = 0; y < height; y++) {
    //            for (int x = 0; x < width; x++) {
    //                if (x == 0 || y == 0 || x == width - 1 || y == height - 1) Console.Write("#");
    //                else if (snake.Contains(x, y)) Console.Write("*");
    //                else if (food.X == x && food.Y == y) Console.Write("$");
    //                else Console.Write(" ");
    //            }
    //            Console.WriteLine();
    //        }
    //    }
    //}

    //public class Snake {

    //    #region Properties

    //    public Point Head => body.First();

    //    #endregion

    //    #region Fields
        
    //    // Collections.
    //    private List<Point> body = new();

    //    #endregion

    //    public Snake() {
    //        body.Add(new Point(10, 10));
    //    }

    //    public bool Contains(Point point) => body.Contains(point);
    //    public bool Contains(int x, int y) => body.Any(p => p.X == x && p.Y == y);
    //    public bool CheckCollisionSelf() => body.Skip(1).Any(p => p.Equals(Head));

    //    public void Move(Direction direction) {
    //        Point newHead = Head.GetNextPoint(direction);
    //        body.Insert(0, newHead);
    //        body.RemoveAt(body.Count - 1);
    //    }

    //    public void Grow(Direction direction) {
    //        Point newHead = Head.GetNextPoint(direction);
    //        body.Insert(0, newHead);
    //    }

    //}

    //public class Point {
    //    public int X { get; private set; }
    //    public int Y { get; private set; }

    //    public Point(int x, int y) { X = x; Y = y; }

    //    public Point GetNextPoint(Direction direction) {
    //        return direction switch {
    //            Direction.Up => new(X, Y - 1),
    //            Direction.Down => new(X, Y + 1),
    //            Direction.Left => new(X - 1, Y),
    //            Direction.Right => new(X + 1, Y),
    //            _ => this
    //        };
    //    }

    //    public bool IsInBounds(int width, int height) {
    //        if (X < 0 || X >= width || Y < 0 || Y >= height) return false;
    //        return true;
    //    }

    //    public override bool Equals(object? obj) => obj is Point point && X == point.X && Y == point.Y;
    //    public override int GetHashCode() => HashCode.Combine(X, Y);
    //}
}
