using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class MainDeck : Deck
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            counter = 0;
        }

        //Could be removed because same as list.Count -> Used for damage when library empty
        private int counter;

        public int Counter { get { return counter; }
            set { counter = value; } }

        public override Card Draw()
        {
            //TODO returns dummy
            if (cardsInZone.Count > 0)
            {
                Card top = cardsInZone[0];
                cardsInZone.Remove(top);
                return top;
            }
            counter++;
            return null;
        }

        public List<Card> Peek(int amount)
        {
            List<Card> peekedCards = new List<Card>();
            peekedCards = cardsInZone.GetRange(0, amount);
            return peekedCards;
        }

        public Card Seek(EnumLibrary.CardTypes cardType)
        {
            //TODO returns dummy
            return new Card();
        }

        public List<Card> Search(EnumLibrary.CardTypes cardType)
        {
            //TODO returns dummy
            return new List<Card>();
        }

        public List<Card> Seek(EnumLibrary.CardSubtypes subType)
        { 
                return new List<Card>(); 
        }

        public List<Card> Search(EnumLibrary.CardSubtypes subType)
        { 
            return new List<Card>(); 
        }

        public List<Card> Mill(int amount)
        {
            List<Card> milledCards = new List<Card>();
            milledCards = cardsInZone.GetRange(0, amount);
            cardsInZone.RemoveRange(0, amount);

            return milledCards;
        }

    }
}
