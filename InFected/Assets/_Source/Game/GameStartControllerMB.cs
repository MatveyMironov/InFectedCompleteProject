using UnityEngine;
using UnityEngine.Events;

public class GameStartControllerMB : MonoBehaviour
{
    [SerializeField] private UnityEvent OnGameStarted;

    private void Start()
    {
        OnGameStarted.Invoke();
    }
}