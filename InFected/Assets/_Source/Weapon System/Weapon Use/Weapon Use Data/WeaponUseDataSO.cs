using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewWeaponUseData", menuName = "Weapons/Weapon Use Data")]
    public class WeaponUseDataSO : ScriptableObject
    {
        [field: SerializeField] public WeaponUseParameters Parameters { get; private set; }
        [field: SerializeField] public WeaponUseSoundEffects SoundEffects { get; private set; }
        [field: SerializeField] public AnimatorOverrideController AnimatorController { get; private set;}
    }
}