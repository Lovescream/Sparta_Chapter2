using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {

    public class DataManager {
        public Dictionary<string, CharacterData> Characters = new();
        public Dictionary<string, ItemData> Items = new();
        public Dictionary<string, Table> Tables = new();

        public void Initialize() {
            Characters = LoadJson<CharacterDataLoader, string, CharacterData>("CharacterData").MakeDictionary();
            Items = LoadJson<ItemDataLoader, string, ItemData>("ItemData").MakeDictionary();

            Table characterTable = new();
            characterTable.AddType("index", 7, false);
            characterTable.AddType("name", 20, false);
            characterTable.AddType("class", 20, false);
            characterTable.AddType("hp", 15, false);
            characterTable.AddType("damage", 15, false);
            characterTable.AddType("defense", 15, false);
            int index = 0;
            foreach (CharacterData data in Managers.Data.Characters.Values) {
                characterTable.AddData("index", (++index).ToString());
                characterTable.AddData("name", data.name);
                characterTable.AddData("class", data.type.ToString());
                characterTable.AddData("hp", data.hp.ToString());
                characterTable.AddData("damage", data.damage.ToString());
                characterTable.AddData("defense", data.defense.ToString());
            }
            Tables.Add("CharacterList", characterTable);
        }

        private Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value> where Key : notnull {
            string jsonData = File.ReadAllText($"{path}.json");
            return JsonConvert.DeserializeObject<Loader>(jsonData);
        }
    }

    #region Data

    public interface ILoader<Key, Value> where Key : notnull {
        Dictionary<Key, Value> MakeDictionary();
    }

    [Serializable]
    public class CharacterData {
        public string name;
        public CharacterClassType type;
        public float hp;
        public float damage;
        public float defense;
    }
    [Serializable]
    public class CharacterDataLoader : ILoader<string, CharacterData> {
        public List<CharacterData> data = new();

        public Dictionary<string, CharacterData> MakeDictionary() {
            Dictionary<string, CharacterData> dictionary = new();
            foreach (CharacterData data in data) { dictionary.Add(data.name, data); }
            return dictionary;
        }
    }
    [Serializable]
    public class ItemData {
        public string name;
        public ItemType type;
        public int cost;
        public float hpModifier;
        public float damageModifier;
        public float defenseModifier;
        public string description;
    }
    [Serializable]
    public class ItemDataLoader : ILoader<string, ItemData> {
        public List<ItemData> data = new();

        public Dictionary<string, ItemData> MakeDictionary() {
            Dictionary<string, ItemData> dictionary = new();
            foreach (ItemData data in data) dictionary.Add(data.name, data);
            return dictionary;
        }
    }


    #endregion


    #region Json

    public class DataTransformer {
        public static void ParseData() {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ParseCharacterData("Character");
            ParseItemData("Item");
        }
        private static void ParseCharacterData(string fileName) {
            CharacterDataLoader loader = new();

            string[] lines = File.ReadAllText($"{fileName}.csv", Encoding.GetEncoding(949)).Split("\n");

            for (int y = 1; y < lines.Length; y++) {
                string[] row = lines[y].Replace("\r", "").Split(',');
                if (row.Length == 0 || string.IsNullOrEmpty(row[0])) continue;

                loader.data.Add(new() {
                    name = row[0],
                    type = ConvertValue<CharacterClassType>(row[1]),
                    hp = ConvertValue<float>(row[2]),
                    damage = ConvertValue<float>(row[3]),
                    defense = ConvertValue<float>(row[4]),
                });
            }

            string jsonStr = JsonConvert.SerializeObject(loader, Formatting.Indented);
            File.WriteAllText($"{fileName}Data.json", jsonStr);
        }
        private static void ParseItemData(string fileName) {
            ItemDataLoader loader = new();

            string[] lines = File.ReadAllText($"{fileName}.csv", Encoding.GetEncoding(949)).Split("\n");

            for (int y = 1; y < lines.Length; y++) {
                string[] row = lines[y].Replace("\r", "").Split(',');
                if (row.Length == 0 || string.IsNullOrEmpty(row[0])) continue;

                loader.data.Add(new() {
                    name = row[0],
                    type = ConvertValue<ItemType>(row[1]),
                    cost = ConvertValue<int>(row[2]),
                    hpModifier = ConvertValue<float>(row[3]),
                    damageModifier = ConvertValue<float>(row[4]),
                    defenseModifier = ConvertValue<float>(row[5]),
                    description = row[6],
                });
            }

            string jsonStr = JsonConvert.SerializeObject(loader, Formatting.Indented);
            File.WriteAllText($"{fileName}Data.json", jsonStr);
        }

        #region Support

        private static T? ConvertValue<T>(string value) {
            if (string.IsNullOrEmpty(value)) return default;
            var obj = TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
            return obj == null ? default : (T)obj;
        }
        private static List<T?> ConvertList<T>(string value) {
            if (string.IsNullOrEmpty(value)) return new();
            return value.Split('|').Select(x => ConvertValue<T>(x)).ToList();
        }

        #endregion
    }

    #endregion
}
