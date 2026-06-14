using Codice.Client.Common.GameUI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class JSONParser
    {
        [Serializable]
        private class JsonCard
        {

            public string name;
            public string faction;
            public string cardSubtype;
            public string cardType;
            public int cost;
            public string cardName;
            public string effects; //effects of the card, using this to read and parse the effect from the json file.
        }
        [Serializable]
        private class databaseWrapper
        {
            public List<JsonCard> items;
        }
        [Serializable]
        private class IDs
        {
            public string id;
        }
        [Serializable]
        private class decklist
        {
            public List<IDs> ids;
        }
        [Serializable]
        private class JsonEffects
        {

        }
        private struct Types
        {
            public string name;
            public EnumLibrary.CardTypes code;
            public Types(string name, EnumLibrary.CardTypes code)
            {
                this.name = name;
                this.code = code;
            }
        }
        private struct SubTypes
        {
            public string name;
            public EnumLibrary.CardSubtypes code;

            public SubTypes(string name, EnumLibrary.CardSubtypes code)
            {
                this.name = name;
                this.code = code;
            }
        }
        private struct Factions
        {
            public string name;
            public EnumLibrary.Factions faction;
            public Factions(string name, EnumLibrary.Factions faction)
            {
                this.name = name;
                this.faction = faction;
            }
        }
        // Do not forget to updates this file if new enums are added.
        private List<Types> cardTypes = new List<Types>() {new Types( "Unit", EnumLibrary.CardTypes.Unit), new Types("Spell", EnumLibrary.CardTypes.Spell), 
            new Types("Leader", EnumLibrary.CardTypes.Leader), new Types("Mana Stone", EnumLibrary.CardTypes.ManaStone)};

        private List<SubTypes> subtypes = new List<SubTypes>() { new SubTypes("Monster", EnumLibrary.CardSubtypes.Monster), new SubTypes("Ritual", EnumLibrary.CardSubtypes.Ritual),
            new SubTypes("Scheme", EnumLibrary.CardSubtypes.Scheme), new SubTypes("Hero", EnumLibrary.CardSubtypes.Hero)};

        private List<Factions> factions = new List<Factions>() { new Factions("Neutral", EnumLibrary.Factions.Neutral), new Factions("Seekers", EnumLibrary.Factions.Seeker),
            new Factions("Underworld", EnumLibrary.Factions.Underworld), new Factions("Order", EnumLibrary.Factions.Order), new Factions("Wild", EnumLibrary.Factions.Wild)};


        public bool Read(string database, string list)
        {
            if (File.Exists(database)) {
                var json1 = File.ReadAllText(database);
                var wrapper = JsonUtility.FromJson<databaseWrapper>(json1);

                //turn json to cards
                List<JsonCard> cards = new List<JsonCard>();
                cards = GetCards(wrapper);
                var json2 = File.ReadAllText(list);
                decklist names = JsonUtility.FromJson<decklist>(json2);
                List<string> validIds = getNamesFromDecklist(names);
                //remove all ids from database that are not in decklist
                JsonCard jsonCard = null;
                for (int i = cards.Count - 1; i >= 0; i--)
                {
                    {
                        jsonCard = cards[i];
                        if (!validIds.Contains(jsonCard.name))
                        {
                            cards.RemoveAt(i);
                        }
                    }
                }
                ConvertCards(cards);
                return true;
            }
        }
            private void ConvertCards(List<JsonCard> cards)
            {
                foreach (JsonCard jsonCard in cards)
                {
                    //parse strings to Enums
                    EnumLibrary.CardTypes cardType = GetCardType(jsonCard.cardType);
                    EnumLibrary.CardSubtypes subtype;
                    subtype = GetCardSubtype(jsonCard.cardSubtype);

                    EnumLibrary.Factions faction = GetFaction(jsonCard.faction);

                    GameObject goCard = new GameObject("");
                    goCard.AddComponent<Card>();
                    Card card = goCard.GetComponent<Card>();
                    card.Init(card.name, faction, cardType, subtype, card.cost, card.effects);
                }
            }

        private List<string> getNamesFromDecklist(decklist list)
        {
            List<string> names = new List<string>();
            foreach (var id in list.ids) {
                names.Add(id.id);
            }
            return names;
        }

        private List<JsonCard> GetCards(databaseWrapper wrapper)
        {
            var list = new List<JsonCard>();
            foreach (var item in wrapper.items)
            {
                var card = new JsonCard();
                card.cardName = item.name;
                card.faction = item.faction;
                card.cardType = item.cardType;
                card.cardSubtype = item.cardSubtype;
                card.cost = item.cost;
                card.effects = item.effects;
                list.Add(card);
            }
            return list;
        }

        private EnumLibrary.Factions GetFaction(string faction)
        {
            foreach(Factions f in factions)
            {
                if(f.name == faction)
                {
                    return f.faction;
                }
            }
            return EnumLibrary.Factions.Neutral;
        }

        private EnumLibrary.CardSubtypes GetCardSubtype(string cardSubtype)
        {
            foreach (SubTypes subType in subtypes)
            {
                if (subType.name == cardSubtype)
                {
                    return subType.code;
                }
            }
            return EnumLibrary.CardSubtypes.None;
        }

        private EnumLibrary.CardTypes GetCardType(string cardType)
        {
            foreach (Types type in cardTypes)
            {
                if(cardType == type.name)
                {
                    return type.code;
                }
            }
            return EnumLibrary.CardTypes.ManaStone;
        }


    }
}
