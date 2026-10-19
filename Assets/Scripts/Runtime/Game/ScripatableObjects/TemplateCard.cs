using NUnit.Framework;
using PlasticGui.WorkspaceWindow;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class TemplateCard : ScriptableObject
    {
        private System.Collections.Generic.List<int> power;
        private System.Collections.Generic.List<int> hp;
        private string cardName { get; }
        private int cost { get; }
        private EnumLibrary.CardTypes cardType { get; }
        private EnumLibrary.CardSubtypes cardSubtype { get; }
        private EnumLibrary.Factions faction { get; }
        private List<Trigger> triggers { get; }

        private List<Effect> effects { get; }

        private Image art {  get; }
        private Text text { get; }

        public TemplateCard(string name, EnumLibrary.CardTypes cardType, List<Effect> effects, Text text, Image art)
        {
            this.cardName = name;
            this.effects = effects;
            this.cardType = cardType;
        }

        public TemplateCard(string name, int cost, EnumLibrary.CardSubtypes subtype, EnumLibrary.CardTypes cardType, EnumLibrary.Factions faction, List<Trigger> triggers,
            List<Effect> effects, Text text, Image art)
        {
            this.cardName = name;
            this.cost = cost;
            this.cardType = cardType;
            this.cardSubtype = subtype;
            this.faction = faction;
            this.triggers = triggers;
            this.effects = effects;
        }

        public TemplateCard(string name, int cost, EnumLibrary.CardSubtypes subtype, EnumLibrary.CardTypes cardType, EnumLibrary.Factions faction, List<int> power,
            List<int> hp, List<Trigger> triggers, List<Effect> effects, Text text, Image art)
        {
            if (hp.Count > 3)
            {
                List<int> temp = new List<int>();
                temp.Add(hp[0]);
                temp.Add(hp[1]);
                temp.Add(hp[2]);

                hp = temp;
            }
            if (power.Count > 3)
            {
                List<int> temp = new List<int>();
                temp.Add(power[0]);
                temp.Add(power[1]);
                temp.Add(power[2]);
                power = temp;
            }
            this.cardName = name;
            this.cost = cost;
            this.cardType = cardType;
            this.cardSubtype = subtype;
            this.faction = faction;
            this.power = power;
            this.hp = hp;
            this.triggers = triggers;
            this.effects = effects;

        }

        public int GetPower(EnumLibrary.Ranks rank)
        {
            return power[(int) rank];
        }
        public int GetHP(EnumLibrary.Ranks rank)
        {
            return hp[(int) rank];
        }


    }
}
