using System.Collections.Generic;
using UnityEngine;

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
                levelEffects[level].Activate(this.rank, new List<GameObject> {this.gameObject});
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
            List<Effect> newEffects, List<Keywords> newKeywords)
        {
            base.RankUp(newRank, newPower, newMaxHP, newEffects, newKeywords);
            keywords = newKeywords;
        }
    }
}
