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
        public virtual void ActivateTrigger() { }

        public virtual void Activate(EnumLibrary.Ranks rank, List<GameObject> targets){}

        public class Ressource : Effect
        {
            UnityEvent RessourceEffectEvent;
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

            public override void ActivateTrigger()
            {
                RessourceEffectEvent.Invoke();
            }

            void RessourceTrigger()
            {

            }
        }

        public class Healing : Effect
        {
            UnityEvent HealingEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                HealingEffectEvent.AddListener(HealingTrigger);
            }

            public override void RemoveEffect()
            {
                HealingEffectEvent.RemoveListener(HealingTrigger);
            }

            public override void ActivateTrigger()
            {
                HealingEffectEvent.Invoke();
            }

            void HealingTrigger()
            {

            }
        }

        public class Damage : Effect
        {
            UnityEvent DamageEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                DamageEffectEvent.AddListener(DamageTrigger);
            }

            public override void RemoveEffect()
            {
                DamageEffectEvent.RemoveListener(DamageTrigger);
            }

            public override void ActivateTrigger()
            {
                DamageEffectEvent.Invoke();
            }

            void DamageTrigger()
            {

            }
        }

        public class Buff : Effect
        {
            UnityEvent BuffEffectEvent;
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

            public override void ActivateTrigger()
            {
                BuffEffectEvent.Invoke();
            }

            void BuffTrigger()
            {

            }
        }

        public class Debuff : Effect
        {
            UnityEvent DebuffEffectEvent;
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

            public override void ActivateTrigger()
            {
                DebuffEffectEvent.Invoke();
            }

            void DebuffTrigger()
            {

            }
        }

        public class Draw : Effect
        {
            UnityEvent DrawEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                DrawEffectEvent.AddListener(DrawTrigger);
            }

            public override void RemoveEffect()
            {
                DrawEffectEvent.RemoveListener(DrawTrigger);
            }

            public override void ActivateTrigger()
            {
                DrawEffectEvent.Invoke();
            }

            void DrawTrigger()
            {

            }
        }

        public class Discard : Effect
        {
            UnityEvent DiscardEffectEvent;
            private int amount;

            public override void AddEffect()
            {
                DiscardEffectEvent.AddListener(DiscardTrigger);
            }

            public override void RemoveEffect()
            {
                DiscardEffectEvent.RemoveListener(DiscardTrigger);
            }

            public override void ActivateTrigger()
            {
                DiscardEffectEvent.Invoke();
            }

            void DiscardTrigger()
            {

            }
        }
    }
}
