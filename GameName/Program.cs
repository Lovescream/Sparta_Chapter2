using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace GameName {
    public class Program {

        public static Dictionary<string, Scene> scenes = new();

        static void Main(string[] args) {
            DataTransformer.ParseData();
            Renderer.Initialize();
            Managers.Data.Initialize();
            Managers.Scene.Initialize();
            Managers.Game.Initialize();
            Initialize();
        }

        private static void Initialize() {
            Managers.Scene.EnterScene<TitleScene>();
        }
    }

    

    #region Enums

    public enum CharacterClassType {
        Fighter,
        Swordsman,
        Rogue,
        Archer,
        Wizard,
        Cleric,
    }

    public enum ItemType {
        Weapon,
        Armor,
        Consumable,
    }

    #endregion

}