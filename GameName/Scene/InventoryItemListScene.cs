using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class InventoryItemListScene : Scene {
        public override string Title { get; protected set; } = "아이템 목록";
        public List<ActionOption> Options { get; protected set; } = new();

        public override void EnterScene() {
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("EquipManage"));
            Options.Add(Managers.Scene.GetOption("Back"));
            DrawScene();
        }

        public override void NextScene() {
            while (true) {
                DrawScene();
                if (!int.TryParse(Console.ReadLine(), out int index)) continue;
                if (index <= 0 || Options.Count < index) continue;
                Options[index - 1].Execute();
                break;
            }
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);
            Renderer.Print(3, "캐릭터가 보유중인 아이템 목록입니다.");

            //int nextLine = Renderer.DrawInventory(Managers.Game.CurrentCharacter.Inventory, 5);
            List<ItemTableFormatter> formatters = new() {
                Renderer.ItemTableFormatters["Index"],
                Renderer.ItemTableFormatters["Equip"],
                Renderer.ItemTableFormatters["Name"],
                Renderer.ItemTableFormatters["Effect"],
                Renderer.ItemTableFormatters["Desc"],
            };
            int nextLine = Renderer.DrawItemList(5, Managers.Game.CurrentCharacter.Inventory.Items, formatters, Managers.Game.CurrentCharacter.Inventory);

            Renderer.PrintOptions(++nextLine, Options);

            Renderer.DrawInputArea();
        }

    }
}
