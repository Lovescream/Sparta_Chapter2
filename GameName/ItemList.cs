using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class ItemList {
        public List<Item> Items { get; private set; } = new();

        public void Add(Item item) {
            Items.Add(item);
            Items = Items.OrderBy(x => x.Data.name.Length).ToList();
        }
        public void Remove(Item item) {
            Items.Remove(item);
            Items = Items.OrderBy(x => x.Data.name.Length).ToList();
        }
    }
}
