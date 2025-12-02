using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public interface ICombatEntity
    {
        public int power { get; set; }
        public int maxHP { get; set; }
        public int currentHP { get; set; }
        public bool isExhausted { get; set; }
        public List<Keywords> keywords { get; set; }

        void Attack(ICombatEntity target);

        void TakeDamage(int amount);
        void Die();
        void ChangeZone(Zone zone);
        void Heal(int amount);

    }
}
