using Unity.Netcode;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    internal class Player : NetworkBehaviour
    {
        private int nbrOfCardsRoundStart = 1;
        private int nbrOfManaStoneRoundStart = 1;
        private int nbrOfTokenCreatedRoundStart = 1;
        private List<Zone> controlledZones;
        private Leader leader;
        private List<Ressource> possessedResources;

        Gamemode gamemode;

        // vars related to the player's turn time limit
        private const float TIME_LIMIT = 10;
        private float turnStart;
        private bool warning = false;

        //list of events triggered by a player
        UnityEvent playerLevelUp;
        UnityEvent playerDefeated;
        UnityEvent playerPassTurn;

        [ClientRpc]
        internal void OnClientPrepareGameClientRpc()
        {
            if (!IsLocalPlayer)
            {
                return;
            }
            if (MetagameApplication.Instance)
            {
                MetagameApplication.Instance.Broadcast(new MatchEnteredEvent());
            }
            Debug.Log("[Local client] Preparing game [Showing loading screen]");
            if (!IsServer) //the server already does this before asking clients to do the same
            {
                CustomNetworkManager.Singleton.InstantiateGameApplication();
            }
            OnClientReadyToStart();
        }

        internal void OnClientReadyToStart()
        {
            Debug.Log("[Local client] Notifying server I'm ready");
            OnServerNotifiedOfClientReadinessServerRpc();
        }

        [ServerRpc]
        internal void OnServerNotifiedOfClientReadinessServerRpc()
        {
            Debug.Log("[Server] I'm ready");
            CustomNetworkManager.Singleton.OnServerPlayerIsReady(this);
        }

        [ClientRpc]
        internal void OnClientStartGameClientRpc()
        {
            if (!IsLocalPlayer) { return; }
            GameApplication.Instance.Broadcast(new StartMatchEvent(false, true));
        }

        [ServerRpc]
        internal void OnPlayerAskedToWinServerRpc()
        {
            OnServerPlayerAskedToWin();
        }

        internal void OnServerPlayerAskedToWin()
        {
            GameApplication.Instance.Broadcast(new EndMatchEvent(this));
        }
        // code by Mark-Olivier

        private void Start()
        {
            playerDefeated = new UnityEvent();
            playerPassTurn = new UnityEvent();
            playerLevelUp = new UnityEvent();

        }
        public void Update()
        {
            if (Time.time == turnStart + TIME_LIMIT)
            {
                if(warning) //if no actions are taken before countdown ends, end the turn
                {
                    //play time expired anim
                    Pass();
                }
                if(!warning) // if no actions are taken in the allowed time start the countdown animation
                {
                    warning = true;
                    turnStart = Time.time;
                }
            }
        }
        public void Forfeit() // call when a player forfeits the game
        {
            //Need way to specify which player is defeated
            playerDefeated.Invoke();
        }

        public void LevelUp()
        {
            playerLevelUp.Invoke();
        }

        public void Pass() //called when a player pass turn, skipping his action and getting ready to end current round
        {
            // How can I notify the GameMode
            playerPassTurn.Invoke();
        }

        public void TakeTurn() // call when this player may take an action of pass
        {
            // highlight all possible interractables.
            // enable skip turn and level up button if level up is available (not used this turn and condition/ressources suffisant)
            //start turn limit timer
            turnStart = Time.time;
            warning = false; //set warning flag to false before each turn start
            //wait until input from active player
        }


        public void PlayCard(Card card) // play the selected card from hand and activate its effects
        {
            if(gamemode.CheckLegalAction())
            { 
                card.Play();
            }
            
        }

        public void Select(Selectable selection)
        {
            if(gamemode.CheckLegalAction())
            {
                selection.Select();
            }
        }

        public void ZoomCard(Card card) // zooms on a selected card (can be called outside of player's turn
        {
            // spawn window with card's text enlarged
            //card.Select(); //requires the cards to be updated to implement select
        }

        public void Attack(ICombatEntity attacker, ICombatEntity target)
        {
            if(gamemode.CheckLegalAction())
            {
                attacker.Attack(target);
            }
            else
            {
                //show warning about exhausted units/leader not being able to attack
            }
        }
    }

    
}
