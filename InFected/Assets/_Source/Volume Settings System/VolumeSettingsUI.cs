using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioSettingsSystem
{
    public class VolumeSettingsUI : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        //[SerializeField] private VolumeSettingsDataSO volumeSettingsData;

        [Space]
        [SerializeField] private List<VolumeSlider> volumeSliders = new();

        private void Awake()
        {
            Setup();
        }

        private void Setup()
        {
            foreach (VolumeSlider volumeSlider in volumeSliders)
            {
                DisplayCurrentVolume(volumeSlider);

                volumeSlider.Slider.onValueChanged.AddListener(SetVolume);

                void SetVolume(float sliderValue)
                {
                    sliderValue = Mathf.Clamp(sliderValue, 0.0001f, 1.0f);
                    float volume = Mathf.Log10(sliderValue) * 20;
                    audioMixer.SetFloat(volumeSlider.ParameterName, volume);
                }
            }
        }

        private void DisplayCurrentVolume(VolumeSlider volumeSlider)
        {
            if (audioMixer.GetFloat(volumeSlider.ParameterName, out float volume))
            {
                float sliderValue = Mathf.Pow(10, volume / 20);
                volumeSlider.Slider.SetValueWithoutNotify(sliderValue);
            }
        }

        [Serializable]
        private class VolumeSlider
        {
            [Tooltip("Name of the exposed volume parameter from Audio Mixer")]
            [SerializeField] private string parameterName;
            [SerializeField] private Slider slider;

            public string ParameterName { get => parameterName; }
            public Slider Slider { get => slider; }
        }
    }
}
