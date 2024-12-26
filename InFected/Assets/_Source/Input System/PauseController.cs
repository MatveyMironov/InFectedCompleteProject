namespace GameSystem
{
    public class PauseController
    {
        private GamePause _pauseManager;

        public PauseController(GamePause pauseManager)
        {
            _pauseManager = pauseManager;
        }

        public void TogglePause()
        {
            if (_pauseManager.IsPaused)
            {
                _pauseManager.ResumeGame();
            }
            else
            {
                _pauseManager.PauseGame();
            }
        }
    }
}