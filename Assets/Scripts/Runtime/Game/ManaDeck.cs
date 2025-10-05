using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class ManaDeck : Deck
    {
        //// Start is called once before the first execution of Update after the MonoBehaviour is created
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
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
