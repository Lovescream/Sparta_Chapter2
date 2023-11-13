using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameName {
    public class SceneManager {
        public Scene? CurrentScene { get; private set; }
        public Scene? PrevScene { get; private set; }

        private Dictionary<string, Scene> Scenes = new();
        private Dictionary<string, ActionOption> Options = new();

        public void Initialize() {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Scene");
            foreach (FileInfo info in directoryInfo.GetFiles()) {
                string sceneName = Path.GetFileNameWithoutExtension(info.FullName);
                Type? type = Type.GetType($"GameName.{sceneName}");
                if (type != null) {
                    Scene? scene = Activator.CreateInstance(type) as Scene;
                    Scenes.Add(sceneName, scene);
                }
            }
            
            Options.Add("ShowInfo", new("ShowInfo", "상태보기", () => EnterScene<CharacterInfoScene>()));
            Options.Add("Inventory", new("Inventory", "인벤토리", () => EnterScene<InventoryItemListScene>()));
            Options.Add("EquipManage", new("EquipManage", "장착관리", () => EnterScene<InventoryEquipScene>()));
            Options.Add("Back", new("Back", "뒤로가기", () => EnterScene<Scene>(PrevScene.GetType().Name)));
        }

        public ActionOption GetOption(string key) => Options[key];
        public void EnterScene<T>(string? sceneKey = null) where T : Scene {
            // #1. Scene 불러오기.
            if (string.IsNullOrEmpty(sceneKey)) sceneKey = typeof(T).Name;
            if (!Scenes.TryGetValue(sceneKey, out Scene? scene)) return;
            if (scene == null || scene == CurrentScene) return;

            // #2. 이전 씬 설정: 인벤토리 및 하위 씬은 이전 씬으로 등록하지 않는다.
            if (CurrentScene is not InventoryEquipScene && CurrentScene is not InventoryItemListScene)
                PrevScene = CurrentScene;

            // #3. 현재 씬 진입.
            CurrentScene = scene;
            scene.EnterScene();
            scene.NextScene();
        }
    }
}
