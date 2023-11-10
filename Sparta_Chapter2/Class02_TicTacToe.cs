using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Chapter2 {
    //public class Class02_TicTacToe {
    //    public void Main() {
    //        while (true) {
    //            new Game().Play();
    //            Console.WriteLine("게임 종료! 다시 플레이하려면 'R'을 입력해주세요.");
    //            if (!char.TryParse(Console.ReadLine(), out char input) || input != 'R') break;
    //        }
    //    }
    //}

    //public class Game {
    //    public Player CurrentPlayer { get; private set; }

    //    private bool isOver;

    //    private Board board;
    //    private Player player1;
    //    private Player player2;

    //    public Game() {
    //        board = new Board();
    //        player1 = new(1, 'X');
    //        player2 = new(2, 'O');
    //        CurrentPlayer = player1;
    //        isOver = false;
    //    }

    //    public void Play() {
    //        while (!isOver) {
    //            Console.Clear();
    //            board.Show();
    //            PlayTurn();

    //            if (board.CheckWin(CurrentPlayer.Symbol)) {
    //                isOver = true;
    //                Console.WriteLine($"{CurrentPlayer}의 승리입니다!");
    //                break;
    //            }
    //            if (board.IsFull()) {
    //                isOver = true;
    //                Console.WriteLine("무승부입니다!");
    //                break;
    //            }
    //            CurrentPlayer = CurrentPlayer == player1 ? player2 : player1;
    //        }
    //    }

    //    private void PlayTurn() {
    //        Console.WriteLine($"{CurrentPlayer} 차례입니다.");
    //        while (true) {
    //            Console.Write("행을 선택하세요 (0, 1, 2): ");
    //            if (!int.TryParse(Console.ReadLine(), out int row) || row < 0 || 2 < row) {
    //                Console.WriteLine("올바른 값을 입력하세요!");
    //                continue;
    //            }
    //            Console.Write("열을 선택하세요 (0, 1, 2): ");
    //            if (!int.TryParse(Console.ReadLine(), out int col) || col < 0 || 2 < col) {
    //                Console.WriteLine("올바른 값을 입력하세요!");
    //                continue;
    //            }
    //            if (!board.PlaceSymbol(row, col, CurrentPlayer.Symbol)) {
    //                Console.WriteLine("잘못된 위치입니다. 다시 입력하세요!");
    //                continue;
    //            }
    //            break;
    //        }
    //    }
    //}


    //public class Board {
    //    private char[,] grid = new char[3, 3];
    //    private readonly char empty = ' ';

    //    public Board() {
    //        for (int x = 0; x < 3; x++) for (int y = 0; y < 3; y++) grid[x, y] = ' ';
    //    }

    //    public bool PlaceSymbol(int x, int y, char symbol) {
    //        if (x < 0 || x > 3 || y < 0 || y > 3) return false;
    //        if (grid[x, y] != empty) return false;
    //        grid[x, y] = symbol;
    //        return true;
    //    }

    //    public bool IsFull() {
    //        for (int x = 0; x < 3; x++) for (int y = 0; y < 3; y++) if (grid[x, y] == empty) return false;
    //        return true;
    //    }

    //    public bool CheckWin(char symbol) {
    //        for (int i = 0; i < 3; i++) {
    //            if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2] && grid[i, 2] == symbol) return true;
    //            if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i] && grid[2, i] == symbol) return true;
    //        }
    //        if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] && grid[2, 2] == symbol) return true;
    //        if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0] && grid[2, 0] == symbol) return true;
    //        return false;
            
    //    }

    //    public void Show() {
    //        string space = "     ";
    //        char vertical = '|';
    //        string horizontal = "_____";
    //        string symbol = "  A  ";

    //        for (int i = 0; i < 9; i++) {
    //            if (i % 3 == 1) {
    //                int x = i / 3;
    //                Console.WriteLine(String.Join(vertical, symbol.Replace('A', grid[x, 0]), symbol.Replace('A', grid[x, 1]), symbol.Replace('A', grid[x, 2])));
    //            }
    //            else if (i % 3 == 2 && i != 8) {
    //                Console.WriteLine(String.Join(vertical, horizontal, horizontal, horizontal));
    //            }
    //            else {
    //                Console.WriteLine(String.Join(vertical, space, space, space));
    //            }
    //        }
    //    }
    //}

    //public class Player {
    //    public int Id { get; private set; }
    //    public char Symbol { get; private set; }

    //    public Player (int id, char symbol) { this.Id = id; this.Symbol = symbol; }

    //    public override string ToString() => $"Player{Id}[{Symbol}]";
    //}
}
