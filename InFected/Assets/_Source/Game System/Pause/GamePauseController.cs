namespace GameSystem
{
    public class GamePauseController
    {
        private readonly GamePause _gamePause;

        public GamePauseController(GamePause gamePause)
        {
            _gamePause = gamePause;
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