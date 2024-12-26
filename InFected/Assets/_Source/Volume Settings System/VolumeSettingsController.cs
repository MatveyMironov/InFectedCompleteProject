using System.Linq;
namespace AudioSettingsSystem
{
    public class VolumeSettingsController
    {
        private readonly VolumeSettings _volumeSettings;
        private readonly VolumeSettingsUI _volumeSettingsUI;
        private readonly VolumeSettingsDataSO _volumeSettingsData;

        public VolumeSettingsController(VolumeSettings volumeSettings, VolumeSettingsUI volumeSettingsUI, VolumeSettingsDataSO volumeSettingsData)
        {
            _volumeSettings = volumeSettings;
            _volumeSettingsUI = volumeSettingsUI;
            _volumeSettingsData = volumeSettingsData;

            GetVolumeDatas();

            _volumeSettingsUI.OnVolumeInputRecieved += ChangeVolume;
        }

        private void GetVolumeDatas()
        {
            foreach (VolumeSettingsDataSO.VolumeData volumeData in _volumeSettingsData.VolumeDatas)
            {
                _volumeSettingsUI.TrySetVolumeSlidersValue(volumeData.AudioGroupName, volumeData.Volume);
                ChangeVolume(volumeData.AudioGroupName, volumeData.Volume);
            }
        }

        private void ChangeVolume(string audioGroupName, float volume)
        {
            _volumeSettings.SetVolume(audioGroupName, volume);
            SaveVolumeData(audioGroupName, volume);
        }

        private void SaveVolumeData(string audioGroupName, float volume)
        {
            VolumeSettingsDataSO.VolumeData volumeData = _volumeSettingsData.VolumeDatas.FirstOrDefault(volumeData => volumeData.AudioGroupName == audioGroupName);

            if (volumeData == null)
            {
                volumeData = new(audioGroupName);
                _volumeSettingsData.VolumeDatas.Add(volumeData);
            }

            volumeData.Volume = volume;
        }
    }
}