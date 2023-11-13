using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class ShopScene : Scene {
        public override string Title { get; protected set; } = "상점";
        public List<ActionOption> Options { get; protected set; } = new();

        public override void EnterScene() {
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("ShopPurchase"));
            Options.Add(Managers.Scene.GetOption("ShopSell"));
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

            Renderer.Print(3, "필요한 아이템을 얻을 수 있는 상점입니다.");
            Renderer.Print(5, "[보유 골드]");
            Renderer.PrintHighlightNumber(6, $"{Managers.Game.CurrentCharacter.Gold} G");

            List<ItemTableFormatter> formatters = new() {
                Renderer.ItemTableFormatters["Index"],
                Renderer.ItemTableFormatters["Name"],
                Renderer.ItemTableFormatters["Effect"],
                Renderer.ItemTableFormatters["Desc"],
            };
            int nextLine = Renderer.DrawItemList(8, Managers.Game.Shop.Inventory.Items, formatters);

            Renderer.PrintOptions(++nextLine, Options);

            Renderer.DrawInputArea();
        }
    }
}
