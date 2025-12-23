using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ManaGrave : Graveyard
    {
        public override List<Card> GetCardsInZone()
        {
            return cardsInZone;
        }
    }
}
