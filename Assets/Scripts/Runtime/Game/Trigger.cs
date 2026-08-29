using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Trigger : NetworkBehaviour
    {
        public List<Effect> effects;
        public virtual void CreateTrigger() { }
        public virtual void DeleteTrigger() { }
        public virtual void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets) { }

        public void Init(List<Effect> effects)
        {
            this.effects = effects;
        }

        public class Deploy : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> DeployTriggerEvent;

            public override void CreateTrigger()
            {
                DeployTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                DeployTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                DeployTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Enrage : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> EnrageTriggerEvent;

            public override void CreateTrigger()
            {
                EnrageTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                EnrageTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                EnrageTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Perish : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> PerishTriggerEvent;

            public override void CreateTrigger()
            {
                PerishTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                PerishTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                PerishTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Prepare : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> PrepareTriggerEvent;

            public override void CreateTrigger()
            {
                PrepareTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                PrepareTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                PrepareTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Regen : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> RegenTriggerEvent;

            public override void CreateTrigger()
            {
                RegenTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                RegenTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                RegenTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Sabotage : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> SabotageTriggerEvent;

            public override void CreateTrigger()
            {
                SabotageTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                SabotageTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                SabotageTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Strike : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> StrikeTriggerEvent;

            public override void CreateTrigger()
            {
                StrikeTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                StrikeTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                StrikeTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }

        public class Supply : Trigger
        {
            UnityEvent<EnumLibrary.Ranks, List<GameObject>> SupplyTriggerEvent;

            public override void CreateTrigger()
            {
                SupplyTriggerEvent = new UnityEvent<EnumLibrary.Ranks, List<GameObject>>();
                SupplyTriggerEvent.AddListener(DoTrigger);
            }

            public override void DeleteTrigger()
            {
                SupplyTriggerEvent.RemoveListener(DoTrigger);
            }

            public override void DoTrigger(EnumLibrary.Ranks rank, List<GameObject> targets)
            {
                foreach (var effect in effects)
                {
                    effect.ActivateEffect(rank, targets);
                }
            }
        }
    }
}
