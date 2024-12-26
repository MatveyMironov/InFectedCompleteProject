using System;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GameWinMenu : HideableUI
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button remainButton;

        public event Action OnNextLevelInputRecieved;
        public event Action OnRemainInputRecieved;

        private void OnEnable()
        {
            nextLevelButton.onClick.AddListener(RecieveNextLevelInput);
            remainButton.onClick.AddListener(RecieveRemainInput);
        }

        private void RecieveNextLevelInput()
        {
            OnNextLevelInputRecieved?.Invoke();
        }

        private void RecieveRemainInput()
        {
            OnRemainInputRecieved?.Invoke();
        }
    }
}
