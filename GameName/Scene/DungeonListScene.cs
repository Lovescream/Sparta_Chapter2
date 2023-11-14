using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class DungeonListScene : Scene {
        public override string Title { get; protected set; } = "친구 집 탐험";
        public List<ActionOption> Options { get; protected set; } = new();

        private List<Dungeon> dungeonList = new();

        public override void EnterScene() {
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("Back"));
            dungeonList.Clear();
            dungeonList = Managers.Game.Dungeons.Values.ToList();
            DrawScene();
        }

        public override void NextScene() {
            while (true) {
                DrawScene();
                if (!int.TryParse(Console.ReadLine(), out int index)) continue;
                if (index < 0 || dungeonList.Count < index) continue;
                if (index == 0) Options[0].Execute();
                else {
                    (Managers.Scene.GetScene<DungeonResultScene>() as DungeonResultScene).SetDungeon(dungeonList[index - 1]);
                    Managers.Scene.EnterScene<DungeonResultScene>();
                }
                break;
            }
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);

            Renderer.Print(4, "오늘은 어떤 친구 집에 놀러가볼까요?");

            int nextLine = Renderer.PrintDungeonList(6, dungeonList);

            Renderer.PrintOptions(++nextLine, Options, true);

            Renderer.DrawInputArea();
        }
    }
}
