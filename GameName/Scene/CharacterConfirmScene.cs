using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class CharacterConfirmScene : Scene {

        public override string Title { get; protected set; } = "캐릭터 확인";

        public override void EnterScene() {
            DrawScene();
        }

        public override void NextScene() {
            string input = Console.ReadLine() ?? "";
            if (input == "No") {
                Managers.Scene.EnterScene<CharacterSelectScene>();
            }
            else {
                Managers.Game.CurrentCharacter.SetName(input);
                Managers.Scene.EnterScene<TownScene>();
            }
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);
            Renderer.Print(5, "정말로 이 캐릭터를 선택하시겠어요?");
            Renderer.Print(6, "다른 캐릭터를 선택하려면 'No'라고 입력해주세요.");
            Renderer.Print(7, "이 캐릭터를 선택하려면, 캐릭터의 이름을 정해주세요.");
            Renderer.Print(8, "빈 칸으로 설정하면 기본 이름이 사용됩니다.");

            Renderer.PrintCharacterInfo(Managers.Game.CurrentCharacter, 11);
            Renderer.DrawInputArea();
        }
    }
}
