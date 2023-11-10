using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class TownScene : Scene {

        public override string Title { get; protected set; } = "스파르타 마을";

        public override void EnterScene() {
            DrawScene();
        }
        public override void NextScene() {
            Console.ReadKey();
        }

        protected override void DrawScene() {
            Renderer.DrawBorder(Title);
            Renderer.Print(3, "스파르타 마을에 오신 여러분 환영합니다.");
            Renderer.Print(4, "이 곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Renderer.DrawInputArea();
        }
    }
}
