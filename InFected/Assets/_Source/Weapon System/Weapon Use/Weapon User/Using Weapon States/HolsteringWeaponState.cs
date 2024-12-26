namespace WeaponSystem
{
    internal class HolsteringWeaponState : UsingWeaponState
    {
        public override bool IsAbleToPullTheTrigger { get { return false; } }
        public override bool IsAbleToRecharge { get { return false; } }
        public override bool IsAbleToReload { get { return false; } }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }
    }
}
