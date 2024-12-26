using InventorySystem;
using UnityEngine;

namespace WeaponSystem
{
    internal class ReloadIngWeaponState : UsingWeaponState
    {
        private WeaponController _weaponController;
        private ItemsOfSameKindProvider _ammunitionItemProvider;

        private LoadingAmmunitionState _loadingAmmunitionState;
        private RechargingWeaponState _rechargingState;

        private UsingWeaponState _currentState;

        public ReloadIngWeaponState(float baseReloadingTime, float baseRechargingTime)
        {
            _loadingAmmunitionState = new(baseReloadingTime);
            _rechargingState = new(baseRechargingTime);

            _loadingAmmunitionState.OnStateFinished += RechargeOrContinue;
            _rechargingState.OnStateFinished += FinishOrContinue;
        }

        public int AvailableAmmunition { get => _ammunitionItemProvider != null ? _ammunitionItemProvider.ItemsCount : 0; }

        public override bool IsAbleToPullTheTrigger { get { return _currentState.IsAbleToPullTheTrigger; } }
        public override bool IsAbleToRecharge { get { return _currentState.IsAbleToRecharge; } }
        public override bool IsAbleToReload { get { return false; } }

        public override void Enter()
        {
            Debug.Log("reloading weapon");

            LoadAmmunition();
        }

        public override void Exit()
        {
            _currentState?.Exit();
        }

        public void SetWeapon(WeaponController weaponController, ItemsOfSameKindProvider ammunitionItemProvider)
        {
            _weaponController = weaponController;
            _ammunitionItemProvider = ammunitionItemProvider;

            _loadingAmmunitionState.SetWeapon(weaponController, ammunitionItemProvider);
            _rechargingState.SetWeapon(weaponController);
        }

        private void LoadAmmunition()
        {
            Transit(_loadingAmmunitionState);
        }

        private void RechargeOrContinue()
        {
            Transit(_rechargingState);
        }

        private void FinishOrContinue()
        {
            Debug.Log(_weaponController.MagazineMaxAcceptedReload);
            Debug.Log(AvailableAmmunition);
            Debug.Log(_weaponController.MagazineMaxAcceptedReload > 0);
            Debug.Log(AvailableAmmunition > 0);
            Debug.Log(_weaponController.MagazineMaxAcceptedReload > 0 && AvailableAmmunition > 0);

            if (_weaponController.MagazineMaxAcceptedReload > 0 && AvailableAmmunition > 0)
            {
                LoadAmmunition();
            }
            else
            {
                FinishState();
            }
        }

        private void Transit(UsingWeaponState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
