namespace GameSystem
{
    public class GameQuit
    {
        private readonly SceneLoader _sceneLoader;

        public GameQuit(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader ?? throw new System.ArgumentNullException(nameof(sceneLoader));
        }

        public void Quit()
        {
            _sceneLoader.LoadScene();
        }
    }
}