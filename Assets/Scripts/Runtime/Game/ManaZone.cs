using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ManaZone : Zone
    {
        void Start()
        {
            validCardTypes = new List<EnumLibrary.CardTypes> { EnumLibrary.CardTypes.ManaStone };
        }
        

        public override List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }
    }
}
