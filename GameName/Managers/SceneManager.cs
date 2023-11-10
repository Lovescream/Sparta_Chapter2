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
        }

        public void EnterScene<T>(string? sceneKey = null) where T : Scene {
            if (string.IsNullOrEmpty(sceneKey)) sceneKey = typeof(T).Name;
            if (!Scenes.TryGetValue(sceneKey, out Scene? scene)) return;
            if (scene == null || scene == CurrentScene) return;
            PrevScene = CurrentScene;
            CurrentScene = scene;

            scene.EnterScene();
            scene.NextScene();
        }

    }
}
