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

        //// Update is called once per frame
        //void Update()
        //{

        //}
        //Could be removed because same as list.Count
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

        public Card Seek(CardType cardTyoe)
        {
            //TODO returns dummy
            return new Card();
        }

        public List<Card> Search(CardType cardType)
        {
            //TODO returns dummy
            return new List<Card>();
        }

        public List<Card> Seek(CardSubType subType)
        { 
                return new List<Card>(); 
        }

        public List<Card> Search(CardSubType subType)
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
