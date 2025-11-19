using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Effect : NetworkBehaviour
    {
        public virtual void AddEffect() { }
        public virtual void RemoveEffect() { }
        public virtual void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets) { }

        public class Ressource : Effect
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> RessourceEffectEvent;
            private int amount;
            private EnumLibrary.Ressources type;

            public override void AddEffect()
            {
                RessourceEffectEvent.AddListener(RessourceTrigger);
            }

            public override void RemoveEffect()
            {
                RessourceEffectEvent.RemoveListener(RessourceTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                RessourceEffectEvent.Invoke(rank, targets);
            }

            void RessourceTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                
            }
        }

        public class Healing : Effect
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> HealingEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                HealingEffectEvent.AddListener(HealingTrigger);
            }

            public override void RemoveEffect()
            {
                HealingEffectEvent.RemoveListener(HealingTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                HealingEffectEvent.Invoke(rank, targets);
            }

            void HealingTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    target.GetComponent<ICombatEntity>().Heal(amount);
                }
            }
        }

        public class Damage : Effect
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> DamageEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                DamageEffectEvent.AddListener(DamageTrigger);
            }

            public override void RemoveEffect()
            {
                DamageEffectEvent.RemoveListener(DamageTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DamageEffectEvent.Invoke(rank, targets);
            }

            void DamageTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    target.GetComponent<ICombatEntity>().TakeDamage(amount);
                }
            }
        }

        public class Buff : Effect
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> BuffEffectEvent;
            private int power;
            private int hp;
            private List<Keywords> keywords;

            public override void AddEffect()
            {
                BuffEffectEvent.AddListener(BuffTrigger);
            }

            public override void RemoveEffect()
            {
                BuffEffectEvent.RemoveListener(BuffTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                BuffEffectEvent.Invoke(rank, targets);
            }

            void BuffTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
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
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> DebuffEffectEvent;
            private int power;
            private int hp;
            private List<Keywords> keywords;

            public override void AddEffect()
            {
                DebuffEffectEvent.AddListener(DebuffTrigger);
            }

            public override void RemoveEffect()
            {
                DebuffEffectEvent.RemoveListener(DebuffTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DebuffEffectEvent.Invoke(rank, targets);
            }

            void DebuffTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
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
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> DrawEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                DrawEffectEvent.AddListener(DrawTrigger);
            }

            public override void RemoveEffect()
            {
                DrawEffectEvent.RemoveListener(DrawTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DrawEffectEvent.Invoke(rank, targets);
            }

            void DrawTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach(GameObject target in targets)
                {
                    target.GetComponent<Deck>().Draw();
                }
            }
        }

        public class Discard : Effect
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> DiscardEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                DiscardEffectEvent.AddListener(DiscardTrigger);
            }

            public override void RemoveEffect()
            {
                DiscardEffectEvent.RemoveListener(DiscardTrigger);
            }

            public override void ActivateTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DiscardEffectEvent.Invoke(rank, targets);
            }

            void DiscardTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
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
