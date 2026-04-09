using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaderSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}