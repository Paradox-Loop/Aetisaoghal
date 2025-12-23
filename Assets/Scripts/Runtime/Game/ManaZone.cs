using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ManaZone : Zone
    {

        public override List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }
    }
}
