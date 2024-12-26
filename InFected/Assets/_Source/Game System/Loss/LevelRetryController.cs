using System;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    internal class LevelRetryController
    {
        private readonly GameLossMenu _gameLossMenu;

        public LevelRetryController(GameLossMenu gameLossMenu)
        {
            _gameLossMenu = gameLossMenu ?? throw new ArgumentNullException(nameof(gameLossMenu));

            _gameLossMenu.OnRetryInputRecieved += RetryLevel;
        }

        public void RetryLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
