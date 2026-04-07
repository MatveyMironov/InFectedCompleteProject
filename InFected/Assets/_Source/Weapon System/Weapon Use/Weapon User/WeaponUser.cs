using InventorySystem;
using System;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponUser : MonoBehaviour
    {
        [SerializeField] private float baseReloadingTime;
        [SerializeField] private float baseRechargingTime;
        [SerializeField] private float equipingTime;

        [Space]
        [SerializeField] private InventorySO inventorySO;

        private Inventory _inventory;

        private WeaponController _equipedWeaponController;
        private ItemsOfSameKindProvider _ammunitionItemProvider;

        private ReloadIngWeaponState _reloadingState;
        private RechargingWeaponState _rechargingState;
        private PullingTriggerState _pullingTriggerState;
        private HoldingWeaponState _holdingWeaponState;
        private NoWeaponState _noWeaponState;
        private EquipingWeaponState _equipingWeaponState;

        private UsingWeaponState _currentState;

        #region Weapon Properties
        public int WeaponID => _equipedWeaponController.WeaponID;
        public string WeaponName => _equipedWeaponController.WeaponName;
        public Sprite WeaponSprite => _equipedWeaponController.WeaponSprite;
        public ItemDataSO AmmunitionType => _equipedWeaponController?.AmmunitionType;
        public int AvailableAmmunition => (_ammunitionItemProvider != null) ? _ammunitionItemProvider.ItemsCount : 0;
        public int LoadedAmmunition => (_equipedWeaponController != null) ? _equipedWeaponController.MagazineLoad : 0;
        public int MagazineCapacity => (_equipedWeaponController != null) ? _equipedWeaponController.MagazineCapacity : 0;
        public ItemDataSO CurrentWeaponAmmunition => _equipedWeaponController?.AmmunitionType;
        public int LoadedAmmo => _equipedWeaponController.MagazineLoad;
        #endregion

        public event Action<WeaponController> OnWeaponEquiped;
        public event Action OnWeaponHolstered;
        public event Action<int> OnMagazineLoadChanged;
        public event Action<int> OnAvailbleAmmunitionCountChanged;

        private void Awake()
        {
            _inventory = inventorySO.Inventory;

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

        private void OnDestroy()
        {
            _rechargingState.OnStateFinished -= HoldWeapon;
            _reloadingState.OnStateFinished -= HoldWeapon;
            _equipingWeaponState.OnStateFinished -= HoldWeapon;
        }

        public void EquipWeapon(WeaponController weaponController)
        {
            RemoveWeapon();

            _equipedWeaponController = weaponController;
            _equipedWeaponController.OnMagazineLoadChanged += InvokeOnMagazineLoadChanged;

            _ammunitionItemProvider = new(_inventory, _equipedWeaponController.AmmunitionType);
            _ammunitionItemProvider.OnItemsCountChanged += InvokeOnAvailableAmmunitionCountChanged;
            InvokeOnAvailableAmmunitionCountChanged(_ammunitionItemProvider.ItemsCount);

            _reloadingState.SetWeapon(_equipedWeaponController, _ammunitionItemProvider);
            _rechargingState.SetWeapon(_equipedWeaponController);
            _pullingTriggerState.SetWeapon(_equipedWeaponController);
            _equipingWeaponState.SetWeapon(_equipedWeaponController);

            Transit(_equipingWeaponState);

            OnWeaponEquiped?.Invoke(weaponController);
        }

        public void RemoveWeapon()
        {
            if (_equipedWeaponController != null)
            {
                _equipedWeaponController.OnMagazineLoadChanged -= InvokeOnMagazineLoadChanged;
                _equipedWeaponController = null;
            }

            if (_ammunitionItemProvider != null)
            {
                _ammunitionItemProvider.OnItemsCountChanged -= InvokeOnAvailableAmmunitionCountChanged;
                _ammunitionItemProvider.GetReadyForDispose();
            }

            Transit(_noWeaponState);
            OnWeaponHolstered?.Invoke();

            //Debug.Log($"Unequip weapon");
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
            if (_equipedWeaponController == null) { return; }

            Transit(_holdingWeaponState);

            if (_equipedWeaponController.MagazineLoad <= 0)
            {
                ReloadWeapon();
            }
            else if (!_equipedWeaponController.IsRecharged && _equipedWeaponController.CanBeManuallyRecharged)
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