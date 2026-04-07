using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Effect : NetworkBehaviour
    {
        public virtual void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets) { }

        public class Ressource : Effect
        {
            private int amount;
            private EnumLibrary.Ressources type;
            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                RessourceEffect(rank, targets);
            }

            void RessourceEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    if (target.GetComponent<Player>())
                    {
                        target.GetComponent<Player>().possessedResources[type] += amount;
                    }
                }
            }
        }

        public class Healing : Effect
        {
            private int amount;

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                HealingEffect(rank, targets);
            }

            void HealingEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    target.GetComponent<ICombatEntity>().Heal(amount);
                }
            }
        }

        public class Damage : Effect
        {
            private int amount;

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DamageEffect(rank, targets);
            }

            void DamageEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    target.GetComponent<ICombatEntity>().TakeDamage(amount);
                }
            }
        }

        public class Buff : Effect
        {
            private int power;
            private int hp;
            private List<Keywords> keywords;

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                BuffEffect(rank, targets);
            }

            void BuffEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach(GameObject target in targets)
                {
                    target.GetComponent<ICombatEntity>().power += power;
                    target.GetComponent<ICombatEntity>().maxHP += hp;
                    target.GetComponent<ICombatEntity>().currentHP += hp;
                    target.GetComponent<ICombatEntity>().keywords.AddRange(keywords);
                }
            }
        }

        public class Debuff : Effect
        {
            private int power;
            private int hp;
            private List<Keywords> keywords;

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DebuffEffect(rank, targets);
            }

            void DebuffEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    target.GetComponent<ICombatEntity>().power -= power;
                    target.GetComponent<ICombatEntity>().maxHP -= hp;
                    target.GetComponent<ICombatEntity>().currentHP -= hp;
                    target.GetComponent<ICombatEntity>().keywords.ForEach(delegate (Keywords k)
                    {
                        if (keywords.Contains(k))
                        {
                            target.GetComponent<ICombatEntity>().keywords.Remove(k);
                        }
                        
                    });
                }
            }
        }

        public class Draw : Effect
        {
            private int amount;

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DrawEffect(rank, targets);
            }

            void DrawEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach(GameObject target in targets)
                {
                    target.GetComponent<Deck>().Draw();
                }
            }
        }

        public class Discard : Effect
        {
            private int amount;

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DiscardEffect(rank, targets);
            }

            void DiscardEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    if (target.GetComponent<Hand>().GetCardsInZone().Count == 0) continue;
                    for(int i = 0; i < amount; i++)
                    {
                        var cardToDiscard = Random.Range(0, target.GetComponent<Hand>().GetCardsInZone().Count);
                        target.GetComponent<Hand>().Discard(target.GetComponent<Hand>().GetCardsInZone()[cardToDiscard]);
                    }
                }
            }
        }
    }
}
