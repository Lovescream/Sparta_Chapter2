using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName
{
    public class Scene {

        public virtual string Title { get; protected set; } = "";

        public virtual void EnterScene() {

        }
        
        public virtual void NextScene() {

        }

        protected virtual void DrawScene() {

        }

    }
}
