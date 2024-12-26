namespace WeaponSystem
{
    public class FullyAutomaticReciever : AutomaticReciever
    {
        public FullyAutomaticReciever(AutomaticRecieverParameters parameters) : base(parameters)
        {

        }

        protected override void Recharge(WeaponMagazine magazine,
                                         WeaponBody body,
                                         WeaponSoundEffects soundEffects,
                                         WeaponShooter shooter)
        {
            base.Recharge(magazine, body, soundEffects, shooter);

            if (IsRecharged && _isTriggerPulled)
            {
                Discharge(magazine, body, soundEffects, shooter);
            }
        }
    }
}
