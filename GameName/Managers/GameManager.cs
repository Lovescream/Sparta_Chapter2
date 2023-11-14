using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class GameManager {
        public Character? CurrentCharacter { get; private set; } = null;
        public Shop Shop { get; private set; }
        public Dictionary<string, Dungeon> Dungeons { get; private set; } = new();

        public void Initialize() {
            Shop = new();
            Dungeons.Add("뿡빵이네 집", new("뿡빵이네 집", 5, 1000));
            Dungeons.Add("꽝꽝이네 집", new("꽝꽝이네 집", 11, 1700));
            Dungeons.Add("펑팡이네 집", new("펑팡이네 집", 17, 2500));
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
