using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ManaDeck : Deck
    {
        void Start()
        {
            validCardTypes = new List<EnumLibrary.CardTypes> { EnumLibrary.CardTypes.ManaStone };

            if (rng == null) { rng = new System.Random(); }
            Shuffle(); // shuffle all decks when they are created at game start
        }
        
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
