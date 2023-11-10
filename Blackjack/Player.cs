using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class Player : IPlayer {
        public Hand Hand { get; } = new();

        public bool ShouldDraw() {
            Console.Write("카드를 더 뽑으시겠습니까? (Y/N): ");
            while (true) {
                string? input = Console.ReadLine();
                if (input == null) continue;
                else if (input.ToUpper() == "Y") return true;
                else if (input.ToUpper() == "N") return false;
                else {
                    Console.WriteLine("올바른 값을 입력해주세요!");
                }
            }
        }
    }
}
