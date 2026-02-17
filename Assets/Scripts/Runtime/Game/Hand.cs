using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Hand : Zone
    {
        public override void AddCardsToZone(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                //check if any cards are cards unable to enter this zone 
                if (card.cardType != EnumLibrary.CardTypes.Unit || card.cardType != EnumLibrary.CardTypes.Spell)
                {
                    cards.Remove(card); //remove cards if their types cannot enter this zone
                }
            }
            cardsInZone.AddRange(cards);
        }
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
