using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ExtraZone : Zone
    {
        void Start()
        {
            validCardTypes = new List<EnumLibrary.CardTypes> { EnumLibrary.CardTypes.Spell, EnumLibrary.CardTypes.Unit };
        }
        
        public override List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }
    }
}
