using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    internal class MatchController : Controller<GameApplication>
    {
        MatchView View => App.View.Match;
        public List<Card> cardWithTriggers;

        void Awake()
        {
            AddListener<CountdownChangedEvent>(OnCountdownChanged);
            AddListener<WinButtonClickedEvent>(OnClientWinButtonClicked);
            Debug.Log("Hello");
        }

        void OnDestroy()
        {
            RemoveListeners();
        }

        internal override void RemoveListeners()
        {
            RemoveListener<CountdownChangedEvent>(OnCountdownChanged);
            RemoveListener<WinButtonClickedEvent>(OnClientWinButtonClicked);

            foreach (var card in cardWithTriggers)
            {
                foreach(var trigger in card.triggers)
                {
                    trigger.DeleteTrigger();
                }
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

        public void AddCardWithTrigger(Card card)
        {
            cardWithTriggers.Add(card);
        }

        public void RemoveCardWithTrigger(Card card)
        {
            cardWithTriggers.Remove(card);
        }

        public void CheckTriggers()
        {
            foreach (var card in cardWithTriggers)
            {
                foreach (var trigger in card.triggers)
                {
                    ActivateTrigger(card, trigger, new List<GameObject> {card.gameObject});
                }
            }  
        }

        void ActivateTrigger(Card card, Trigger trigger, List<GameObject> targets)
        {
            card.DoTrigger(trigger, targets);
        }

        public Zone GetZone(Card card) {
            return null;
        }
    }
}
