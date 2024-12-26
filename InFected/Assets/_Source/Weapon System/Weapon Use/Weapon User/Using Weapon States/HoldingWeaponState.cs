using UnityEngine;

namespace WeaponSystem
{
    internal class HoldingWeaponState : UsingWeaponState
    {
        public override bool IsAbleToPullTheTrigger { get { return true; } }

        public override bool IsAbleToRecharge { get { return true; } }

        public override bool IsAbleToReload { get { return true; } }

        public override void Enter()
        {
            Debug.Log("holding weapon");
        }

        public override void Exit()
        {
            
        }
    }
}
