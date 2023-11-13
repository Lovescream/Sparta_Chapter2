using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class GameManager {
        public Character? CurrentCharacter { get; private set; } = null;

        public void Initialize() {

        }

        public void SelectCharacter(CharacterData data) {
            if (data == null) return;
            CurrentCharacter = new(data);
            CurrentCharacter.Inventory.Add(new Item(Managers.Data.Items["낡은 검"]));
            CurrentCharacter.Inventory.Add(new Item(Managers.Data.Items["낡은 검"]));
        }
    }
}
