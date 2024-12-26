using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class GameStartMenu : HideableUI
    {
        [SerializeField] private Button startButton;

        public event Action OnStartButtonClicked;

        private void OnEnable()
        {
            startButton.onClick.AddListener(InvokeStartButtocClickedEvent);
        }

        private void InvokeStartButtocClickedEvent()
        {
            OnStartButtonClicked?.Invoke();
        }
    }
}
