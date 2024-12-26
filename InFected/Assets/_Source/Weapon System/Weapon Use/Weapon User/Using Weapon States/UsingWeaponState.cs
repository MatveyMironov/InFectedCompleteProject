using System;

namespace WeaponSystem
{
    public abstract class UsingWeaponState
    {
        public event Action OnStateFinished;

        public abstract bool IsAbleToPullTheTrigger { get; }
        public abstract bool IsAbleToRecharge { get; }
        public abstract bool IsAbleToReload { get; }

        public abstract void Enter();
        public abstract void Exit();
        
        protected void FinishState()
        {
            OnStateFinished?.Invoke();
        }
    }
}