using UnityEngine;

namespace WeaponSystem
{
    internal class PullingTriggerState : UsingWeaponState
    {
        private WeaponController _weaponController;

        public override bool IsAbleToPullTheTrigger { get; } = false;
        public override bool IsAbleToRecharge { get; } = false;
        public override bool IsAbleToReload { get; } = false;

        public override void Enter()
        {
            Debug.Log("pulling trigger");

            _weaponController.PullTheTrigger();
        }

        public override void Exit()
        {
            _weaponController.ReleaseTheTrigger();
        }
        public void SetWeapon(WeaponController weaponController)
        {
            _weaponController = weaponController;
        }
    }
}
