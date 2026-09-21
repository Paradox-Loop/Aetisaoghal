using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class prefabFactory // this class is purely static and doesn't have any members
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
            throw new NotImplementedException();
        }

        internal static void CreateLeader(EnumLibrary.CardTypes cardType, string name, List<int> power, List<int> hp, EnumLibrary.Factions faction, List<Effect> effects)
        {
            throw new NotImplementedException();
        }

        internal static Effect CreateRessourceEffect(Effect.Ressource ressource, List<int> list)
        {
            throw new NotImplementedException();
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
        }

        internal static void CreateSpell(EnumLibrary.CardTypes cardType, string name, int cost, EnumLibrary.Factions faction, EnumLibrary.CardSubtypes subtype, List<Effect> effects)
        {
            throw new NotImplementedException();
        }

        internal static void CreateUnit(EnumLibrary.CardTypes cardType, string name, int cost, EnumLibrary.Factions faction, EnumLibrary.CardSubtypes subtype, List<int> power, List<int> hp, List<Effect> effects)
        {
            throw new NotImplementedException();
        }
    }
}
