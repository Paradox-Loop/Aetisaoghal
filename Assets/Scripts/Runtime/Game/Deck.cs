using Codice.Client.Common.GameUI;
using Codice.CM.Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public abstract class Deck : Zone
    {
        protected static System.Random rng;

        public abstract Card Draw();

        // Returns a shuffled version of the cards in the deck without modifying the actual orders of the cards
        public override List<Card> GetCardsInZone()
        {
            
            int n = cardsInZone.Count;
            List<Card> shuffledCards = cardsInZone;
            for (int i = 0; i < n; i++)
            {
                int k = rng.Next(n - 1);
                Card card = shuffledCards[k];
                shuffledCards[k] = shuffledCards[i];
                shuffledCards[i] = shuffledCards[k];
            }
            return shuffledCards;
        }

        protected void Shuffle()
        {
            if(cardsInZone.Count == 0)
            { return; } // do not shuffle if deck is empty
            int n = cardsInZone.Count;
            for (int i = 0; i < n; i++)
            {
                Card card = cardsInZone[i];
                int k = rng.Next(n - 1); //pick a random card in the range 0, deck.count
                cardsInZone[i] = cardsInZone[k]; // swap k and i
                cardsInZone[k] = card;
            }        
        }

        public static bool operator ==(Deck a, Deck b)
        {
            if(object.ReferenceEquals(a, b)) return true;
            return a.cardsInZone == b.cardsInZone;
        }
        public static bool operator !=(Deck a, Deck b)
        {
            if(object.ReferenceEquals (a, b)) return false;
            return a.cardsInZone != b.cardsInZone;
        }

        [Test]
        public void ShuffleTest()
        {
            this.Shuffle();
        }
    }
}