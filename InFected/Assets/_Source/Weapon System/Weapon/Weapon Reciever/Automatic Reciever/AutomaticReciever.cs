using CustomUtilities;
using System;
using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class AutomaticReciever : WeaponReciever
    {
        protected AutomaticRecieverParameters _automaticParameters;

        private bool _isAutomaticallyRecharging;

        public AutomaticReciever(AutomaticRecieverParameters parameters) : base(parameters)
        {
            _automaticParameters = parameters;
        }

        public override bool CanBeManuallyRecharged { get { return !_isAutomaticallyRecharging; } }

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
            else
            {
                body.AudioSource.PlayOneShot(soundEffects.EmptyMagazineSound);
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

            _isAutomaticallyRecharging = true;
            CoroutineManager.StartRoutine(RechargeAutomatically(magazine, body, soundEffects, shooter));
        }

        protected IEnumerator RechargeAutomatically(WeaponMagazine magazine,
                                                    WeaponBody body,
                                                    WeaponSoundEffects soundEffects,
                                                    WeaponShooter shooter)
        {
            yield return new WaitForSeconds(_automaticParameters.RechargingTime);

            _isAutomaticallyRecharging = false;
            Recharge(magazine, body, soundEffects, shooter);
        }

        [Serializable]
        public class AutomaticRecieverParameters : RecieverParameters
        {
            [field: SerializeField] public float RechargingTime { get; private set; }
        }
    }
}
