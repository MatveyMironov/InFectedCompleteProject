namespace GameSystem
{
    public class LevelTransitionController
    {
        private readonly SceneLoader _levelTransition;
        private readonly GameWinMenu _gameWinMenu;

        public LevelTransitionController(SceneLoader levelTransition, GameWinMenu gameWinMenu)
        {
            _levelTransition = levelTransition ?? throw new System.ArgumentNullException(nameof(levelTransition));
            _gameWinMenu = gameWinMenu ?? throw new System.ArgumentNullException(nameof(gameWinMenu));

            _gameWinMenu.OnNextLevelInputRecieved += _levelTransition.LoadScene;
        }
    }
}
