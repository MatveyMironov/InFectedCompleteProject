using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public string SceneName { get => sceneName; }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
