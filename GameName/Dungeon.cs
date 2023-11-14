using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class Dungeon {
        public string Name { get; private set; }
        public float RequiredDefense { get; private set; }
        public int DefaultReward { get; private set; }

        public Dungeon(string name, float requiredDefense, int defaultReward) {
            Name = name;
            RequiredDefense = requiredDefense;
            DefaultReward = defaultReward;
        }

        public int GetClearProbability(Character character) => character.Defense >= RequiredDefense ? 100 : 60;
        public bool EnterDungeon(Character character) => new Random().Next(0, 100) < GetClearProbability(character);
        public int Reward(Character character) => (int)(DefaultReward * (1 + (new Random().Next((int)character.Damage, (int)(character.Damage * 2)) / 100f)));
        public int Damage(Character character) {
            int min = 20 + (int)(character.Defense - RequiredDefense);
            int max = 35 + (int)(character.Defense - RequiredDefense);
            return new Random().Next(min, max + 1);
        }
    }
}
