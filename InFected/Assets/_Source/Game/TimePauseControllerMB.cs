using UnityEngine;

namespace GameSystem
{
    public class TimePauseControllerMB : MonoBehaviour
    {
        public void Pause()
        {
            Time.timeScale = 0.0f;
        }

        public void Unpause()
        {
            Time.timeScale = 1.0f;
        }
    }
}