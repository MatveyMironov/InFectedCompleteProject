using UISystem;

namespace GameSystem
{
    public class GamePauseController
    {
        private readonly GamePause _gamePause;
        private readonly GamePauseMenu _gamePauseMenu;

        public GamePauseController(GamePause gamePause, GamePauseMenu gamePauseMenu)
        {
            _gamePause = gamePause;
            _gamePauseMenu = gamePauseMenu;
            
            _gamePauseMenu.OnResumeInputRecieved += _gamePause.ResumeGame;
        }

        public void TogglePause()
        {
            if (_gamePause.IsPaused)
            {
                _gamePause.ResumeGame();
            }
            else
            {
                _gamePause.PauseGame();
            }
        }
    }
}