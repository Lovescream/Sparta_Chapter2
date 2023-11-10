using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class Dealer : IPlayer {
        public Hand Hand { get; } = new();
        public bool ShouldDraw() => Hand.Value < 17;
    }
}
