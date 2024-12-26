using CustomUtilities;
using InventorySystem;
using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    internal class LoadingAmmunitionState : UsingWeaponState
    {
        private readonly float _baseloadingTime;

        private WeaponController _weaponController;
        private ItemsOfSameKindProvider _ammunitionItemProvider;

        private Coroutine _loadingAmmunition;

        public LoadingAmmunitionState(float baseloadingTime)
        {
            _baseloadingTime = baseloadingTime;
        }

        public int AvailableAmmunition { get => _ammunitionItemProvider != null ? _ammunitionItemProvider.ItemsCount : 0; }

        public override bool IsAbleToPullTheTrigger { get { return true; } }
        public override bool IsAbleToRecharge { get { return false; } }
        public override bool IsAbleToReload { get { return false; } }

        public override void Enter()
        {
            if (_loadingAmmunition != null) { return; }

            _loadingAmmunition = CoroutineManager.StartRoutine(LoadingAmmunition());
        }

        public override void Exit()
        {
            if (_loadingAmmunition == null) { return; }

            _weaponController.WeaponAudioSource.Stop();
            CoroutineManager.StopRoutine(_loadingAmmunition);
            _loadingAmmunition = null;
        }

        public void SetWeapon(WeaponController weaponController, ItemsOfSameKindProvider ammunitionItemProvider)
        {
            _weaponController = weaponController;
            _ammunitionItemProvider = ammunitionItemProvider;
        }

        private IEnumerator LoadingAmmunition()
        {
            if (_weaponController.MagazineMaxAcceptedReload > 0 && AvailableAmmunition > 0)
            {
                _weaponController.WeaponAudioSource.PlayOneShot(_weaponController.UseSoundEffects.ReloadingingSound);

                yield return new WaitForSeconds(_baseloadingTime * _weaponController.UseParameters.ReloadDifficulty);

                LoadAmmunition();
            }
            
            FinishState();
        }

        private void LoadAmmunition()
        {
            int requiredAmmunitionAmount = _weaponController.MagazineMaxAcceptedReload;

            if (requiredAmmunitionAmount <= AvailableAmmunition)
            {
                _weaponController.Reload(requiredAmmunitionAmount);
                _ammunitionItemProvider.RemoveItems(requiredAmmunitionAmount);
            }
            else
            {
                _weaponController.Reload(AvailableAmmunition);
                _ammunitionItemProvider.RemoveItems(_ammunitionItemProvider.ItemsCount);
            }
        }
    }
}
