using Core;

namespace GameSystem
{
    public class GameLoss
    {
        private TimePause _timePause;
        private GameLossMenu _lossMenu;

        public GameLoss(TimePause timePause, GameLossMenu lossMenu)
        {
            _timePause = timePause;
            _lossMenu = lossMenu;

            _lossMenu.Hide();
        }

        public void Lose()
        {
            _timePause.Pause();
            //_actionMapsController.DisableMainActionMap();
            //_actionMapsController.DisableJournalActionMap();
            _lossMenu.Show();
        }
    }
}