using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class CharacterSelectScene : Scene {
        public override string Title { get; protected set; } = "캐릭터 선택";

        private List<CharacterData> dataList = new();

        public override void EnterScene() {
            DrawScene();
            dataList = Managers.Data.Characters.Values.ToList();
        }

        public override void NextScene() {
            while (true) {
                DrawScene();
                if (!int.TryParse(Console.ReadLine(), out int index)) continue;
                if (index <= 0 || dataList.Count < index) continue;
                Managers.Game.SelectCharacter(dataList[index - 1]);
                break;
            }
            Managers.Scene.EnterScene<CharacterConfirmScene>();
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);
            Renderer.Print(3, "플레이할 캐릭터를 선택해주세요!");
            Renderer.DrawTable(Managers.Data.Tables["CharacterList"], 5);
            Renderer.DrawInputArea();
        }

    }
}
