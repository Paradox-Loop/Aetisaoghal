using Codice.Client.BaseCommands;
using System.Collections.Generic;
using UnityEditorInternal;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    public class Gamemode // Singleton
    {
        private Player startingPlayer;
        private int currentRound;
        private UnityEditor.Animations.AnimatorStateMachine gamestate;
        private List<Player> playersPassed;
        static readonly Gamemode Instance = new Gamemode();
        static Gamemode GetGamemode()
        {
            if (Instance != null)
            {
                return Instance;
            }
            return null;
        }



        private void GameMode()
        {
            playersPassed = new List<Player>();
        }

        private void StartGame()
        {

        }

        private void EndGame(Player player)
        {

        }

        private void StartRound()
        {
            playersPassed.Clear();
        }

        private void EndRound()
        {
            if (playersPassed.Count > 2)
            {
                if (playersPassed[0] == startingPlayer)
                {
                    startingPlayer = playersPassed[1];
                }
                else
                {
                    startingPlayer = playersPassed[0];
                }
                playersPassed.Clear();
            }
        }

        private void StartTurn()
        {
            Player player = new Player();
            player.TakeTurn();
            HighlightPossibleActions();
        }

        private void EndTurn()
        {

        }

        private void HighlightPossibleActions()
        {

        }

        private void DoTrigger()
        {

        }

        public bool CheckLegalAction()
        {
            return true;
        }
    }
}