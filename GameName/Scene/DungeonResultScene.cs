using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class DungeonResultScene : Scene {
        public override string Title { get; protected set; } = "탐험 결과";
        public List<ActionOption> Options { get; protected set; } = new();

        private Dungeon dungeon;
        private bool isClear;
        private int originGold;
        private int originHp;

        public void SetDungeon(Dungeon dungeon) => this.dungeon = dungeon;

        public override void EnterScene() {
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("Back"));

            Character character = Managers.Game.CurrentCharacter;
            isClear = dungeon.EnterDungeon(character);
            originHp = (int)character.Hp;
            character.Hp -= isClear ? dungeon.Damage(character) : (int)character.Hp / 2;
            originGold = character.Gold;
            int r = dungeon.Reward(character);
            character.Gold += isClear ? r : 0;
            

            DrawScene();
        }

        public override void NextScene() {
            base.NextScene();
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

            Renderer.Print(4, isClear ? "축하합니다!" : "아쉽습니다...");
            Renderer.Print(5, isClear ? $"{dungeon.Name} 탐험에 성공했습니다!" : $"{dungeon.Name} 탐험에 실패했습니다...");
            Renderer.Print(7, "[탐험 결과]");
            Renderer.PrintHighlightNumber(8, $"체력 {originHp} -> {Managers.Game.CurrentCharacter.Hp}");
            Renderer.PrintHighlightNumber(9, $"골드 {originGold} -> {Managers.Game.CurrentCharacter.Gold}");

            Renderer.PrintOptions(11, Options);

            Renderer.DrawInputArea();
        }
    }
}
