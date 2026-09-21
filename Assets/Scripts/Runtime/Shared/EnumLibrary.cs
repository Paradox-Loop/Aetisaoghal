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
            Neutral,
            None
        }

        public enum CardTypes
        {
            Unit,
            Spell,
            Leader,
            ManaStone,
            Error
        }

        public enum CardSubtypes
        {
           Ritual,
           Scheme,
           Monster,
           Hero,
           None
        }

        public enum Ranks
        {
            Recruit,
            Veteran,
            Elite,
            Error
        }

        public enum Ressources
        {
            Mana,
            Token,
            Card,
            Food,
            ArcaneKnowledge,
            Loot,
            Error
        }

        public enum Sources{
            Self,
            Tokens,
            Units,
            Spells,
            Ritual,
            Scheme,
            Monster,
            Hero
        }
    }
}
