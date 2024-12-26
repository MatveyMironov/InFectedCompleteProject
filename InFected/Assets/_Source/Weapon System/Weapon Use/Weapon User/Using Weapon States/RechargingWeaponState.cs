using CustomUtilities;
using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    internal class RechargingWeaponState : UsingWeaponState
    {
        private float _baseRechargingTime;

        private WeaponController _weaponController;

        private Coroutine _recharging;

        public RechargingWeaponState(float baseRechargingTime)
        {
            _baseRechargingTime = baseRechargingTime;
        }

        public override bool IsAbleToPullTheTrigger { get { return false; } }
        public override bool IsAbleToRecharge { get { return false; } }
        public override bool IsAbleToReload { get { return true; } }

        public override void Enter()
        {
            Debug.Log("recharging weapon");

            if (_recharging != null) { return; }

            _recharging = CoroutineManager.StartRoutine(RechargingWeapon());
        }

        public override void Exit()
        {
            if (_recharging == null) { return; }

            _weaponController.WeaponAudioSource.Stop();
            CoroutineManager.StopRoutine(_recharging);
            _recharging = null;
        }

        public void SetWeapon(WeaponController weaponController)
        {
            _weaponController = weaponController;
        }

        private IEnumerator RechargingWeapon()
        {
            if (!_weaponController.IsRecharged && _weaponController.CanBeManuallyRecharged)
            {
                _weaponController.WeaponAudioSource.PlayOneShot(_weaponController.UseSoundEffects.RechargingSound);

                yield return new WaitForSeconds(_baseRechargingTime * _weaponController.UseParameters.RechargeDifficulty);

                _weaponController.RechargeManually();
            }

            FinishState();
        }
    }
}
