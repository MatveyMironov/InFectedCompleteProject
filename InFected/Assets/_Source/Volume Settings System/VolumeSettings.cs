using UnityEngine;
using UnityEngine.Audio;

namespace AudioSettingsSystem
{
    public class VolumeSettings
    {
        private AudioMixer _audioMixer;

        public VolumeSettings(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }

        public void SetVolume(string audioGroupName, float volume)
        {
            volume = Mathf.Clamp(volume, 0.0001f, 1.0f);
            _audioMixer.SetFloat(audioGroupName, Mathf.Log10(volume) * 20);
            _audioMixer.GetFloat(audioGroupName, out float value);
        }
    }
}
