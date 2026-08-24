using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Unit : Card, ICombatEntity
    {
        public bool isToken;
        public int activeCost;
        public EnumLibrary.Ressources activeRessource;

        public int power { get; set; }
        public int maxHP { get; set; }
        public int currentHP { get; set; }
        public bool isExhausted { get; set; }
        public List<Keywords> keywords { get; set; }

        public void Init(EnumLibrary.Factions faction, EnumLibrary.CardTypes cardType,
            EnumLibrary.CardSubtypes subType, int cost, string cardName, EnumLibrary.Ranks rank,
            List<Effect> effects, List<Trigger> triggers, Image image, Text text, bool isToken,
            int activeCost, EnumLibrary.Ressources activeRessource, int power, int maxHP, 
            int currentHP, bool isExhausted, List<Keywords> keywords)
        {
            base.Init(faction, cardType, subType, cost, cardName, rank, effects, triggers, image, text);
            this.isToken = isToken;
            this.activeCost = activeCost;
            this.activeRessource = activeRessource;
            this.power = power;
            this.maxHP = maxHP;
            this.currentHP = currentHP;
            this.isExhausted = isExhausted;
            this.keywords = keywords;
        }

        public void ActivateAbility(int cost, EnumLibrary.Ressources ressource, bool exhaust)
        {

        }

        public void Attack(ICombatEntity target)
        {
            target.TakeDamage(power);
            TakeDamage(target.power);
        }

        public void ChangeZone(Zone zone)
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            //TODO Sent to gravayard
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void Heal(int amount)
        {
            currentHP += amount;
            if (currentHP >= maxHP) 
            { 
                currentHP = maxHP;
            }
        }

        public void TakeDamage(int amount)
        {
            currentHP -= amount;
            if(currentHP <= 0)
            {
                Die();
            }
        }

        public override void RankUp(EnumLibrary.Ranks newRank, int newPower, int newMaxHP, 
            List<Effect> newEffects, List<Trigger> newTriggers, List<Keywords> newKeywords)
        {
            base.RankUp(newRank, newPower, newMaxHP, newEffects, newTriggers, newKeywords);
            keywords = newKeywords;
        }
    }
}
