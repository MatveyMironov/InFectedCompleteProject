using UnityEngine;

namespace WeaponSystem
{
    public class WeaponSoundEffectsDataSO : ScriptableObject
    {
        [field: SerializeField] public WeaponSoundEffects SoundEffects { get; private set; }
    }
}