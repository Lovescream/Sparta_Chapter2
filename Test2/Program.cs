namespace Test2 {
    internal class Program {
        static void Main(string[] args) {
            List<Character> list = new() {
                new(0, "Character0", "Fighter", 100, new List<string>(){ "Sword", "Potion", }),
                new(1, "Character1", "Archer", 10, new List<string>() { "Bow", "Arrow", }),
                new(2, "Character2", "Rogue", 1000, new List<string>() { "Lockpick", "Gold", })
            };

            List<string> nameList = list.Select(x => $"{x.name}_{x.className}").ToList();
            nameList.ForEach(Console.WriteLine);

            Console.WriteLine("==================================================================");

            var a = list.SelectMany(character => character.itemList, (character, item) => new { character.name, item });
            foreach (var element in a) {
                Console.WriteLine($"{element.name} has a {element.item}");
            }
        }
    }

    public class Character {
        public int index;
        public string name;
        public string className;
        public int hp;
        public List<string> itemList;

        public Character(int index, string name, string className, int hp, List<string> itemList) {
            this.index = index;
            this.name = name;
            this.className = className;
            this.hp = hp;
            this.itemList = itemList;
        }
    }
}