using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class TitleScene : Scene {
        public readonly string[] titleArt = {
            @" ██████╗  █████╗ ███╗   ███╗███████╗███╗   ██╗ █████╗ ███╗   ███╗███████╗",
            @"██╔════╝ ██╔══██╗████╗ ████║██╔════╝████╗  ██║██╔══██╗████╗ ████║██╔════╝",
            @"██║  ███╗███████║██╔████╔██║█████╗  ██╔██╗ ██║███████║██╔████╔██║█████╗  ",
            @"██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ██║╚██╗██║██╔══██║██║╚██╔╝██║██╔══╝  ",
            @"╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗██║ ╚████║██║  ██║██║ ╚═╝ ██║███████╗",
            @" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝",
            @"플레이하려면 아무 키나 누르세요.",
        };

        public override void EnterScene() {
            DrawScene();
        }
        public override void NextScene() {
            Console.ReadKey();
            Managers.Scene.EnterScene<CharacterSelectScene>();
        }

        protected override void DrawScene() {
            Renderer.DrawBorder();
            Renderer.PrintCenter(titleArt);
            Renderer.DrawInputArea();
        }
    }
}
