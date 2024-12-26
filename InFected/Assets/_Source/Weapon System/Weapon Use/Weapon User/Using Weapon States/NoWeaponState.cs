using UnityEngine;

namespace WeaponSystem
{
    internal class NoWeaponState : UsingWeaponState
    {
        public override bool IsAbleToPullTheTrigger { get { return false; } }
        public override bool IsAbleToRecharge { get { return false; } }
        public override bool IsAbleToReload { get { return false; } }

        public override void Enter()
        {
            Debug.Log("no weapon");
        }

        public override void Exit()
        {

        }
    }
}
