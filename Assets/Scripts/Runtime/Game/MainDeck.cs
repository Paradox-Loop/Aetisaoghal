using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Template.Multiplayer.NGO.Runtime.EnumLibrary;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class MainDeck : Deck
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            counter = 0;
            base.validCardTypes = new List<CardTypes> { CardTypes.Spell, CardTypes.Unit };

            if (Deck.rng == null) { Deck.rng = new System.Random(); }
            Shuffle(); // shuffle all decks when they are created at game start
        }
        private void Update() // making sure start is ran
        {
            counter = 0;
            cardsInZone = new List<Card>(); //ensure the list is initialized
            validCardTypes = new List<CardTypes> { CardTypes.Spell, CardTypes.Unit };

            if (Deck.rng == null) { Deck.rng = new System.Random(); }
            Shuffle(); // shuffle all decks when they are created at game start
        }

        public void StartBypass()
        {
            counter = 0;
            cardsInZone = new List<Card>(); //ensure the list is initialized
            validCardTypes = new List<CardTypes> { CardTypes.Spell, CardTypes.Unit };

            if (Deck.rng == null) { Deck.rng = new System.Random(); }
            Shuffle(); // shuffle all decks when they are created at game start
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
            //Get all cards from deck that are of the specified time.
            List<Card> available = new List<Card>();
            foreach (Card card in cardsInZone)
            {
                if (card.GetType().Equals(cardType))
                {
                    available.Add(card);
                }
            }
            return available;
        }

        public Card Seek(EnumLibrary.CardSubtypes subType)
        {
            foreach (var card in cardsInZone)
            {
                if (card.subType.Equals(subType))
                {
                    return card;
                }
            }
            return null; //return null if no sutable cards where found. Must make sure to handle it.
        }

        public List<Card> Search(EnumLibrary.CardSubtypes subType)
        {
            List<Card> available = new List<Card>();
            foreach (Card card in cardsInZone)
            {
                if (card.subType == subType)
                {
                    available.Add(card);
                }
            }
            return available;
        }

        public List<Card> Mill(int amount)
        {
            List<Card> milledCards = new List<Card>();
            milledCards = cardsInZone.GetRange(0, amount);
            cardsInZone.RemoveRange(0, amount);

            return milledCards;
        }
        

        public void AddthirdFromTop(Card card)
        {
            cardsInZone[2] = card;
        }
    }
}
