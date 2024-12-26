using UnityEngine;

namespace GameSystem
{
    public class QuitInputController
    {
        private GameQuit _gameQuit;
        private IQuitInputListener _quitInputRecieved;

        public QuitInputController(GameQuit gameQuit, IQuitInputListener quitInputRecieved)
        {
            _gameQuit = gameQuit;
            _quitInputRecieved = quitInputRecieved;

            _quitInputRecieved.OnQuitInputRecieved += _gameQuit.Quit;
        }
    }
}