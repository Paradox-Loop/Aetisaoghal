using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;
namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class DeckTests
    {
        [Test]
        public void ShuffleTest()
        {
            GameObject goDeck1 = new GameObject("goDeck1");
            GameObject goDeck2 = new GameObject("goDeck2");
            goDeck1.AddComponent<MainDeck>();
            goDeck2.AddComponent<MainDeck>();
            
            MainDeck deck1 = goDeck1.GetComponent<MainDeck>();
            MainDeck deck2 = goDeck2.GetComponent<MainDeck>();
            deck1.StartBypass();
            deck2.StartBypass();

            GameObject goCard1 = new GameObject("goCard1");
            GameObject goCard2 = new GameObject("goCard2");
            GameObject goCard3 = new GameObject("goCard3");
            GameObject goCard4 = new GameObject("goCard4");
            GameObject goCard5 = new GameObject("goCard5");
            goCard1.AddComponent<Card>();
            goCard2.AddComponent<Card>();
            goCard3.AddComponent<Card>();
            goCard4.AddComponent<Card>();
            goCard5.AddComponent<Card>();
            Card card1= goCard1.GetComponent<Card>();
            Card card2= goCard2.GetComponent<Card>();
            Card card3 = goCard3.GetComponent<Card>();
            Card card4 = goCard4.GetComponent<Card>();
            Card card5 = goCard5.GetComponent<Card>();

            card1.cardType = EnumLibrary.CardTypes.Unit;
            card2.cardType = EnumLibrary.CardTypes.Unit;
            card3.cardType = EnumLibrary.CardTypes.Spell;
            card4.cardType = EnumLibrary.CardTypes.Unit;
            card5.cardType = EnumLibrary.CardTypes.Spell;
            List<Card> cards = new() {card1, card2, card3, card4, card5};

            deck1.AddCardsToZone(cards);
            deck2.AddCardsToZone(cards);
            deck1.ShuffleTest();
            deck2.ShuffleTest();
            Debug.Assert(deck1 != deck2);

        }

        [Test]
        public void SearchFoundTest()
        {
            GameObject goCard1 = new GameObject("goCard1");
            GameObject goCard2 = new GameObject("goCard2");
            GameObject goCard3 = new GameObject("goCard3");
            GameObject goCard4 = new GameObject("goCard4");
            GameObject goCard5 = new GameObject("goCard5");

            // add components
            goCard1.AddComponent<Card>();
            goCard2.AddComponent<Card>();
            goCard3.AddComponent<Card>();
            goCard4.AddComponent<Card>();
            goCard5.AddComponent<Card>();

            //get components references
            Card card1 = goCard1.GetComponent<Card>();
            Card card2 = goCard2.GetComponent<Card>();
            Card card3 = goCard3.GetComponent<Card>();
            Card card4 = goCard4.GetComponent<Card>();
            Card card5 = goCard5.GetComponent<Card>();

            card1.cardType = EnumLibrary.CardTypes.Unit;
            card2.cardType = EnumLibrary.CardTypes.Unit;
            card3.cardType = EnumLibrary.CardTypes.Spell;
            card4.cardType = EnumLibrary.CardTypes.Unit;
            card5.cardType = EnumLibrary.CardTypes.Spell;
            card1.subType = EnumLibrary.CardSubtypes.Monster;
            card4.subType = EnumLibrary.CardSubtypes.Monster;
            List<Card> cards = new() { card1, card2, card3, card4, card5 };
            GameObject goDeck = new GameObject("goDeck");
            goDeck.AddComponent<MainDeck>();
            MainDeck deck = goDeck.GetComponent<MainDeck>(); //load a normal containing a mix of cards
            deck.StartBypass();
            deck.AddCardsToZone(cards);
            List<Card> output = deck.Search(EnumLibrary.CardSubtypes.Monster);
            List<Card> expected = new() { card1, card4}; //list containing only the monsters that should be found by the search

            CollectionAssert.AreEqual(expected, output);
        }

        [Test]
        public void SearchNoFindTest()
        {
            GameObject goCard1 = new GameObject("goCard1");
            GameObject goCard2 = new GameObject("goCard2");
            GameObject goCard3 = new GameObject("goCard3");
            GameObject goCard4 = new GameObject("goCard4");
            GameObject goCard5 = new GameObject("goCard5");

            // add components
            goCard1.AddComponent<Card>();
            goCard2.AddComponent<Card>();
            goCard3.AddComponent<Card>();
            goCard4.AddComponent<Card>();
            goCard5.AddComponent<Card>();

            //get components references
            Card card1 = goCard1.GetComponent<Card>();
            Card card2 = goCard2.GetComponent<Card>();
            Card card3 = goCard3.GetComponent<Card>();
            Card card4 = goCard4.GetComponent<Card>();
            Card card5 = goCard5.GetComponent<Card>();

            card1.cardType = EnumLibrary.CardTypes.Unit;
            card2.cardType = EnumLibrary.CardTypes.Unit;
            card3.cardType = EnumLibrary.CardTypes.Spell;
            card4.cardType = EnumLibrary.CardTypes.Unit;
            card5.cardType = EnumLibrary.CardTypes.Spell;
            card1.subType = EnumLibrary.CardSubtypes.Scheme;
            card3.subType = EnumLibrary.CardSubtypes.Ritual;
            card4.subType = EnumLibrary.CardSubtypes.Hero;
            List<Card> cards = new() { card1, card2, card3, card4, card5 };

            GameObject goDeck = new GameObject("goDeck");
            goDeck.AddComponent<MainDeck>();
            MainDeck deck = goDeck.GetComponent<MainDeck>();//load a normal containing a mix of cards
            deck.StartBypass();
            deck.AddCardsToZone(cards);
            List<Card> output = deck.Search(EnumLibrary.CardSubtypes.Monster);

            Assert.IsEmpty(output);
        }
        [Test]
        public void SeekTestEqual() // test seek by adding a card before any other card matching the search
        {
            GameObject goCard1 = new GameObject("goCard1");
            GameObject goCard2 = new GameObject("goCard2");
            GameObject goCard3 = new GameObject("goCard3");
            GameObject goCard4 = new GameObject("goCard4");
            GameObject goCard5 = new GameObject("goCard5");

            // add components
            goCard1.AddComponent<Card>();
            goCard2.AddComponent<Card>();
            goCard3.AddComponent<Card>();
            goCard4.AddComponent<Card>();
            goCard5.AddComponent<Card>();

            //get components references
            Card card1 = goCard1.GetComponent<Card>();
            Card card2 = goCard2.GetComponent<Card>();
            Card card3 = goCard3.GetComponent<Card>();
            Card card4 = goCard4.GetComponent<Card>();
            Card card5 = goCard5.GetComponent<Card>();

            card1.cardType = EnumLibrary.CardTypes.Unit;
            card2.cardType = EnumLibrary.CardTypes.Unit;
            card3.cardType = EnumLibrary.CardTypes.Spell;
            card4.cardType = EnumLibrary.CardTypes.Unit;
            card5.cardType = EnumLibrary.CardTypes.Spell;
            List<Card> cards = new() { card1, card2, card3, card4, card5 };
            GameObject goDeck = new GameObject("goDeck");
            goDeck.AddComponent<MainDeck>();
            MainDeck deck = goDeck.GetComponent<MainDeck>(); //create an unshuffled deck
            deck.StartBypass();
            deck.AddCardsToZone(cards);

            GameObject goCardToFind = new GameObject("goCardToFind");
            goCardToFind.AddComponent<Card>();
            Card cardToFind = goCardToFind.GetComponent<Card>(); //create card that will be seeked
            cardToFind.subType = EnumLibrary.CardSubtypes.Monster;
            deck.AddthirdFromTop(cardToFind);

            Card seek = deck.Seek(EnumLibrary.CardSubtypes.Monster);
            Assert.AreEqual(cardToFind, seek);
        }

        [Test]
        public void SeekTestNotEqual() // test seek by adding a card after the first card matching the search
        {
            GameObject goCard1 = new GameObject("goCard1");
            GameObject goCard2 = new GameObject("goCard2");
            GameObject goCard3 = new GameObject("goCard3");
            GameObject goCard4 = new GameObject("goCard4");
            GameObject goCard5 = new GameObject("goCard5");

            // add components
            goCard1.AddComponent<Card>();
            goCard2.AddComponent<Card>();
            goCard3.AddComponent<Card>();
            goCard4.AddComponent<Card>();
            goCard5.AddComponent<Card>();

            //get components references
            Card card1 = goCard1.GetComponent<Card>();
            Card card2 = goCard2.GetComponent<Card>();
            Card card3 = goCard3.GetComponent<Card>();
            Card card4 = goCard4.GetComponent<Card>();
            Card card5 = goCard5.GetComponent<Card>();

            card1.cardType = EnumLibrary.CardTypes.Unit;
            card2.cardType = EnumLibrary.CardTypes.Unit;
            card3.cardType = EnumLibrary.CardTypes.Spell;
            card4.cardType = EnumLibrary.CardTypes.Unit;
            card5.cardType = EnumLibrary.CardTypes.Spell;
            card1.subType = EnumLibrary.CardSubtypes.Monster;
            List<Card> cards = new List<Card> { card1, card2, card3, card4, card5 };

            GameObject goDeck = new GameObject("goDeck");
            goDeck.AddComponent<MainDeck>();
            MainDeck deck = goDeck.GetComponent<MainDeck>();
            deck.StartBypass();
            deck.AddCardsToZone(cards);
            GameObject goCardNotToFind = new GameObject("goCardNotToFind");
            goCardNotToFind.AddComponent<Card>();
            Card cardNotToFind = goCardNotToFind.GetComponent<Card>();
            cardNotToFind.subType = EnumLibrary.CardSubtypes.Monster;

            deck.AddthirdFromTop(cardNotToFind);
            Card seek = deck.Seek(EnumLibrary.CardSubtypes.Monster);
            Assert.AreNotEqual(cardNotToFind, seek);
        }

        [Test]
        public void AddIllegalCard()
        {
            GameObject goCard1 = new GameObject("goCard1");
            GameObject goCard2 = new GameObject("goCard2");
            GameObject goCard3 = new GameObject("goCard3");
            GameObject goCard4 = new GameObject("goCard4");
            GameObject goCard5 = new GameObject("goCard5");

            // add components
            goCard1.AddComponent<Card>();
            goCard2.AddComponent<Card>();
            goCard3.AddComponent<Card>();
            goCard4.AddComponent<Card>();
            goCard5.AddComponent<Card>();

            //get components references
            Card card1 = goCard1.GetComponent<Card>();
            Card card2 = goCard2.GetComponent<Card>();
            Card card3 = goCard3.GetComponent<Card>();
            Card card4 = goCard4.GetComponent<Card>();
            Card card5 = goCard5.GetComponent<Card>();

            // Create the list of expected value
            card1.cardType = EnumLibrary.CardTypes.Unit;
            card2.cardType = EnumLibrary.CardTypes.Unit;
            card3.cardType = EnumLibrary.CardTypes.Spell;
            card4.cardType = EnumLibrary.CardTypes.Unit;
            card5.cardType = EnumLibrary.CardTypes.Spell;
            card1.subType = EnumLibrary.CardSubtypes.Monster;
            List<Card> cards = new() { card1, card2, card3, card4, card5 };
            List<Card> expected = new() { card1, card2, card3, card4, card5 };

            // Let's try to add the incorrect card
            GameObject goLeader = new GameObject("goLeader");
            goLeader.AddComponent<Card>();
            Card leader = goLeader.GetComponent<Card>();
            leader.cardType = EnumLibrary.CardTypes.Leader;

            GameObject goDeck = new GameObject("goDeck");
            goDeck.AddComponent<MainDeck>();
            MainDeck deck = goDeck.GetComponent<MainDeck>();
            deck.StartBypass();
            deck.AddCardsToZone(cards);
            deck.AddCardsToZone(new List<Card> { leader });
            Assert.IsTrue(deck.GetCardsInZone().All(expected.Contains));// incorrect card should not have been added to the deck.
        }
    }
}