using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class EnumLibrary
    {
        public enum Factions
        {
            Seeker,
            Underworld,
            Order,
            Wild,
            Neutral
        }

        public enum CardTypes
        {
            Unit,
            Spell,
            Leader,
            ManaStone
        }

        public enum CardSubtypes
        {
           Ritual,
           Scheme,
           Monster,
           Hero
        }

        public enum Ranks
        {
            Recruit,
            Veteran,
            Elite
        }

        public enum Ressources
        {
            Mana,
            Token,
            Card,
            Food,
            ArcaneKnowledge,
            Loot
        }
    }
}
