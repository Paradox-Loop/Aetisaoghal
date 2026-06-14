using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
   
    public class Card : NetworkBehaviour
    {
        public EnumLibrary.Factions faction;
        public EnumLibrary.CardTypes cardType;
        public EnumLibrary.CardSubtypes subType;
        public int cost;
        public string cardName;
        public EnumLibrary.Ranks rank;
        public List<Effect> effects;
        public List<Trigger> triggers;

        private Image image;
        private Text text;

        //set the parameters of the card read from a JSON file.
        public void Init(string name, EnumLibrary.Factions faction, EnumLibrary.CardTypes cardTypes, EnumLibrary.CardSubtypes subtype, int cost, List<Effect> effects)
        {
            this.name = name;
            this.faction = faction;
            this.cardType = cardTypes;
            this.subType = subtype;
            this.cost = cost;
            this.effects = effects;

        }
        
        public void Play()
        {
        
        }

        void DoEffect(Effect effect)
        {
            //TO-DO : replace with actual targeting target itself for now
            effect.ActivateEffect(rank, new List<GameObject> { gameObject });
        }

        public void DoTrigger(Trigger trigger, List<GameObject> targets)
        {
            trigger.DoTrigger(rank, targets);
        }

        public virtual void RankUp() { }

        public virtual void RankUp(EnumLibrary.Ranks newRank, List<Effect> newEffects, 
            List<Trigger> newTriggers)
        {
            rank = newRank;
            effects = newEffects;
            triggers = newTriggers;
        }

        public virtual void RankUp(EnumLibrary.Ranks newRank, int newPower, int newMaxHP, 
            List<Effect> newEffects, List<Trigger> newTriggers, List<Keywords> newKeywords)
        {
            rank = newRank;
            effects = newEffects;
            triggers = newTriggers;
        }
    }
}
