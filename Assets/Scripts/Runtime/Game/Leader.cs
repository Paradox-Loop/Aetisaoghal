using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Leader : Card, ICombatEntity
    {
        public int level;
        public int commandCost;
        public EnumLibrary.Ressources commandRessource;
        public string proficiency; //To-Do change when proficiency are added
        public List<int> levelCost;
        public EnumLibrary.Ressources levelRessource;
        public List<Effect> levelEffects;
        private bool hasLeveled;

        public int power { get; set; }
        public int maxHP { get; set; }
        public int currentHP { get; set; }
        public bool isExhausted { get; set; }
        public List<Keywords> keywords { get; set; }

        public void Init(EnumLibrary.Factions faction, EnumLibrary.CardTypes cardType,
            EnumLibrary.CardSubtypes subType, int cost, string cardName, EnumLibrary.Ranks rank,
            List<Effect> effects, List<Trigger> triggers, Image image, Text text, int level,
            int commandCost, EnumLibrary.Ressources commandRessource, string proficiency, 
            List<int> levelCost, EnumLibrary.Ressources levelRessource, List<Effect> levelEffects,
            bool hasLeveled, int power, int maxHP, int currentHP, bool isExhausted, List<Keywords> keywords)
        {
            base.Init(faction, cardType, subType, cost, cardName, rank, effects, triggers, 
                image, text);
            this.level = level;
            this.commandCost = commandCost;
            this.commandRessource = commandRessource;
            this.proficiency = proficiency;
            this.levelCost = levelCost;
            this.levelRessource = levelRessource;
            this.levelEffects = levelEffects;
            this.hasLeveled = hasLeveled;
            this.power = power;
            this.maxHP = maxHP;
            this.currentHP = currentHP;
            this.isExhausted = isExhausted;
            this.keywords = keywords;
        }

        public void ActivateCommand(int cost, EnumLibrary.Ressources ressource, bool exhaust)
        {

        }

        public bool canLevelUp()
        {
            return !hasLeveled;
        }

        public void LevelUp()
        {
            if (canLevelUp())
            {
                levelEffects[level].ActivateEffect(this.rank, new List<GameObject> {this.gameObject});
                //To-Do Remove ressource to player equal to level cost
                level += 1;
            }
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

        public void Die()
        {
            //TODO Sent to gravayard
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
            if (currentHP <= 0)
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
