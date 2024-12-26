using System;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GameLossMenu : HideableUI, IQuitInputListener
    {
        [SerializeField] private Button quitButton;
        [SerializeField] private Button retryButton;

        public event Action OnQuitInputRecieved;
        public event Action OnRetryInputRecieved;

        private void OnEnable()
        {
            quitButton.onClick.AddListener(RecieveQuitInput);
            retryButton.onClick.AddListener(RecieveRetryInput);
        }

        private void RecieveQuitInput()
        {
            OnQuitInputRecieved?.Invoke();
        }

        private void RecieveRetryInput()
        {
            OnRetryInputRecieved?.Invoke();
        }
    }
}
