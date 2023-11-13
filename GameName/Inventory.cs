using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class Inventory {

        #region Properties

        public Character Owner { get; private set; }

        public Item? EquippedWeapon => Equipped[ItemType.Weapon];
        public Item? EquippedArmor => Equipped[ItemType.Armor];

        public List<Item> Items { get; private set; } = new List<Item>();

        #endregion

        #region Fields

        private Dictionary<ItemType, Item?> Equipped;

        #endregion

        public Inventory(Character owner) {
            Equipped = new() {
                {ItemType.Weapon, null },
                {ItemType.Armor, null },
            };
            Owner = owner;
        }

        #region Add / Remove

        public void Add(Item item) {
            Items.Add(item);
            Items = Items.OrderBy(x => x.Data.name.Length).ToList();
        }

        public void Remove(Item item) {
            Items.Remove(item);
            Items = Items.OrderBy(x => x.Data.name.Length).ToList();
        }

        #endregion

        #region Equip

        public bool IsEquipped(Item item) => EquippedWeapon == item || EquippedArmor == item;
        public void Equip(Item item) {
            if (item.Data.type != ItemType.Weapon && item.Data.type != ItemType.Armor) return;
            if (Equipped[item.Data.type] != null) Unequip(item.Data.type);
            Equipped[item.Data.type] = item;
            Owner.OnEquip(item);
        }
        
        public void Unequip(ItemType type) {
            if (type != ItemType.Weapon || type != ItemType.Armor) return;
            if (Equipped[type] == null) return;
            Owner.OnUnequip(Equipped[type]);
            Equipped[type] = null;
        }

        #endregion

    }
}
