using GameSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class GamePauseMenu : HideableUI, IQuitInputListener
    {
        [SerializeField] private GameObject mainWindow;
        [SerializeField] private GameObject audioSettingsWindow;

        [Space]
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button openAudioSettingsButton;
        [SerializeField] private Button closeAudioSettingsButton;

        public event Action OnResumeInputRecieved;
        public event Action OnQuitInputRecieved;

        private void OnEnable()
        {
            resumeButton.onClick.AddListener(RecieveResumeInput);
            quitButton.onClick.AddListener(RecieveQuitInput);

            openAudioSettingsButton.onClick.AddListener(OpenAudioSettings);
            closeAudioSettingsButton.onClick.AddListener(OpenMain);
        }

        public override void Show()
        {
            OpenMain();
            base.Show();
        }

        private void OpenMain()
        {
            audioSettingsWindow.SetActive(false);
            mainWindow.SetActive(true);
        }

        private void OpenAudioSettings()
        {
            mainWindow.SetActive(false);
            audioSettingsWindow.SetActive(true);
        }

        private void RecieveResumeInput()
        {
            OnResumeInputRecieved?.Invoke();
        }

        private void RecieveQuitInput()
        {
            OnQuitInputRecieved?.Invoke();
        }
    }
}
