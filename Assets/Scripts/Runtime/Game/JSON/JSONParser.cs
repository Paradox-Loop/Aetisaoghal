using Codice.Client.Common.GameUI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Template.Multiplayer.NGO.Runtime.SimpleJSON;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class JSONParser
    {
        [Serializable]
        private class JsonCard
        {
            public string type;
            public string name;
            public string faction;
            public string cardSubtype;
            public string cardType;
            public int cost;
            public string power;
            public string hp;
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
        private class  EffectWrapper
        {
            public List<JsonEffects> effects;
        }
        [Serializable]
        private class JsonEffects
        {
            public string effectType;
            public string data;
        }
        [Serializable]
        private class JsonRessourceEffects
        {
            public string amount;
            public string ressourceType;
        }
        private class JsonHealingEffect
        {
            public string amount;
        }
        private class JsonDamageEffect
        {
            public string amount;
        }
        private class JsonBuffEffect
        {
            public string power;
            public string hp;
            public string keywords;
        }
        private class JsonDebuffEffect
        {
            public string power;
            public string hp;
            public string keywords;
        }
        private class JsonDrawEffect
        {
            public string amount;
        }
        private class JsonDiscardEffect
        {
            public string amount;
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
        private struct Ressources
        {
            public string name;
            public EnumLibrary.Ressources ressource;
            public Ressources(string name, EnumLibrary.Ressources ressource)
            {
                this.name = name;
                this.ressource = ressource;
            }
        }
        private struct intArray
        {
            public List<int> values;
        }
        // Do not forget to updates this file if new enums are added.
        private List<Types> cardTypes = new List<Types>() {new Types( "Unit", EnumLibrary.CardTypes.Unit), new Types("Spell", EnumLibrary.CardTypes.Spell), 
            new Types("Leader", EnumLibrary.CardTypes.Leader), new Types("Mana Stone", EnumLibrary.CardTypes.ManaStone)};

        private List<SubTypes> subtypes = new List<SubTypes>() { new SubTypes("Monster", EnumLibrary.CardSubtypes.Monster), new SubTypes("Ritual", EnumLibrary.CardSubtypes.Ritual),
            new SubTypes("Scheme", EnumLibrary.CardSubtypes.Scheme), new SubTypes("Hero", EnumLibrary.CardSubtypes.Hero)};

        private List<Factions> factions = new List<Factions>() { new Factions("Neutral", EnumLibrary.Factions.Neutral), new Factions("Seekers", EnumLibrary.Factions.Seeker),
            new Factions("Underworld", EnumLibrary.Factions.Underworld), new Factions("Order", EnumLibrary.Factions.Order), new Factions("Wild", EnumLibrary.Factions.Wild)};
        private List<Ressources> ressourceTypes = new List<Ressources> { new Ressources("Mana", EnumLibrary.Ressources.Mana), new Ressources("Cards", EnumLibrary.Ressources.Card),
            new Ressources("Loot", EnumLibrary.Ressources.Loot), new Ressources("Arcane Knowledge", EnumLibrary.Ressources.ArcaneKnowledge), new Ressources("Food", EnumLibrary.Ressources.Food),
            new Ressources("Token", EnumLibrary.Ressources.Token)};

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
            return false;
        }
        private void ConvertCards(List<JsonCard> cards)
        {
            foreach (JsonCard jsonCard in cards)
            {
                //parse to Enums
                EnumLibrary.CardTypes cardType = GetCardType(jsonCard.cardType);
                EnumLibrary.CardSubtypes subtype;
                subtype = GetCardSubtype(jsonCard.cardSubtype);

                EnumLibrary.Factions faction = GetFaction(jsonCard.faction);

                List<int> power = new List<int>() {0};
                List<int> hp = new List<int>() { 0 };
                if(jsonCard.power != null && jsonCard.hp != null)
                {
                    power = readIntArray(jsonCard.power);
                    hp = readIntArray(jsonCard.hp);
                }

                int cost = jsonCard.cost;
                    
                string name = jsonCard.name;
                    
                List<Effect> effects = GetEffects(jsonCard.effects); //parse all the card effects

                // called correct factory method for card type
                if (cardType == EnumLibrary.CardTypes.ManaStone)
                {
                    scriptableFactory.CreateCardMana(cardType, name, effects);
                }
                else if (cardType == EnumLibrary.CardTypes.Leader)
                {
                    scriptableFactory.CreateLeader(cardType, name, power, hp, faction, effects);
                }
                else if (cardType == EnumLibrary.CardTypes.Unit)
                {
                    scriptableFactory.CreateUnit(cardType, name, cost, faction, subtype, power, hp, effects);
                }
                else if(cardType == EnumLibrary.CardTypes.Spell)
                {
                    scriptableFactory.CreateSpell(cardType, name, cost, faction, subtype, effects);
                }
            }
        }

        private List<Effect> GetEffects(string db)
        {
            List<JsonEffects> jsonEffects = JsonUtility.FromJson<List<JsonEffects>>(db);
            List<Effect> effects = new List<Effect>();
            foreach (JsonEffects jsonEffect in jsonEffects)
            {
                if (jsonEffect.effectType == "Ressource")
                {
                    JsonRessourceEffects jsonRessourceEffect = JsonUtility.FromJson<JsonRessourceEffects>(jsonEffect.data);
                    Effect.Ressource ressource = new Effect.Ressource();
                    EnumLibrary.Ressources ressourceType = getRessourceType(jsonRessourceEffect.ressourceType);

                    if (ressourceType == EnumLibrary.Ressources.Error)
                    {
                        throw new Exception("Invalid ressource type exception");
                    }
                    effects.Add(scriptableFactory.CreateRessourceEffect(ressourceType, readIntArray(jsonRessourceEffect.amount)));
                }
                else if (jsonEffect.effectType == "Healing")
                {
                    JsonHealingEffect jSonHealingEffect = JsonUtility.FromJson<JsonHealingEffect>(jsonEffect.data);
                    effects.Add(scriptableFactory.CreateSimpleEffect("heal", readIntArray(jSonHealingEffect.amount)));
                }
                else if (jsonEffect.effectType == "Damage")
                {
                    JsonDamageEffect jsonDamageEffect = JsonUtility.FromJson<JsonDamageEffect>(jsonEffect.data);
                    effects.Add(scriptableFactory.CreateSimpleEffect("damage", readIntArray(jsonDamageEffect.amount)));
                }
                else if(jsonEffect.effectType == "Buff")
                {
                    JsonBuffEffect jsonBuffEffect = JsonUtility.FromJson<JsonBuffEffect>(jsonEffect.data);
                    List<int> power = readIntArray(jsonBuffEffect.power);
                    List<int> hp = readIntArray(jsonBuffEffect.hp);
                    List<Keywords> keywords = GetKeywords(jsonBuffEffect.keywords);
                    effects.Add(scriptableFactory.CreateBuffEffect(power, hp, keywords, "buff"));
                }
                else if( jsonEffect.effectType == "Debuff")
                {
                    JsonDebuffEffect jsonDebuffEffect = JsonUtility.FromJson<JsonDebuffEffect>(jsonEffect.data);
                    List<int> power = readIntArray(jsonDebuffEffect.power);
                    List<int> hp = readIntArray(jsonDebuffEffect.hp);
                    List<Keywords> keywords = GetKeywords(jsonDebuffEffect.keywords);
                    effects.Add(scriptableFactory.CreateBuffEffect(power, hp, keywords, "debuff"));
                }
                else if(jsonEffect.effectType == "Draw")
                {
                    JsonDrawEffect jsonDrawEffect = JsonUtility.FromJson<JsonDrawEffect>(jsonEffect.data);
                    effects.Add(scriptableFactory.CreateSimpleEffect("draw", readIntArray(jsonDrawEffect.amount));
                }
                else if(jsonEffect.effectType == "Discard")
                {
                    JsonDiscardEffect jsonDiscardEffect = JsonUtility.FromJson<JsonDiscardEffect>(jsonEffect.data);
                    effects.Add(scriptableFactory.CreateSimpleEffect("discard", readIntArray(jsonDiscardEffect.amount)));
                }
            }
            return effects;
        }

        private List<int> readIntArray(string power)
        {
            List<int> array = new List<int>();
            intArray intArray = JsonUtility.FromJson<intArray>(power);
            foreach (int i in intArray.values)
            {
                array.Add(i);
            }
            return array;
        }

        private List<Keywords> GetKeywords(string keywords)
        {
            throw new NotImplementedException();
        }

        private EnumLibrary.Ressources getRessourceType(string ressourceType)
        {
            foreach(var type in ressourceTypes)
            {
                if (type.name == ressourceType)
                    return type.ressource;
            }
            return EnumLibrary.Ressources.Error;
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
