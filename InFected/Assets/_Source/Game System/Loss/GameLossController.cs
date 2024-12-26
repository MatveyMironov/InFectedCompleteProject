using PlayerSystem;

namespace GameSystem
{
    public class GameLossController
    {
        private readonly PlayerDeathController _playerDeathController;
        private readonly GameLoss _gameLoss;

        public GameLossController(PlayerDeathController playerDeathController, GameLoss gameLoss)
        {
            _playerDeathController = playerDeathController;
            _gameLoss = gameLoss;

            _playerDeathController.OnPlayerDeath += _gameLoss.Lose;
        }
    }
}