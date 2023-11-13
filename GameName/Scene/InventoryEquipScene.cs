using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class InventoryEquipScene : Scene {
        public override string Title { get; protected set; } = "장착 관리";
        public List<ActionOption> Options { get; protected set; } = new();

        private Inventory inventory;

        public override void EnterScene() {
            inventory = Managers.Game.CurrentCharacter.Inventory;
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("Inventory"));
            DrawScene();
        }

        public override void NextScene() {
            while(true) {
                DrawScene();
                if (!int.TryParse(Console.ReadLine(), out int index)) continue;
                if (index < 0 || inventory.Items.Count < index) continue;
                if (index == 0) {
                    Options[0].Execute();
                    break;
                }
                else {
                    Item item = inventory.Items[index - 1];
                    if (inventory.IsEquipped(item)) inventory.Unequip(item.Data.type);
                    else inventory.Equip(item);
                }
            }
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);
            Renderer.Print(3, "보유중인 아이템을 관리할 수 있습니다.");
            Renderer.Print(4, "장착하거나 장착해제할 아이템을 선택하세요.");
            Renderer.Print(5, "인벤토리로 돌아가려면 0을 입력해주세요.");

            Renderer.DrawInventory(Managers.Game.CurrentCharacter.Inventory, 7);


            Renderer.DrawInputArea();
        }
    }


}
