using Core;
using UISystem;

namespace GameSystem
{
    public class GameStart
    {
        private TimePause _timePause;
        private ActionMapsController _actionMapsController;
        private GameStartMenu _starttartMenu;

        public GameStart(TimePause timePause, ActionMapsController actionMapsController, GameStartMenu startMenu)
        {
            _timePause = timePause;
            _actionMapsController = actionMapsController;
            _starttartMenu = startMenu;

            _starttartMenu.Hide();
        }

        public void Initialize()
        {
            _timePause.Pause();
            _actionMapsController.DisableMainActionMap();
            _actionMapsController.DisableJournalActionMap();
            _actionMapsController.DisablePauseActionMap();
            _starttartMenu.Show();
        }

        public void StartGame()
        {
            _starttartMenu.Hide();
            _actionMapsController.EnableJournalActionMap();
            _actionMapsController.EnableMainActionMap();
            _actionMapsController.EnablePauseActionMap();
            _timePause.Unpause();
        }
    }
}