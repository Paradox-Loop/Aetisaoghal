using System.Collections.Generic;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    internal class Leader : Card, ICombatEntity
    {
        int ICombatEntity.power { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        int ICombatEntity.maxHP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        int ICombatEntity.currentHP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        bool ICombatEntity.isExhausted { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        List<Keywords> ICombatEntity.keywords { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        void ICombatEntity.Attack(ICombatEntity target)
        {
            throw new System.NotImplementedException();
        }

        void ICombatEntity.ChangeZone(Zone zone)
        {
            throw new System.NotImplementedException();
        }

        void ICombatEntity.Die()
        {
            throw new System.NotImplementedException();
        }

        void ICombatEntity.Heal(int amount)
        {
            throw new System.NotImplementedException();
        }

        void ICombatEntity.TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}