using UnityEngine;

namespace GameSystem
{
    public class TimePause
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}
