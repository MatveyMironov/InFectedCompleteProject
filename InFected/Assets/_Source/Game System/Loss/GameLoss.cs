using Core;

namespace GameSystem
{
    public class GameLoss
    {
        private TimePause _timePause;
        private ActionMapsController _actionMapsController;
        private GameLossMenu _lossMenu;

        public GameLoss(TimePause timePause, ActionMapsController actionMapsController, GameLossMenu lossMenu)
        {
            _timePause = timePause;
            _actionMapsController = actionMapsController;
            _lossMenu = lossMenu;

            _lossMenu.Hide();
        }

        public void Lose()
        {
            _timePause.Pause();
            _actionMapsController.DisableMainActionMap();
            _actionMapsController.DisableJournalActionMap();
            _lossMenu.Show();
        }
    }
}