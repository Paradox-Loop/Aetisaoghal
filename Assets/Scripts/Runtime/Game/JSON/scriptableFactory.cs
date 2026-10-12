using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class scriptableFactory // this class is purely static and doesn't have any members
    {

        internal static Effect CreateBuffEffect(List<int> power, List<int> hp, List<Keywords> keywords, string type)
        {
            Effect effect;
            if (type == "buff")
            {
                effect = new Effect.Buff();
            }
            else
            {
                effect = new Effect.Debuff();
            }
            throw new NotImplementedException();
        }

        internal static void CreateCardMana(EnumLibrary.CardTypes cardType, string name, List<Effect> effects)
        {
            TemplateCard card = new TemplateCard(name, EnumLibrary.CardTypes.ManaStone, effects, null, null);
            //probably need to add this to some struct
        }

        internal static void CreateLeader(EnumLibrary.CardTypes cardType, string name, List<int> power, List<int> hp, EnumLibrary.Factions faction, List<Effect> effects)
        {
            TemplateCard leader = new TemplateCard(name, /*cost is 0 for leaders*/ 0, EnumLibrary.CardSubtypes.None, EnumLibrary.CardTypes.Leader, faction, power, hp,
                /*triggers*/ null, effects, null, null);
            
        }

        internal static Effect CreateRessourceEffect(EnumLibrary.Ressources ressource, List<int> list)
        {
            Effect.Ressource effect = new Effect.Ressource();
            effect.Init(list, ressource);
            var temp = ScriptableObject.Instantiate(effect);
            return temp;

        }

        internal static Effect CreateSimpleEffect(string type, List<int> list) // factory fonction for effects that have only one parameter.
        {
            Effect effect;
            if(type == "draw")
            {
                effect = new Effect.Draw();
            }
            else if(type == "discard")
            {
                effect = new Effect.Discard();
            }
            else if(type == "heal")
            {
                effect = new Effect.Healing();
            }
            else if(type == "damage")
            {
                effect = new Effect.Damage();
            }
            else
            {
                throw new Exception("Inexisting effect exception");
            }
            effect.Init(list);
            var temp = ScriptableObject.Instantiate(effect);
            return temp;
        }

        internal static void CreateSpell(EnumLibrary.CardTypes cardType, string name, int cost, EnumLibrary.Factions faction, EnumLibrary.CardSubtypes subtype, List<Effect> effects)
        {
            TemplateCard spell = new TemplateCard(name, cost, subtype, EnumLibrary.CardTypes.Spell, faction, /*trigger*/ null, effects, null, null);
        }

        internal static void CreateUnit(EnumLibrary.CardTypes cardType, string name, int cost, EnumLibrary.Factions faction, EnumLibrary.CardSubtypes subtype, List<int> power, List<int> hp, List<Effect> effects)
        {
            TemplateCard unit = new TemplateCard(name, cost, subtype, EnumLibrary.CardTypes.Unit, faction, power, hp, null, effects, null, null);
        }
    }
}
