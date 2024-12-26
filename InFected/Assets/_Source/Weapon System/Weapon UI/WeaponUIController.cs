using UnityEngine;

namespace WeaponSystem
{
    public class WeaponUIController
    {
        private WeaponUI _weaponUI;
        private WeaponUser _weaponUser;

        public WeaponUIController(WeaponUI weaponUI, WeaponUser weaponUser)
        {
            _weaponUI = weaponUI;
            _weaponUser = weaponUser;

            _weaponUser.OnWeaponEquiped += DisplayWeapon;
            _weaponUser.OnWeaponHolstered += HideWeapon;
            _weaponUser.OnMagazineLoadChanged += DisplayMagazineLoad;
            _weaponUser.OnAvailbleAmmunitionCountChanged += DisplayAvailableAmmunition;

            SetInitialState();
        }

        private void SetInitialState()
        {
            _weaponUI.HideWeaponUI();
        }

        private void DisplayWeapon(WeaponController weaponUseController)
        {
            _weaponUI.ShowWeaponUI();
            _weaponUI.WeaponDisplayer.DisplayWeapon(weaponUseController.WeaponName, weaponUseController.WeaponSprite);
            _weaponUI.MagazineDisplayer.DisplayCapacity(weaponUseController.MagazineCapacity);
            DisplayMagazineLoad(weaponUseController.MagazineLoad);
        }

        private void HideWeapon()
        {
            _weaponUI.HideWeaponUI();
        }

        private void DisplayMagazineLoad(int magazineLoad)
        {
            _weaponUI.MagazineDisplayer.DisplayLoad(magazineLoad);
        }

        private void DisplayAvailableAmmunition(int availableAmmunition)
        {
            _weaponUI.InventoryAmmoDisplayer.DisplayCount(availableAmmunition);
        }
    }
}