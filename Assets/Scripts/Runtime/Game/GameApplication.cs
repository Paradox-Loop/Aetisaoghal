using System.Collections.Generic;
using Unity.Netcode;

namespace Unity.Template.Multiplayer.NGO.Runtime
{
    /// <summary>
    /// Manages the flow of the Game part of the application
    /// </summary>
    public class GameApplication : BaseApplication<GameModel, GameView, GameController>
    {
        internal new static GameApplication Instance { get; private set; }
        internal bool IsDedicatedServer => NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient;

        private Player startingPlayer;
        private int currentRound;
        private UnityEditor.Animations.AnimatorStateMachine gamestate;
        private List<Player> playersPassed;

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
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
