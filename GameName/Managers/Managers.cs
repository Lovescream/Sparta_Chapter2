using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {

    public static class Managers {

        private static DataManager data = new();
        private static SceneManager scene = new();
        private static GameManager game = new();
        public static DataManager Data => data;
        public static SceneManager Scene => scene;
        public static GameManager Game => game;

    }

}
