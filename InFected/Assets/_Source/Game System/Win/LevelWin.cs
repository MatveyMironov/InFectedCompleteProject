using Core;
using UISystem;

namespace GameSystem
{
    public class LevelWin
    {
        private readonly TimePause _timePause;
        private readonly ActionMapsController _actionMapsController;
        private readonly GameWinMenu _winMenu;

        public LevelWin(TimePause timePause, ActionMapsController actionMapsController, GameWinMenu winMenu)
        {
            _timePause = timePause;
            _actionMapsController = actionMapsController;
            _winMenu = winMenu;

            _winMenu.Hide();
        }

        public void Win()
        {
            _timePause.Pause();
            _actionMapsController.DisableMainActionMap();
            _actionMapsController.DisableJournalActionMap();
            _winMenu.Show();
        }
    }
}