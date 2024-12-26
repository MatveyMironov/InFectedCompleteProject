using InventorySystem;
using System;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponUser
    {
        private readonly Inventory _inventory;

        private WeaponController _weaponController;
        private ItemsOfSameKindProvider _ammunitionItemProvider;

        private readonly ReloadIngWeaponState _reloadingState;
        private readonly RechargingWeaponState _rechargingState;
        private readonly PullingTriggerState _pullingTriggerState;
        private readonly HoldingWeaponState _holdingWeaponState;
        private readonly NoWeaponState _noWeaponState;
        private readonly EquipingWeaponState _equipingWeaponState;

        private UsingWeaponState _currentState;

        public WeaponUser(Inventory inventory, float baseReloadingTime, float baseRechargingTime, float equipingTime)
        {
            _inventory = inventory;

            _rechargingState = new(baseRechargingTime);
            _reloadingState = new(baseReloadingTime, baseRechargingTime);
            _pullingTriggerState = new();
            _holdingWeaponState = new();
            _noWeaponState = new();
            _equipingWeaponState = new(equipingTime);

            _rechargingState.OnStateFinished += HoldWeapon;
            _reloadingState.OnStateFinished += HoldWeapon;
            _equipingWeaponState.OnStateFinished += HoldWeapon;

            _currentState = _noWeaponState;
        }



        #region Weapon Properties
        public int WeaponID { get { return _weaponController.WeaponID; } }
        public string WeaponName { get => _weaponController.WeaponName; }
        public Sprite WeaponSprite { get => _weaponController.WeaponSprite; }
        public ItemDataSO AmmunitionType { get { return _weaponController?.AmmunitionType; } }
        public int AvailableAmmunition { get => _ammunitionItemProvider != null ? _ammunitionItemProvider.ItemsCount : 0; }
        public int LoadedAmmunition { get { return (_weaponController != null) ? _weaponController.MagazineLoad : 0; } }
        public int MagazineCapacity { get { return (_weaponController != null) ? _weaponController.MagazineCapacity : 0; } }
        public ItemDataSO CurrentWeaponAmmunition { get { return _weaponController?.AmmunitionType; } }
        public int LoadedAmmo { get { return _weaponController.MagazineLoad; } }
        #endregion

        public event Action<WeaponController> OnWeaponEquiped;
        public event Action OnWeaponHolstered;
        public event Action<int> OnMagazineLoadChanged;
        public event Action<int> OnAvailbleAmmunitionCountChanged;

        public void EquipWeapon(WeaponController weaponController)
        {
            RemoveWeapon();

            _weaponController = weaponController;
            _weaponController.OnMagazineLoadChanged += InvokeOnMagazineLoadChanged;

            _ammunitionItemProvider = new(_inventory, _weaponController.AmmunitionType);
            _ammunitionItemProvider.OnItemsCountChanged += InvokeOnAvailableAmmunitionCountChanged;
            InvokeOnAvailableAmmunitionCountChanged(_ammunitionItemProvider.ItemsCount);

            _reloadingState.SetWeapon(_weaponController, _ammunitionItemProvider);
            _rechargingState.SetWeapon(_weaponController);
            _pullingTriggerState.SetWeapon(_weaponController);
            _equipingWeaponState.SetWeapon(_weaponController);

            Transit(_equipingWeaponState);

            OnWeaponEquiped?.Invoke(weaponController);
        }

        public void RemoveWeapon()
        {
            if (_weaponController != null)
            {
                _weaponController.OnMagazineLoadChanged -= InvokeOnMagazineLoadChanged;
                _weaponController = null;
            }

            if (_ammunitionItemProvider != null)
            {
                _ammunitionItemProvider.OnItemsCountChanged -= InvokeOnAvailableAmmunitionCountChanged;
                _ammunitionItemProvider.GetReadyForDispose();
            }

            Transit(_noWeaponState);
            OnWeaponHolstered?.Invoke();
        }

        public void PullWeaponTrigger()
        {
            if (_currentState.IsAbleToPullTheTrigger)
            {
                Transit(_pullingTriggerState);
            }
        }

        public void ReleaseWeaponTrigger()
        {
            if (_weaponController == null) { return; }

            Transit(_holdingWeaponState);

            if (_weaponController.MagazineLoad <= 0)
            {
                ReloadWeapon();
            }
            else if (!_weaponController.IsRecharged && _weaponController.CanBeManuallyRecharged)
            {
                RechargeWeapon();
            }
        }

        public void ReloadWeapon()
        {
            if (_currentState.IsAbleToReload)
            {
                Transit(_reloadingState);
            }
        }

        private void RechargeWeapon()
        {
            if (_currentState.IsAbleToRecharge)
            {
                Transit(_rechargingState);
            }
        }

        private void HoldWeapon()
        {
            Transit(_holdingWeaponState);
        }

        private void Transit(UsingWeaponState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        private void InvokeOnMagazineLoadChanged(int load)
        {
            OnMagazineLoadChanged?.Invoke(load);
        }

        private void InvokeOnAvailableAmmunitionCountChanged(int count)
        {
            OnAvailbleAmmunitionCountChanged?.Invoke(count);
        }
    }
}