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
        public List<Zone> zones;

        private Player startingPlayer;
        private Player activePlayer;
        private List<Player> players;
        private List<Player> playersPassed;
        private int nbOfPlayers;

        private int currentRound;

        //Make it it's own class
        //private State gamestate;

        void Awake()
        {
            AddListener<CountdownChangedEvent>(OnCountdownChanged);
            AddListener<WinButtonClickedEvent>(OnClientWinButtonClicked);
            foreach(Player player in players)
            {
                GameObject Hand = new GameObject("Hand", typeof(Hand));
                player.controlledZones.Add(Hand.GetComponent<Hand>());
                GameObject MainDeck = new GameObject("MainDeck", typeof(MainDeck));
                player.controlledZones.Add(MainDeck.GetComponent<MainDeck>());
                GameObject ManaDeck = new GameObject("ManaDeck", typeof(ManaDeck));
                player.controlledZones.Add(ManaDeck.GetComponent<ManaDeck>());
                GameObject ExtraZone = new GameObject("ExtraZone", typeof(ExtraZone));
                player.controlledZones.Add(ExtraZone.GetComponent<ExtraZone>());
                GameObject FrontLine = new GameObject("FrontLine", typeof(FrontLine));
                player.controlledZones.Add(FrontLine.GetComponent<FrontLine>());
                GameObject BackLine = new GameObject("BackLine", typeof(BackLine));
                player.controlledZones.Add(BackLine.GetComponent<BackLine>());
                GameObject ManaZone = new GameObject("ManaZone", typeof(ManaZone));
                player.controlledZones.Add(ManaZone.GetComponent<ManaZone>());
                GameObject MainGrave = new GameObject("MainGrave", typeof(MainGrave));
                player.controlledZones.Add(MainGrave.GetComponent<MainGrave>());
                GameObject ManaGrave = new GameObject("ManaGrave", typeof(ManaGrave));
                player.controlledZones.Add(ManaGrave.GetComponent<ManaGrave>());
                zones.AddRange(player.controlledZones);
            }
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

        private void StartGame()
        {
            nbOfPlayers = players.Count;
            startingPlayer = players[Random.Range(0, nbOfPlayers)];
            currentRound = 0;
            StartRound();
        }

        private void EndGame(Player player)
        {

        }

        private void StartRound()
        {
            playersPassed.Clear();
            currentRound++;
            activePlayer = startingPlayer;
            CheckTriggers();
        }

        private void EndRound()
        {
            CheckTriggers();
            if (playersPassed.Count >= nbOfPlayers)
            {
                int currentIndex = players.IndexOf(startingPlayer);
                currentIndex = (currentIndex + 1) % players.Count;
                startingPlayer = players[currentIndex];
                playersPassed.Clear();
            }
        }

        private void StartTurn()
        {
            CheckTriggers();
            activePlayer.TakeTurn();
            HighlightPossibleActions();
        }

        private void EndTurn()
        {
            CheckTriggers();
            int currentIndex = players.IndexOf(activePlayer);
            currentIndex = (currentIndex + 1) % players.Count;
            activePlayer = players[currentIndex];
        }

        private void HighlightPossibleActions()
        {

        }

        public bool CheckLegalAction()
        {
            return true;
        }

        public Zone GetZone(Card cardToFind) {
            foreach (Zone zone in zones)
            {
                foreach(Card card in zone.GetCardsInZone())
                {
                    if(card == cardToFind)
                    {
                        return zone;
                    }
                }
            }
            return null;
        }
    }
}
