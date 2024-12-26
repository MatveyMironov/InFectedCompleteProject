using Core;
using UISystem;

namespace GameSystem
{
    public class GamePause
    {
        private TimePause _timePause;
        ActionMapsController _actionMapsController;
        private GamePauseMenu _pauseMenu;

        public GamePause(TimePause timePause, ActionMapsController actionMapsController, GamePauseMenu pauseMenu)
        {
            _timePause = timePause;
            _actionMapsController = actionMapsController;
            _pauseMenu = pauseMenu;

            _pauseMenu.Hide();
        }

        public bool IsPaused { get; private set; }

        public void PauseGame()
        {
            if (IsPaused) { return; }

            _timePause.Pause();
            _actionMapsController.DisableMainActionMap();
            _actionMapsController.DisableJournalActionMap();
            _pauseMenu.Show();

            IsPaused = true;
        }

        public void ResumeGame()
        {
            if (!IsPaused) { return; }

            _pauseMenu.Hide();
            _actionMapsController.EnableMainActionMap();
            _actionMapsController.EnableJournalActionMap();
            _timePause.Unpause();

            IsPaused = false;
        }
    }
}
