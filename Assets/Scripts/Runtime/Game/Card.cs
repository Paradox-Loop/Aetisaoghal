using System.Collections.Generic;
using Unity.Netcode;
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
        public string name;
        public EnumLibrary.Ranks rank;
        public List<Effect> effects;
        public Zone currentZone;

        private Image image;
        private Text text;
        
        public void Play()
        {
        
        }

        void DoEffect(Effect effect)
        {
            //TO-DO : replace with actual targeting target itself for now
            effect.ActivateTrigger(rank, new List<GameObject> {gameObject});
        }

        public virtual void RankUp() { }

        public virtual void RankUp(EnumLibrary.Ranks newRank, List<Effect> newEffects)
        {
            rank = newRank;
            effects = newEffects;
        }

        public virtual void RankUp(EnumLibrary.Ranks newRank, int newPower, int newMaxHP, 
            List<Effect> newEffects, List<Keywords> newKeywords)
        {
            rank = newRank;
            effects = newEffects;
        }
    }
}
