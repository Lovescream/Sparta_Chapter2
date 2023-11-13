using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public static class Renderer {

        private static readonly int inputAreaHeight = 1;
        private static readonly string inputAreaString = ">> ";
        private static readonly int printMargin = 2;

        public static Dictionary<string, ItemTableFormatter> ItemTableFormatters = new();

        private static int width;
        private static int height;

        public static void Initialize() {
            Console.Title = "GameName";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            ItemTableFormatters["Index"] = new("Index", "", 2, null);
            ItemTableFormatters["Equip"] = new("Equip", "", 3, null);
            ItemTableFormatters["Name"] = new("Name", "이름", 20, i => i.Data.name);
            ItemTableFormatters["Effect"] = new("Effect", "효과", 15, i => i.Effect);
            ItemTableFormatters["Desc"] = new("Desc", "설명", 50, i => i.Data.description);
            ItemTableFormatters["Cost"] = new("Cost", "비용", 10, i => i.Data.cost.ToString());
            ItemTableFormatters["SellCost"] = new("SellCost", "비용", 10, i => (i.Data.cost * 0.85f).ToString());
        }

        public static void Print(int line, string content) {
            Console.SetCursorPosition(printMargin, line);
            Console.WriteLine(content);
        }
        public static void PrintHighlight(int line, string contentNormal, string contentHighlight) {
            Console.SetCursorPosition(printMargin, line);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(contentNormal);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(contentHighlight);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void PrintHighlightNumber(int line, string content) {
            Console.SetCursorPosition(printMargin, line);
            foreach (char c in content) {
                if (int.TryParse(c.ToString(), out int num)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(num);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else {
                    Console.Write(c);
                }
            }
            Console.WriteLine();
        }
        public static void DrawHpBar(int x, int y, Character character) {
            Console.SetCursorPosition(x, y);
            int barLength = 10;
            int hpLength = (int)((character.Hp / character.HpMax) * 10);
            Console.Write(new string('■', hpLength));
            Console.Write(new string('□', barLength - hpLength));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" ({character.Hp} / {character.HpMax})");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void PrintCenter(string[] lines) {
            int textHeight = lines.Length;

            int verticalStart = (height - textHeight) / 2;
            for (int i = 0; i < lines.Length; i++) {
                int correctLength = GetPrintingLength(lines[i]);
                int horizontalStart = (width - correctLength) / 2;
                if (horizontalStart < 0) horizontalStart = 0;
                Console.SetCursorPosition(horizontalStart, verticalStart + i);
                Console.WriteLine(lines[i]);
            }
        }

        public static void DrawBorder(string title = "") {
            Console.Clear();
            width = Console.WindowWidth;
            height = Console.WindowHeight;

            Console.SetCursorPosition(0, 0);
            Console.Write(new string('=', width));
            for (int i = 1; i < height - inputAreaHeight - 2; i++) {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Console.SetCursorPosition(width - 1, i);
                Console.Write('║');
            }
            if (!string.IsNullOrEmpty(title)) {
                Console.SetCursorPosition(0, 2);
                Console.Write(new string('=', width));
                int correctLength = GetPrintingLength(title);
                int horizontalStart = (width - correctLength) / 2;
                if (horizontalStart < 0) horizontalStart = 3;
                Console.SetCursorPosition(horizontalStart, 1);
                Console.WriteLine(title);
            }
            Console.SetCursorPosition(0, height - inputAreaHeight - 2);
            Console.Write(new string('=', width));
        }

        public static void DrawInputArea() {
            Console.SetCursorPosition(0, height - inputAreaHeight - 1);
            Console.Write(inputAreaString);
            Console.SetCursorPosition(inputAreaString.Length, height - inputAreaHeight - 1);
        }

        public static void PrintOptions(int line, List<ActionOption> options, bool fromZero = false) {
            for (int i = 0; i < options.Count; i++) {
                ActionOption option = options[i];
                Console.SetCursorPosition(printMargin, line);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fromZero ? i : i + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(". ");
                Console.Write(option.Description);
                line++;
            }
        }

        #region Character

        public static int PrintCharacterInfo(Character character, int startRow) {
            PrintHighlight(startRow++, $"{character.Name} Lv ", character.Level.ToString());
            PrintHighlight(startRow++, $"직업: ", character.Data.type.ToString());
            Print(startRow, $"체력: ");
            DrawHpBar(printMargin + GetPrintingLength("체력: "), startRow++, character);
            if (character.Inventory.EquippedWeapon != null)
                PrintHighlightNumber(startRow++, $"공격력: {character.Data.damage} (+{character.Inventory.EquippedWeapon.Data.damageModifier})");
            else
                PrintHighlight(startRow++, $"공격력: ", character.Data.damage.ToString());
            if (character.Inventory.EquippedArmor != null)
                PrintHighlightNumber(startRow++, $"방어력: {character.Data.defense} (+{character.Inventory.EquippedArmor.Data.defenseModifier})");
            else 
                PrintHighlight(startRow++, $"방어력: ", character.Data.defense.ToString());


            PrintHighlight(startRow++, $"골드: ", character.Gold.ToString());

            return startRow;
        }

        #endregion

        #region Inventory

        public static int DrawItemList(int startRow, List<Item> items, List<ItemTableFormatter> formatterList, Inventory inventory = null) {
            // #1. 그리기 준비.
            int row = startRow;

            // #2. 상위 행 그리기.
            string s0 = "|";
            string s1 = "|";
            for (int i = 0; i < formatterList.Count; i++) {
                ItemTableFormatter formatter = formatterList[i];
                s0 += $"{formatter.GetString()}|";
                s1 += $"{formatter.GetString(index: -1)}|";
            }
            Print(row++, s0);
            Print(row++, s1);

            // #3. 본문 행 그리기.
            for (int i = 0; i < items.Count; i++) {
                Item item = items[i];
                string content = "|";
                for (int j = 0; j < formatterList.Count; j++) {
                    ItemTableFormatter formatter = formatterList[j];
                    if (formatter.key == "Index") content += $"{formatter.GetString(index: i + 1)}|";
                    else if (formatter.key == "Equip") content += $"{formatter.GetString(item, inventory: inventory)}|";
                    else content += $"{formatter.GetString(item)}|";
                }
                Print(row++, content);
            }
            return row;
        }

        //public static int DrawInventory(Inventory inventory, int startRow) {
        //    // #1. 그리기 준비.
        //    List<Item> itemList = inventory.Items;
        //    string[] line = new string[7];
        //    line[0] = line[line.Length - 1] = "";
        //    int row = startRow;

        //    // #2. 상위 행 그리기.
        //    line[1] = GetInventoryElementString(2, "", true);
        //    line[2] = GetInventoryElementString(3, "", true);
        //    line[3] = GetInventoryElementString(10, "이름", true);
        //    line[4] = GetInventoryElementString(15, "효과", true);
        //    line[5] = GetInventoryElementString(50, "설명", true);
        //    Print(row++, String.Join('|', line));
        //    line[1] = GetInventoryElementString(2, "=", false);
        //    line[2] = GetInventoryElementString(3, "=", false);
        //    line[3] = GetInventoryElementString(10, "=", false);
        //    line[4] = GetInventoryElementString(15, "=", false);
        //    line[5] = GetInventoryElementString(50, "=", false);
        //    Print(row++, String.Join('|', line));

        //    // #3. 본문 행 그리기.
        //    for (int i = 0; i < itemList.Count; i++) {
        //        Item item = itemList[i];
        //        line[1] = GetInventoryElementString(2, (i + 1).ToString(), false);
        //        line[2] = GetInventoryElementString(3, inventory.IsEquipped(item) ? "[E]" : "", false);
        //        line[3] = GetInventoryElementString(10, item.Data.name, false);
        //        line[4] = GetInventoryElementString(15, item.Effect, false);
        //        line[5] = GetInventoryElementString(50, item.Data.description, false);
        //        Print(row++, String.Join('|', line));
        //    }
        //    return row;
        //}

        public static string GetInventoryElementString(int maxLength, string data, bool isTitle = false) {
            int dataLength = GetPrintingLength(data);
            if (data == "=") return new string('=', maxLength);
            StringBuilder builder = new();
            int spaceCount = maxLength - dataLength;
            int margin = isTitle ? 2 : 1;
            int leftCount = Math.Clamp(spaceCount / 2, 0, margin);
            builder.Append(' ', leftCount);
            builder.Append(data);
            builder.Append(' ', spaceCount - leftCount);
            return builder.ToString();
        }

        #endregion

        #region Table

        public static void DrawTable(Table table, int startRow) {
            // #1. 그리기 준비.
            TableDataType[] types = table.GetTypes();
            string[] line = new string[types.Length + 2];
            line[0] = line[line.Length - 1] = "";
            int row = startRow;

            // #1. 상위 행 그리기.
            for (int i = 0; i < types.Length; i++) {
                line[i + 1] = GetTableElementString(types[i], types[i].name, true);
            }
            Print(row++, String.Join('|', line));
            for (int i = 0; i < types.Length; i++) {
                line[i + 1] = GetTableElementString(types[i], "=", false);
            }
            Print(row++, String.Join('|', line));

            // #2. 본문 행 그리기.
            for (int i = 0; i < table.GetDataCount(); i++) {
                string[] data = table.GetRow(i);
                for (int j = 0; j<data.Length;j++) {
                    line[j + 1] = GetTableElementString(types[j], data[j]);
                }
                Print(row++, String.Join('|', line));
            }
        }
        private static string GetTableElementString(TableDataType type, string data, bool isTitle = false) {
            int dataLength = GetPrintingLength(data);
            if (data == "=") return new string('=', type.length);
            StringBuilder builder = new();
            int spaceCount = type.length - dataLength;
            int margin = isTitle ? 2 : 1;
            int leftCount = type.center ? spaceCount / 2 : Math.Clamp(spaceCount / 2, 0, margin);
            builder.Append(' ', leftCount);
            builder.Append(data);
            builder.Append(' ', spaceCount - leftCount);
            return builder.ToString();
        }

        #endregion

        

        #region Support

        private static int GetPrintingLength(string line) => line.Sum(c => IsKorean(c) ? 2 : 1);
        private static bool IsKorean(char c) => '가' <= c && c <= '힣';

        #endregion
    }

    public class ItemTableFormatter {
        public string key;
        public string description;
        public int length;
        public Func<Item, string> dataSelector;

        public ItemTableFormatter(string key, string description, int length, Func<Item, string> dataSelector) {
            this.key = key;
            this.description = description;
            this.length = length;
            this.dataSelector = dataSelector;
        }

        public string GetString(Item item = null, int index = -2, Inventory inventory = null) {
            if (index == -1) return Renderer.GetInventoryElementString(length, "=", false);
            else if (index >= 0) return Renderer.GetInventoryElementString(length, index.ToString(), false);
            if (inventory != null && item != null) return Renderer.GetInventoryElementString(length, inventory.IsEquipped(item) ? "[E]" : "", false);
            if (item == null) return Renderer.GetInventoryElementString(length, description, true);
            return Renderer.GetInventoryElementString(length, dataSelector(item), false);
        }
    }
}
