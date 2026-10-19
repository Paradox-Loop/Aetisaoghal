using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Effect : NetworkBehaviour
    {
        public virtual void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets) { }
        public virtual void Init(List<int> amount) { }
        private const int NUMBER_OF_RANKS = 3;

        public class Ressource : Effect
        {
            private int[] amount = new int[NUMBER_OF_RANKS];
            private EnumLibrary.Ressources type;

            public void Init(List<int> amount, EnumLibrary.Ressources type)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.amount[i] = amount[i];
                }
                this.type = type;
            }

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
                        int temp = (int)rank;
                        target.GetComponent<Player>().possessedResources[type] += amount[temp];
                    }
                }
            }
        }

        public class Healing : Effect
        {
            private int[] amount = new int[NUMBER_OF_RANKS];

            public override void Init(List<int> amount)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.amount[i] = amount[i];
                }
            }

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                HealingEffect(rank, targets);
            }

            void HealingEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    int temp = (int)rank;
                    target.GetComponent<ICombatEntity>().Heal(this.amount[temp]);
                }
            }
        }

        public class Damage : Effect
        {
            private int[] amount = new int[NUMBER_OF_RANKS];
            public override void Init(List<int> amount)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.amount[i] = amount[i];
                }
            }

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DamageEffect(rank, targets);
            }

            void DamageEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    int temp = (int)rank;
                    target.GetComponent<ICombatEntity>().TakeDamage(amount[temp]);
                }
            }
        }

        public class Buff : Effect
        {
            private int[] power = new int[NUMBER_OF_RANKS];
            private int[] hp = new int[NUMBER_OF_RANKS];
            private List<Keywords>[] keywords = new List<Keywords>[NUMBER_OF_RANKS];

            public void Init(List<int> power, List<int> hp, List<Keywords>[] keywords)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.power[i] = power[i];
                    this.hp[i] = hp[i];
                    this.keywords[i] = keywords[i];
                }
            }

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                BuffEffect(rank, targets);
            }

            void BuffEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach(GameObject target in targets)
                {
                    int temp = (int)rank;
                    target.GetComponent<ICombatEntity>().power += power[temp];
                    target.GetComponent<ICombatEntity>().maxHP += hp[temp];
                    target.GetComponent<ICombatEntity>().currentHP += hp[temp];
                    target.GetComponent<ICombatEntity>().keywords.AddRange(keywords[temp]);
                }
            }
        }

        public class Debuff : Effect
        {
            private int[] power = new int[NUMBER_OF_RANKS];
            private int[] hp = new int[NUMBER_OF_RANKS];
            private List<Keywords>[] keywords = new List<Keywords>[NUMBER_OF_RANKS];

            public void Init(List<int> power, List<int> hp, List<Keywords>[] keywords)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.power[i] = power[i];
                    this.hp[i] = hp[i];
                    this.keywords[i] = keywords[i];
                }
            }

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DebuffEffect(rank, targets);
            }

            void DebuffEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    int temp = (int)rank;
                    target.GetComponent<ICombatEntity>().power -= power[temp];
                    target.GetComponent<ICombatEntity>().maxHP -= hp[temp];
                    target.GetComponent<ICombatEntity>().currentHP -= hp[temp];
                    for (int i = 0; i < NUMBER_OF_RANKS; i++)
                    {
                        List<Keywords> rankKeywords = keywords[i];
                        target.GetComponent<ICombatEntity>().keywords.ForEach(delegate (Keywords k)
                        {
                            if (rankKeywords.Contains(k))
                            {
                                target.GetComponent<ICombatEntity>().keywords.Remove(k);
                            }
                        
                        } );
                    }
                   
                }
            }
        }

        public class Draw : Effect
        {
            private int[] amount = new int[NUMBER_OF_RANKS];

            public override void Init(List<int> amount)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.amount[i] = amount[i];
                }
            }

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
            private int[] amount = new int[NUMBER_OF_RANKS];

            public override void Init(List<int> amount)
            {
                for (int i = 0; i > NUMBER_OF_RANKS; i++)
                {
                    this.amount[i] = amount[i];
                }
            }

            public override void ActivateEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                DiscardEffect(rank, targets);
            }

            void DiscardEffect(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (GameObject target in targets)
                {
                    int temp = (int)rank;
                    if (target.GetComponent<Hand>().GetCardsInZone().Count == 0) continue;
                    for(int i = 0; i < amount[temp]; i++)
                    {
                        var cardToDiscard = Random.Range(0, target.GetComponent<Hand>().GetCardsInZone().Count);
                        target.GetComponent<Hand>().Discard(target.GetComponent<Hand>().GetCardsInZone()[cardToDiscard]);
                    }
                }
            }
        }
    }
}
