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
            
        }
    }
}
