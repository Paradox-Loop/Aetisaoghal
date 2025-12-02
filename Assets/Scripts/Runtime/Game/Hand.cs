using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Hand : Zone
    {
        public void AddCardToHand(Card card)
        {
            // TODO
        }

        public void Discard(Card card)
        {
            // TODO
        }

        public override List<Card> GetCardsInZone()
        {
            return new List<Card>();
            //check if player calling is owner before showing hand
            if(true)
            {
                return cardsInZone;
            }
            // if player doesn't own hand (or is not spectator return null and handle warning)
            return null;
        }
    }
}
