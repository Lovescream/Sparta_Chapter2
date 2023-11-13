using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class ShopScene : Scene {
        public override string Title { get; protected set; } = "상점";
        public List<ActionOption> Options { get; protected set; } = new();
        public ShopState State { get; protected set; } = ShopState.Default;

        public override void EnterScene() {
            State = ShopState.Default;
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("ShopPurchase"));
            Options.Add(Managers.Scene.GetOption("ShopSell"));
            Options.Add(Managers.Scene.GetOption("Back"));
            DrawScene();
        }

        public void EnterState(ShopState state) {
            State = state;
            DrawScene();
            NextScene();
        }

        public override void NextScene() {
            while (true) {
                DrawScene();
                if (!int.TryParse(Console.ReadLine(), out int index)) continue;
                if (State == ShopState.Default) {
                    if (index <= 0 || Options.Count < index) continue;
                    Options[index - 1].Execute();
                    break;
                }
                else if (State == ShopState.Purchase) {
                    if (index < 0 || Managers.Game.Shop.Inventory.Items.Count < index) continue;
                    if (index == 0) EnterState(ShopState.Default);
                    else {
                        // 해당 아이템 구매.
                        Item item = Managers.Game.Shop.Inventory.Items[index - 1];
                        Purchase(item);
                        continue;
                    }
                }
                else if (State == ShopState.Sell) {
                    if (index < 0 || Managers.Game.CurrentCharacter.Inventory.Items.Count < index) continue;
                    if (index == 0) EnterState(ShopState.Default);
                    else {
                        // 해당 아이템 판매.
                        Item item = Managers.Game.CurrentCharacter.Inventory.Items[index - 1];
                        Sell(item);
                        continue;
                    }
                }
            }
        }

        public bool Purchase(Item item) {
            if (item.Data.cost > Managers.Game.CurrentCharacter.Gold) return false;
            Managers.Game.CurrentCharacter.Gold -= item.Data.cost;
            Managers.Game.Shop.Inventory.Remove(item);
            Managers.Game.CurrentCharacter.Inventory.Add(item);
            return true;
        }
        public void Sell(Item item) {
            if (Managers.Game.CurrentCharacter.Inventory.IsEquipped(item))
                Managers.Game.CurrentCharacter.Inventory.Unequip(item.Data.type);
            Managers.Game.CurrentCharacter.Gold += (int)(item.Data.cost * 0.85f);
            Managers.Game.CurrentCharacter.Inventory.Remove(item);
            Managers.Game.Shop.Inventory.Add(item);
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);

            // #1. 안내 메시지 출력.
            Renderer.Print(3, State switch {
                ShopState.Default => "필요한 아이템을 얻을 수 있는 상점입니다.",
                ShopState.Purchase => "구입할 아이템 번호를 입력해주세요.",
                ShopState.Sell => "판매할 아이템 번호를 입력해주세요.",
                _ => ""
            });

            // #2. 보유 골드 출력.
            Renderer.Print(5, "[보유 골드]");
            Renderer.PrintHighlightNumber(6, $"{Managers.Game.CurrentCharacter.Gold} G");

            // #3. 리스트 속성 준비.
            List<ItemTableFormatter> formatters = new() {
                Renderer.ItemTableFormatters["Index"],
                Renderer.ItemTableFormatters["Name"],
                Renderer.ItemTableFormatters["Effect"],
                Renderer.ItemTableFormatters["Desc"],
            };
            if (State == ShopState.Purchase) {
                formatters.Add(Renderer.ItemTableFormatters["Cost"]);
            }
            else if (State == ShopState.Sell) {
                formatters.Insert(1, Renderer.ItemTableFormatters["Equip"]);
                formatters.Add(Renderer.ItemTableFormatters["SellCost"]);
            }

            // #4. 아이템 리스트 출력.
            List<Item> itemList = State switch {
                ShopState.Sell => Managers.Game.CurrentCharacter.Inventory.Items,
                _ => Managers.Game.Shop.Inventory.Items,
            };
            int nextLine = Renderer.DrawItemList(8, itemList, formatters, State == ShopState.Sell ? Managers.Game.CurrentCharacter.Inventory : null);

            // #5. 선택지 출력.
            if (State == ShopState.Default)
                Renderer.PrintOptions(++nextLine, Options);
            else
                Renderer.PrintHighlightNumber(++nextLine, "0. 나가기");
            

            Renderer.DrawInputArea();
        }
    }

    public enum ShopState {
        Default,
        Purchase,
        Sell,
    }
}
