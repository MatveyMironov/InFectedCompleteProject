using Core;
using System;

namespace GameSystem
{
    internal class Remain
    {
        private readonly GameWinMenu _winMenu;
        private readonly TimePause _timePause;

        public Remain(GameWinMenu gameWinMenu, TimePause timePause)
        {
            _winMenu = gameWinMenu ?? throw new ArgumentNullException(nameof(gameWinMenu));
            _timePause = timePause ?? throw new ArgumentNullException(nameof(timePause));

            _winMenu.OnRemainInputRecieved += RemainOnLevel;
        }

        private void RemainOnLevel()
        {
            _timePause.Unpause();
            //_actionMapsController.EnableMainActionMap();
            //_actionMapsController.EnableJournalActionMap();
            _winMenu.Hide();
        }
    }
}
