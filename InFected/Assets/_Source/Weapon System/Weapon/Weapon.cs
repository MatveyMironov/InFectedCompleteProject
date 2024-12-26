using UnityEngine;

namespace WeaponSystem
{
    public class Weapon
    {
        // This class will store all information about particular weapon:
        // it's functionality, magazine load etc.

        public Weapon(string name,
                          Sprite icon,
                          WeaponReciever reciever,
                          WeaponShooter shooter,
                          WeaponMagazine magazine,
                          WeaponSoundEffects soundEffects,
                          WeaponUseParameters useParameters,
                          WeaponUseSoundEffects useSoundEffects,
                          AnimatorOverrideController animator)
        {
            Name = name;
            Icon = icon;
            Reciever = reciever;
            Shooter = shooter;
            Magazine = magazine;
            SoundEffects = soundEffects;
            UseParameters = useParameters;
            UseSoundEffects = useSoundEffects;
            Animator = animator;
        }

        public string Name { get; }
        public Sprite Icon { get; }

        public WeaponReciever Reciever { get; }
        public WeaponShooter Shooter { get; }
        public WeaponMagazine Magazine { get; }
        public WeaponSoundEffects SoundEffects { get; }
        public WeaponUseParameters UseParameters { get; }
        public WeaponUseSoundEffects UseSoundEffects { get; }
        public AnimatorOverrideController Animator { get; }
    }
}
