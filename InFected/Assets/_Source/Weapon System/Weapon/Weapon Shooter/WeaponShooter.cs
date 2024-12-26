using System;

namespace WeaponSystem
{
    public abstract class WeaponShooter
    {
        // This class defines what exits gun's muzlle: bullet, buckshot, laser beam or anything else

        public ShooterParameters Parameters { get; }

        protected WeaponShooter(ShooterParameters parameters)
        {
            Parameters = parameters;
        }

        public abstract void Shoot(WeaponBody body, WeaponSoundEffects soundEffects);

        [Serializable]
        public abstract class ShooterParameters
        {
            
        }
    }
}
