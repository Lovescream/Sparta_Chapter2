using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class Item {

        public ItemData Data { get; private set; }

        public Item(ItemData data) => Data = data;

        public string Effect {
            get {
                if (Data.hpModifier > 0) return $"체력 +{Data.hpModifier}";
                else if (Data.damageModifier > 0) return $"공격력 +{Data.damageModifier}";
                else if (Data.defenseModifier > 0) return $"방어력 +{Data.defenseModifier}";
                else return "";
            }
        }
    }
}
