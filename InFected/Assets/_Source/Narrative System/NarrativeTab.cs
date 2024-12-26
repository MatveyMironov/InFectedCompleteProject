using System;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace NarrativeSystem
{
    public class NarrativeTab : HideableUI
    {
        [SerializeField] private Button _closeButton;

        public event Action OnCloseInputRecieved;

        private void Start()
        {
            _closeButton.onClick.AddListener(RecieveCloseInput);
        }

        private void RecieveCloseInput()
        {
            OnCloseInputRecieved?.Invoke();
        }
    }
}