using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class Character {

        #region Properties

        public CharacterData Data { get; private set; }
        public string Name => string.IsNullOrEmpty(name) ? Data.name : name;
        public int Gold { get; private set; }
        public float HpMax => Data.hp + hpModifier;
        public float Damage => Data.damage + damageModifier;
        public float Defense => Data.defense + defenseModifier;
        public float Hp => hp;
        public int Level => level;
        #endregion

        #region Fields

        private string name;
        private float hp;
        private float hpModifier = 0;
        private float damageModifier = 0;
        private float defenseModifier = 0;

        private int level = 1;

        #endregion

        public Character(CharacterData data, string name = "") {
            this.Data = data;
            this.name = name;

            this.hp = HpMax;
        }

        public void SetName(string name) => this.name = name;
    }
}
