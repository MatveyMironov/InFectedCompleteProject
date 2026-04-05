using Core;
using UnityEngine;

namespace GameSystem
{
    public class GamePause
    {
        private readonly ActionMapsController _actionMapsController;

        public GamePause(ActionMapsController actionMapsController)
        {
            _actionMapsController = actionMapsController;
        }

        public bool IsPaused { get; private set; }

        public void PauseGame()
        {
            if (IsPaused) { return; }

            Time.timeScale = 0.0f;

            _actionMapsController.DisableMainActionMap();
            _actionMapsController.DisableJournalActionMap();

            IsPaused = true;
        }

        public void ResumeGame()
        {
            if (!IsPaused) { return; }

            _actionMapsController.EnableMainActionMap();
            _actionMapsController.EnableJournalActionMap();
            
            Time.timeScale = 1.0f;

            IsPaused = false;
        }
    }
}
