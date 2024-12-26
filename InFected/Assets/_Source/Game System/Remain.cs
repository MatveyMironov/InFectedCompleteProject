using Core;
using System;

namespace GameSystem
{
    internal class Remain
    {
        private readonly GameWinMenu _winMenu;
        private readonly TimePause _timePause;
        private readonly ActionMapsController _actionMapsController;

        public Remain(GameWinMenu gameWinMenu, TimePause timePause, ActionMapsController actionMapsController)
        {
            _winMenu = gameWinMenu ?? throw new ArgumentNullException(nameof(gameWinMenu));
            _timePause = timePause ?? throw new ArgumentNullException(nameof(timePause));
            _actionMapsController = actionMapsController ?? throw new ArgumentNullException(nameof(actionMapsController));

            _winMenu.OnRemainInputRecieved += RemainOnLevel;
        }

        private void RemainOnLevel()
        {
            _timePause.Unpause();
            _actionMapsController.EnableMainActionMap();
            _actionMapsController.EnableJournalActionMap();
            _winMenu.Hide();
        }
    }
}
