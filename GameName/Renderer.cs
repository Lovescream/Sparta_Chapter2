using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public static class Renderer {

        private static readonly int inputAreaHeight = 1;
        private static readonly string inputAreaString = ">> ";
        private static readonly int printMargin = 2;

        private static int width;
        private static int height;

        public static void Initialize() {
            Console.Title = "GameName";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
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

        #region Character

        public static int PrintCharacterInfo(Character character, int startRow) {
            PrintHighlight(startRow++, $"{character.Name} Lv ", character.Level.ToString());
            PrintHighlight(startRow++, $"직업: ", character.Data.type.ToString());
            Print(startRow, $"체력: ");
            DrawHpBar(printMargin + GetPrintingLength("체력: "), startRow++, character);
            PrintHighlight(startRow++, $"공격력: ", character.Damage.ToString());
            PrintHighlight(startRow++, $"방어력: ", character.Defense.ToString());
            PrintHighlight(startRow++, $"골드: ", character.Gold.ToString());

            return startRow;
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
        private static bool IsKorean(char c) => '가' < c && c <= '힣';

        #endregion
    }
}
