using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Chapter2 {
    public class Class01 {
        public static void Class01Main() {
            Console.WriteLine("==================================================================");
            Console.Write("이름을 입력하세요: ");
            string? name = Console.ReadLine();
            int age = 0;
            while (true) {
                Console.Write("나이를 입력하세요: ");
                if (int.TryParse(Console.ReadLine(), out age)) {
                    if (age > 0)
                        break;
                }
                Console.WriteLine("자연수를 입력하세요.");
            }
            Console.WriteLine($"안녕하세요, {name}! 당신은 {age}세 이군요.");
            Console.WriteLine("==================================================================");
            Console.Write("첫 번째 수를 입력하세요: ");
            int first = 0;
            while (true) {
                if (int.TryParse(Console.ReadLine(), out first)) break;
            }
            Console.Write("두 번째 수를 입력하세요: ");
            int second = 0;
            while (true) {
                if (int.TryParse(Console.ReadLine(), out second)) break;
            }
            Console.WriteLine($"더하기: {first + second}\n빼기: {first - second}\n곱하기: {first * second}\n나누기: {first / (float)second}");
            Console.WriteLine("==================================================================");
            Console.Write($"섭씨 온도를 입력하세요: ");
            int temperature = 0;
            while (true) {
                if (int.TryParse(Console.ReadLine(), out temperature)) break;
            }
            Console.WriteLine($"변환된 화씨 온도: {(temperature * 9 / 5f) + 32}");
            Console.WriteLine("==================================================================");
            Console.Write("키를 입력하세요(cm): ");
            float height = 0;
            while (true) {
                if (float.TryParse(Console.ReadLine(), out height)) break;
            }
            Console.Write("몸무게를 입력하세요: ");
            float weight = 0;
            while (true) {
                if (float.TryParse(Console.ReadLine(), out weight)) break;
            }
            Console.WriteLine($"BMI = {weight / (height * height) * 10000}");
        }
    }
}
