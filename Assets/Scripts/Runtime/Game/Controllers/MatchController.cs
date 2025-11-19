using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine.Events;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    internal class MatchController : Controller<GameApplication>
    {
        MatchView View => App.View.Match;
        public List<Effect> triggers;

        void Awake()
        {
            AddListener<CountdownChangedEvent>(OnCountdownChanged);
            AddListener<WinButtonClickedEvent>(OnClientWinButtonClicked);
        }

        void OnDestroy()
        {
            RemoveListeners();
        }

        internal override void RemoveListeners()
        {
            RemoveListener<CountdownChangedEvent>(OnCountdownChanged);
            RemoveListener<WinButtonClickedEvent>(OnClientWinButtonClicked);

            foreach (var trigger in triggers)
            {
                trigger.RemoveEffect();
            }
        }

        void OnCountdownChanged(CountdownChangedEvent evt)
        {
            View.OnCountdownChanged(evt.NewValue);
        }

        void OnClientWinButtonClicked(WinButtonClickedEvent evt)
        {
            NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<Player>().OnPlayerAskedToWinServerRpc();
        }

        public void AddTrigger(Effect trigger)
        {
            triggers.Add(trigger);
            trigger.AddEffect();
        }

        public void RemoveTrigger(Effect trigger)
        {
            triggers.Remove(trigger);
            trigger.RemoveEffect();
        }

        public void CheckTrigger(Effect trigger)
        {
            if(triggers.Contains(trigger))
            {
                ActivateTrigger(trigger);
            }
        }

        void ActivateTrigger(Effect trigger)
        {
            trigger.ActivateTrigger();
        } 
    }
}
