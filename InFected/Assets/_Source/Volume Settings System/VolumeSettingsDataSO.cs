using System;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSettingsSystem
{
    [CreateAssetMenu(fileName = "NewAudioSettings", menuName = "Audio/Audio Settings Data")]
    public class VolumeSettingsDataSO : ScriptableObject
    {
        [SerializeField] private List<VolumeData> volumeDatas = new();
        public List<VolumeData> VolumeDatas { get { return volumeDatas; } }

        [Serializable]
        public class VolumeData
        {
            [SerializeField] private string audioGroupName;
            [SerializeField] private float volume;

            public VolumeData(string audioGroupName)
            {
                this.audioGroupName = audioGroupName;
            }

            public string AudioGroupName { get { return audioGroupName; } }
            public float Volume { get { return volume; } set { volume = value; } }
        }
    }
}
