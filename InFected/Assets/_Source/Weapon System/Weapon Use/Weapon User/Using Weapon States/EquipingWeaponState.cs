using CustomUtilities;
using System;
using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    internal class EquipingWeaponState : UsingWeaponState
    {
        private float _equipingTime;

        private WeaponController _weaponController;

        private Coroutine _equiping;

        public EquipingWeaponState(float equipingTime)
        {
            _equipingTime = equipingTime;
        }

        public override bool IsAbleToPullTheTrigger { get { return false; } }
        public override bool IsAbleToRecharge { get { return false; } }
        public override bool IsAbleToReload { get { return false; } }

        public override void Enter()
        {
            Debug.Log("equiping weapon");

            if (_equiping != null) { return; }

            _equiping = CoroutineManager.StartRoutine(EquipingWeapon());
        }

        public override void Exit()
        {
            if (_equiping == null) { return; }

            CoroutineManager.StopRoutine(_equiping);
            _equiping = null;
        }

        internal void SetWeapon(WeaponController weaponController)
        {
            _weaponController = weaponController;
        }

        private IEnumerator EquipingWeapon()
        {
            yield return new WaitForSeconds(_equipingTime);

            _weaponController.WeaponBody.ModelAnimator.runtimeAnimatorController = _weaponController.Animator;
            FinishState();
        }
    }
}
