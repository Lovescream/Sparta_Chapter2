using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TextGame {
    // Console.BackgroundColor = ConsoleColor.Red; 데미지 입었을 때 화면이 빨간색으로 변하면 재밌겠다
    internal class Program {
        private static Character player;
        private static Item[] items;

        static void Main(string[] args) {
            GameDataSetting();
            GameLogo();
            DisplayGameIntro();
        }

        static void GameDataSetting() {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            items = new Item[10];
            AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 0, 5, 0));
            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 1, 2, 0, 0));
            AddItem(new Item("고양이 수염", "고양이 수염은 행운을 가져다 줍니다. 야옹!", 1, 7, 7, 7));
        }

        // 아이템 추가
        static void AddItem(Item item) {
            if (Item.ItemCount == 10) return; // 아이템이 꽉차면 아무일도 일어나지 않는다
            items[Item.ItemCount] = item; // 0개 -> items[0], 1개 -> items[1] ...
            Item.ItemCount++;
        }

        // 게임로고
        static void GameLogo() {
            // 아스키 코드로 이루어진 타이틀 화면을 위한 인코딩 설정
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "= Sparta Dungeon =";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                               \r\n ####                  #          ######                                       \r\n##  #                 ##           ##  ##                                      \r\n###   ###   ##   ## # ###  ##      ##  ## ## ## # ##    ####  ###  ###  # ##   \r\n ###  ## # # ##  #### ##  # ##     ##  ## ## #  ## ##  ## #  ## # ## ## ## ##  \r\n  ### ## #  ###  ##   ##   ###     ##  ## ## #  ## ##  ## #  #### ## ## ## ##  \r\n#  ## ## # #  #  ##   ##  #  #     ##  ## ## #  ## ##   ###  ##   ## ## ## ##  \r\n####  ###  ##### ##    ## #####   ######   ###  ## ### ##     ###  ###  ## ### \r\n      ##                                               ####                    \r\n      ###                                              #  #                    \r\n                                                       ####                    ");
            Console.WriteLine();
            Console.WriteLine("          ===== 계속하려면 아무 키나 입력하십시오. =====          ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Beep();
        }

        static void DisplayGameIntro() {
            //GameDataSetting();
            Console.Clear();
            Console.Title = "= Sparta Village =";

            LineTextColor("==================================================");
            // 한글자씩 출력
            Console.ForegroundColor = ConsoleColor.Cyan;
            string starttxt = "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.";
            for (int i = 0; i < starttxt.Length; i++) {
                Console.Write(starttxt[i]);
                //Thread.Sleep(50);
            }
            Console.WriteLine();
            LineTextColor("==================================================");
            Console.WriteLine();
            ChooseTextColor("1. 상태 보기\n2. 인벤토리\n0. 메인화면");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = CheckValidInput(0, 2);
            switch (input) {
                case 0:
                    Console.Beep();
                    GameLogo();
                    break;
                case 1:
                    DisplayMyInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
            }
        }

        static void DisplayMyInfo() {
            Console.Clear();
            Console.Title = "= Information =";

            ChooseTextColor("= 상태 보기 =");
            LineTextColor("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            StatTextColor("Lv. ", player.Level.ToString("00")); // 00, 07 등 한자릿수도 두자릿수로 표현하기 위해 string 타입으로 변환
            Console.WriteLine();
            Console.WriteLine("{0} ( {1} )", player.Name, player.Job);
            StatTextColor("공격력 : ", player.Atk.ToString());
            Console.WriteLine();
            StatTextColor("방어력 : ", player.Def.ToString());
            Console.WriteLine();
            StatTextColor("체 력 : ", player.Hp.ToString());
            Console.WriteLine();
            StatTextColor("Gold : ", player.Gold.ToString());
            Console.WriteLine();
            Console.WriteLine();
            ChooseTextColor("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = CheckValidInput(0, 0);
            switch (input) {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static void DisplayInventory() {
            Console.Clear();
            Console.Title = "= inventory =";

            ChooseTextColor("인벤토리");
            LineTextColor("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            ChooseTextColor("[아이템 목록]");

            for (int i = 0; i < Item.ItemCount; i++) {
                items[i].ItemStat();
            }

            Console.WriteLine("");
            ChooseTextColor("1. 장착 관리\n0. 나가기");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = CheckValidInput(0, 1);
            switch (input) {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    DisplayerEquip();
                    break;
            }
        }

        static void DisplayerEquip() {
            //Console.Clear();
            //Console.Title = "= Equip =";

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("인벤토리 - 장착 관리");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("[아이템 목록]");
            //Console.Write("- " + $"{item.Armor}\t"); // 배열? 리스트?
            //Console.WriteLine("| 방어력 " + $"{item.DefOption}" + " | 무쇠로 만들어져 튼튼한 갑옷입니다.");
            //Console.Write("- " + $"{item.Weapon}\t");
            //Console.WriteLine("| 공격력 " + $"{item.AtkOption}" + " | 쉽게 볼 수 있는 낡은 검 입니다.");
            //Console.WriteLine($"체력 : {player.Hp}");
            //Console.WriteLine($"Gold : {player.Gold} G");
            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("0. 나가기");
            //Console.WriteLine();
            //Console.ResetColor();
            //Console.WriteLine("원하시는 행동을 입력해주세요.");
            //Console.Write(">> ");

            //int input = CheckValidInput(0, 0);
            //switch (input)
            //{
            //    case 0:
            //        DisplayInventory();
            //        break;
            //}
        }

        // 선택지 메서드
        static int CheckValidInput(int min, int max) {
            while (true) {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess) {
                    if (ret >= min && ret <= max)
                        return ret;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // 정렬
        public static int GetPrintableLength(string str) {
            int length = 0;
            foreach (char c in str) {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter) {
                    length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else {
                    length += 1; // 나머지 문자에 대해 길이를 1로 취급
                }
            }

            return length;
        }
        public static string PadRightForMixedText(string str, int totalLength) {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }

        // 설명글씨색
        private static void LineTextColor(string line) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        // 선택지글씨색
        private static void ChooseTextColor(string line) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        // 스텟글씨색
        private static void StatTextColor(string s1, string s2, string s3 = "") {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ResetColor();
            Console.Write(s3);
        }
    }


    public class Character {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold) {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    public class Item {
        public string Name { get; }
        public string Description { get; }
        public int Type { get; }
        public int AtkOption { get; }
        public int DefOption { get; }
        public int HpOption { get; }
        public bool IsEquipped { get; set; }

        public static int ItemCount = 0; // static을 붙임으로 Item이라는 클래스에 귀속된다

        public Item(string name, string description, int type, int atkOption, int defOption, int hpOption, bool isEquipped = false) {
            Name = name;
            Description = description;
            Type = type;
            AtkOption = atkOption;
            DefOption = defOption;
            HpOption = hpOption;
            IsEquipped = isEquipped; // 변수명?이랑 매개변수명이랑 이름 어떻게 똑같은지
        }

        public void ItemStat(bool wearItem = false, int index = 0) {
            Console.Write("- ");
            if (IsEquipped) {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("E");
                Console.Write("]");
            }
            Console.Write(Name);
            Console.Write(" | ");

            if (AtkOption != 0) Console.Write($"AtkOption {(AtkOption >= 0 ? "+" : "")}{AtkOption} "); // 삼항연산자
            if (DefOption != 0) Console.Write($"DefOption {(DefOption >= 0 ? "+" : "")}{DefOption} "); // 옵션이 0이 아니라면 옵션수치를 내보내라
            if (HpOption != 0) Console.Write($"HpOption {(HpOption >= 0 ? "+" : "")}{HpOption} "); // [조건 ? 참 : 거짓]

            Console.Write(" | ");

            Console.WriteLine(Description);
        }
    }
}