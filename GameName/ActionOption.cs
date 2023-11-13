using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class ActionOption {

        public string Key { get; private set; }
        public string Description { get; private set; }
        public Action Action { get; private set; }
        public ActionOption(string key, string description, Action action) {
            Key = key;
            Description = description;
            Action = action;
        }

        public void Execute() {
            Action?.Invoke();
        }

    }
}
