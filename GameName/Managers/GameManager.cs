using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class GameManager {
        public Character? CurrentCharacter { get; private set; } = null;
        public Shop Shop { get; private set; }

        public void Initialize() {
            Shop = new();
        }

        public void SelectCharacter(CharacterData data) {
            if (data == null) return;
            CurrentCharacter = new(data);
            CurrentCharacter.Inventory.Add(new Item(Managers.Data.Items["낡은 검"]));
            CurrentCharacter.Inventory.Add(new Item(Managers.Data.Items["수련자 갑옷"]));
            CurrentCharacter.Gold += 2500;
        }
    }
}
