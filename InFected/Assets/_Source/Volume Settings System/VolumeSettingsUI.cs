using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AudioSettingsSystem
{
    public class VolumeSettingsUI : MonoBehaviour
    {
        [SerializeField] private List<VolumeSlider> volumeSliders = new();

        public event Action<string, float> OnVolumeInputRecieved;

        private void Start()
        {
            foreach (VolumeSlider volumeSlider in volumeSliders)
            {
                VolumeSliderManager volumeSliderManager = new(volumeSlider.Slider, volumeSlider.AudioGroupName, OnVolumeInputRecieved);
            }
        }

        public bool TrySetVolumeSlidersValue(string audioGroupName, float volume)
        {
            VolumeSlider volumeSlider = volumeSliders.Find(volumeSlider => volumeSlider.AudioGroupName == audioGroupName);

            if (volumeSlider != null)
            {
                volumeSlider.Slider.value = volume;

                return true;
            }

            return false;
        }

        [Serializable]
        private class VolumeSlider
        {
            [SerializeField] private Slider slider;
            [SerializeField] private string audioGroupName;

            public Slider Slider { get => slider; }
            public string AudioGroupName { get => audioGroupName; }
        }

        private class VolumeSliderManager
        {
            private readonly Slider _slider;
            private readonly string _audioGroupName;
            private readonly Action<string, float> _onVolumeInputRecieved;

            public VolumeSliderManager(Slider slider, string audioGroupName, Action<string, float> onVolumeInputRecieved)
            {
                _slider = slider;
                _audioGroupName = audioGroupName;
                _onVolumeInputRecieved = onVolumeInputRecieved;

                _slider.onValueChanged.AddListener(RecieveVolumeInput);
            }

            private void RecieveVolumeInput(float volumeInput)
            {
                _onVolumeInputRecieved?.Invoke(_audioGroupName, volumeInput);
            }
        }
    }
}
