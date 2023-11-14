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
        public int Gold { get; set; }
        public float HpMax => Data.hp + hpModifier;
        public float Damage => Data.damage + damageModifier;
        public float Defense => Data.defense + defenseModifier;
        public float Hp {
            get => hp;
            set {
                if (value >= HpMax) hp = HpMax;
                else if (value <= 0) hp = 0;
                else hp = value;
            }
        }
        public int Level => level;
        
        public Inventory Inventory { get; private set; }
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
            Inventory = new(this);
        }

        public void SetName(string name) => this.name = name;

        public void OnEquip(Item item) {
            if (item == null) return;
            if (item.Data.hpModifier != 0)
                hpModifier += item.Data.hpModifier;
            if (item.Data.damageModifier != 0)
                damageModifier += item.Data.damageModifier;
            if (item.Data.defenseModifier != 0)
                defenseModifier += item.Data.defenseModifier;
        }

        public void OnUnequip(Item item) {
            if (item == null) return;
            if (item.Data.hpModifier != 0)
                hpModifier -= item.Data.hpModifier;
            if (item.Data.damageModifier != 0)
                damageModifier -= item.Data.damageModifier;
            if (item.Data.defenseModifier != 0)
                defenseModifier -= item.Data.defenseModifier;
        }
    }
}
