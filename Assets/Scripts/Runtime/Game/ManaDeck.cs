using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ManaDeck : Deck
    {
        public override Card Draw()
        {
            if(cardsInZone.Count == 0)
            {
                //get owner of this zone
                ManaGrave manaGrave = new ManaGrave(); // change to correct grave once we can get the owner
                List<Card> cardsToShuffle = manaGrave.GetCardsInZone();
                cardsInZone = cardsToShuffle;
                base.Shuffle();
            }
            Card card = cardsInZone[0];
            cardsInZone.RemoveAt(0);
            return card;
        }

    }
}
