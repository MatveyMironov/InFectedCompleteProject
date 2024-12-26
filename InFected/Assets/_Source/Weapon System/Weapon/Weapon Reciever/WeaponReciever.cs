using System;

namespace WeaponSystem
{
    public abstract class WeaponReciever
    {
        protected readonly RecieverParameters _parameters;

        protected bool _isTriggerPulled;

        protected WeaponReciever(RecieverParameters parameters)
        {
            _parameters = parameters;
        }

        public bool IsRecharged { get; protected set; }
        public virtual bool CanBeManuallyRecharged { get { return true; } }
        public bool CanFire { get; protected set; }

        public abstract void PullTheTrigger(WeaponMagazine magazine,
                                            WeaponBody body,
                                            WeaponSoundEffects soundEffects,
                                            WeaponShooter shooter);

        public abstract void ReleaseTheTrigger();

        public virtual void RechargeManually(WeaponMagazine magazine,
                                             WeaponBody body,
                                             WeaponSoundEffects soundEffects,
                                             WeaponShooter shooter)
        {
            if (!CanBeManuallyRecharged) { return; }

            Recharge(magazine, body, soundEffects, shooter);
        }

        protected virtual void Recharge(WeaponMagazine magazine,
                                         WeaponBody body,
                                         WeaponSoundEffects soundEffects,
                                         WeaponShooter shooter)
        {
            if (magazine.Load > 0)
            {
                IsRecharged = true;
            }
        }

        protected abstract void Discharge(WeaponMagazine magazine,
                                          WeaponBody body,
                                          WeaponSoundEffects soundEffects,
                                          WeaponShooter shooter);

        [Serializable]
        public abstract class RecieverParameters
        {
            
        }
    }
}
