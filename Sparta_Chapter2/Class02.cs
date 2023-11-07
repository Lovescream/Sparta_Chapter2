using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Chapter2 {
    public  class Class02 {
        public static void Class02Main() {
            Console.WriteLine("==================================================================");
            Console.WriteLine("구 구 단 을 출 력 한 다 ! ");
            for (int x = 2; x <= 9; x++) {
                for (int y = 1; y <= 9; y++) {
                    Console.WriteLine($"{x} x {y} = {x * y}");
                }
            }
            Console.WriteLine("==================================================================");
            for (int i = 1; i <= 5; i++) {
                for (int j = 0; j < i; j++) {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            for (int i = 5; i > 0; i--) {
                for (int j = 0; j < i; j++) {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            int height = 5;
            for (int i = height - 1; i >= 0; i--) {
                for (int j = 0; j < i; j++)
                    Console.Write(" ");
                for (int j = 0; j < 2 * height - 2 * i - 1; j++) {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.WriteLine("==================================================================");

            int count = 5;
            int[] nums = new int[count];
            for (int i = 0; i < count; i++) {
                Console.Write($"[{i} / {count}] 숫자를 입력하세요: ");
                while (true) {
                    if (int.TryParse(Console.ReadLine(), out nums[i]))
                        break;
                    Console.WriteLine("정수를 입력하세요!");
                }
            }
            Console.WriteLine($"최댓값: {nums.Max()}");
            Console.WriteLine($"최솟값: {nums.Min()}");
            Console.WriteLine("==================================================================");
            Console.Write("소수를 판별할 숫자를 입력하세요: ");
            int numb = 0;
            while (true) {
                if (int.TryParse(Console.ReadLine(), out numb) && numb > 0) break;
                Console.WriteLine("자연수를 입력하세요!");
            }
            if (IsPrime(numb)) Console.WriteLine($"{numb}은 소수입니다.");
            else Console.WriteLine($"{numb}은 소수가 아닙니다.");
        }

        public static void Class02Game01() {
            int number = new Random().Next(1, 101);
            int count = 0;
            while (true) {
                count++;
                Console.Write("숫자를 입력하세요: ");
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0) {
                    if (number > num) Console.WriteLine("너무 작습니다.");
                    else if (number < num) Console.WriteLine("너무 큽니다.");
                    else {
                        Console.WriteLine($"축하합니다! {count}번 만에 숫자를 맞추었습니다.");
                        break;
                    }
                }
                Console.WriteLine("자연수를 입력하세요!");
            }
        }
        

        public static void Class02Game02() {
            int player = 1;
            char[] array = { '0', '1', '2', '3', '4', '5', '6', '7', '8'};
            int turn = 0;

            while (true) {
                Console.Clear();
                Console.WriteLine("Player 1: X    Player 2: O\n");
                Console.WriteLine($"[Player {player}의 차례]\n");

                ShowBoard(array);
                if (int.TryParse(Console.ReadLine(), out int selection)) {
                    if (array[selection] != 'X' || array[selection] != 'O') {
                        array[selection] = player == 2 ? 'O' : 'X';
                        player = player == 1 ? 2 : 1;
                    }
                    else {
                        Console.WriteLine($"{selection}번 자리는 이미 {array[selection]}으로 표시되었습니다.");
                    }
                }
                else {
                    Console.WriteLine("숫자를 입력해주세요.");
                }

                turn++;
                if (Check(array)) {
                    Console.Clear();
                    ShowBoard(array);
                    if (player == 2) Console.WriteLine("Player 1 Win!");
                    else Console.WriteLine("Player 2 Win!");
                    break;
                }
                else if (turn >= 9) {
                    Console.Clear();
                    ShowBoard(array);
                    Console.WriteLine("Draw!");
                    break;
                }
            }
        }
        private static void ShowBoard(char[] array) {
            string space = "     ";
            char vertical = '|';
            string horizontal = "_____";
            string check = "  A  ";
            for (int i = 0; i < 9; i++) {
                if (i % 3 == 1) {
                    Console.WriteLine(String.Join(vertical, check.Replace("A", array[i - 1].ToString()), check.Replace("A", array[i].ToString()), check.Replace("A", array[i + 1].ToString())));
                }
                else if (i % 3 == 2 && i != 8) {
                    Console.WriteLine(String.Join(vertical, horizontal, horizontal, horizontal));
                }
                else {
                    Console.WriteLine(String.Join(vertical, space, space, space));
                }
            }
        }
        private static bool Check(char[] array) {
            if (array[0] == array[1] && array[1] == array[2]) return true;
            if (array[3] == array[4] && array[4] == array[5]) return true;
            if (array[6] == array[7] && array[7] == array[8]) return true;
            if (array[0] == array[3] && array[3] == array[6]) return true;
            if (array[1] == array[4] && array[4] == array[7]) return true;
            if (array[2] == array[5] && array[5] == array[8]) return true;
            if (array[0] == array[4] && array[4] == array[8]) return true;
            if (array[2] == array[4] && array[4] == array[6]) return true;
            return false;
        }

        private static bool IsPrime(int num) {
            int count = 0;
            for (int i = 1; i * i <= num; i++) {
                if (i * i == num) count++;
                else if (num % i == 0) count += 2;
            }
            return count == 2;
        }
    }
}
