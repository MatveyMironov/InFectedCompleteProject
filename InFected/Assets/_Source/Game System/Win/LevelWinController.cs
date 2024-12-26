using KeySystem;

namespace GameSystem
{
    public class LevelWinController
    {
        public LevelWinController(KeysCollector samplesCollector, LevelWin gameWin)
        {
            samplesCollector.OnAllSamplesCollected += gameWin.Win;
        }
    }
}