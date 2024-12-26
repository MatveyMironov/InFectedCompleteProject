using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
    public class WeaponDataSO : ScriptableObject
    {
        // This class will store all information about one type of weapon

        [field: Header("Information")]
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [Header("Ammunition")]
        [SerializeField] private WeaponMagazineDataSO magazineData;

        [Header("Effects")]
        [SerializeField] private WeaponSoundEffects soundEffects;

        [Header("Mechanism")]
        [SerializeField] private WeaponRecieverDataSO recieverData;
        [SerializeField] private WeaponShooterDataSO shooterData;

        [Header("Use")]
        [SerializeField] private WeaponUseDataSO useData;

        public WeaponReciever WeaponReciever { get =>  recieverData.WeaponReciever; }
        public WeaponShooter WeaponShooter { get => shooterData.WeaponShooter; }
        public WeaponMagazine Magazine { get => magazineData.WeaponMagazine; }
        public WeaponSoundEffects SoundEffects { get => soundEffects; }
        public WeaponUseParameters UseParameters { get => useData.Parameters; }
        public WeaponUseSoundEffects UseSoundEffects { get => useData.SoundEffects; }
        public AnimatorOverrideController AnimatorController { get => useData.AnimatorController; }

        public Weapon Weapon
        {
            get
            {
                return new Weapon(Name, Icon, WeaponReciever, WeaponShooter, Magazine, SoundEffects, UseParameters, UseSoundEffects, AnimatorController);
            }
        }
    }
}
