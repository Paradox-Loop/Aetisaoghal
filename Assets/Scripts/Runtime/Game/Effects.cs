using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Effects : Effect
    {
        public class Ressource
        {
            private int amount;
            private EnumLibrary.Ressources type;
        }

        public class Healing
        {
            private int amount;
        }

        public class Damage
        {
            private int amount;
        }

        public class Buff
        {
            private int power;
            private int hp;
            private List<Keywords> keywords;
        }

        public class Debuff
        {
            private int power;
            private int hp;
            private List<Keywords> keywords;
        }

        public class Draw
        {
            private int amount;
        }

        public class Discard
        {
            private int amount;
        }
    }
}
