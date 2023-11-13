using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class Shop {

        public Inventory Inventory { get; set; }

        public Shop() {
            Inventory = new(null);
            foreach (ItemData itemData in Managers.Data.Items.Values) {
                Inventory.Add(new Item(itemData));
            }
        }

    }
}
