using UISystem;

namespace GameSystem
{
    public class GameStartController
    {
        public GameStartController(GameStart gameStart, GameStartMenu gameStartMenu)
        {
            gameStartMenu.OnStartButtonClicked += gameStart.StartGame;
        }
    }
}