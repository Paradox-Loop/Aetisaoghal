using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

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
    }
}
