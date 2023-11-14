using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class RestScene : Scene {
        public override string Title { get; protected set; } = "휴식하기";
        public List<ActionOption> Options { get; protected set; } = new();
        public RestResult State { get; protected set; } = RestResult.None;

        private int healAmount;

        public override void EnterScene() {
            State = RestResult.None;
            Options.Clear();
            Options.Add(Managers.Scene.GetOption("ConfirmRest"));
            Options.Add(Managers.Scene.GetOption("Back"));
            SetHealAmount();
            DrawScene();
        }

        public override void NextScene() {
            while (true) {
                SetHealAmount();
                DrawScene();
                if (!int.TryParse(Console.ReadLine(), out int index)) continue;
                if (index <= 0 || Options.Count < index) continue;
                Options[index - 1].Execute();
                break;
            }
        }

        public void Rest() {
            if (Managers.Game.CurrentCharacter.Gold >= 500) {
                Managers.Game.CurrentCharacter.Gold -= 500;
                Managers.Game.CurrentCharacter.Hp += healAmount;
                State = RestResult.Success;
            }
            else {
                State = RestResult.Fail;
            }
            DrawScene();
            NextScene();

        }

        private void SetHealAmount() {
            healAmount = (int)(Managers.Game.CurrentCharacter.HpMax * 0.5f);
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);

            // #1. 안내 메시지 출력.
            int row = 4;
            if (State == RestResult.Success) {
                Renderer.PrintHighlightNumber(row, $"휴식했습니다. (Hp +{healAmount})");
                row += 2;
            }
            else if (State == RestResult.Fail) {
                Renderer.Print(row, "돈이 부족하여 휴식할 수 없었습니다.");
                row += 2;
            }
            Renderer.PrintHighlightNumber(row++, $"500 G를 지불하고 휴식을 취해 체력을 {healAmount} 회복할 수 있습니다. (보유 골드: {Managers.Game.CurrentCharacter.Gold} G)");
            Renderer.Print(row, "     체력: ");
            Renderer.DrawHpBar(13, row++, Managers.Game.CurrentCharacter);

            // #2. 선택지 출력.
            Renderer.PrintOptions(++row, Options);


            Renderer.DrawInputArea();
        }

    }
    public enum RestResult {
        None,
        Success,
        Fail,
    }
}
