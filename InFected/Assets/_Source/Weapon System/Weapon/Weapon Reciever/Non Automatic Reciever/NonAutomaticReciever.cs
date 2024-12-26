using System;

namespace WeaponSystem
{
    public class NonAutomaticReciever : WeaponReciever
    {
        private readonly NonAutomaticRecieverParameters _nonAutomaticParameters;

        public NonAutomaticReciever(NonAutomaticRecieverParameters nonAutomaticParameters) : base(nonAutomaticParameters)
        {
            _nonAutomaticParameters = nonAutomaticParameters;
        }

        public override void PullTheTrigger(WeaponMagazine magazine,
                                            WeaponBody body,
                                            WeaponSoundEffects soundEffects,
                                            WeaponShooter shooter)
        {
            _isTriggerPulled = true;

            if (IsRecharged)
            {
                Discharge(magazine, body, soundEffects, shooter);
            }
        }

        public override void ReleaseTheTrigger()
        {
            _isTriggerPulled = false;
        }

        protected override void Discharge(WeaponMagazine magazine,
                                          WeaponBody body,
                                          WeaponSoundEffects soundEffects,
                                          WeaponShooter shooter)
        {
            magazine.RemoveAmmunition(1);
            shooter.Shoot(body, soundEffects);

            IsRecharged = false;
        }

        [Serializable]
        public class NonAutomaticRecieverParameters : RecieverParameters
        {

        }
    }
}
