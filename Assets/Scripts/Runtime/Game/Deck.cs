using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public abstract class Deck : Zone
    {
        protected static System.Random rng;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (rng == null) { rng = new System.Random(); }
            Shuffle(); // shuffle all decks when they are created at game start
        }

        public abstract Card Draw();

        // Returns a shuffled version of the cards in the deck without modifying the actual orders of the cards
        public override List<Card> GetCardsInZone()
        {
            List<Card> shuffledCards = new List<Card>();
            int n = cardsInZone.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                shuffledCards[k] = cardsInZone[n];
                shuffledCards[n] = cardsInZone[k];
            }
            return shuffledCards;
        }

        protected void Shuffle()
        {
            int n = cardsInZone.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = cardsInZone[k];
                cardsInZone[k] = cardsInZone[n];
                cardsInZone[n] = card;
            }
        }
    }
}
