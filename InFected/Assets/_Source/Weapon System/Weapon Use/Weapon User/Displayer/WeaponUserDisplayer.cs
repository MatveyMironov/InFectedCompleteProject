using TMPro;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    public class WeaponUserDisplayer : MonoBehaviour
    {
        [SerializeField] private WeaponUser weaponUser;

        [Space]
        [SerializeField] private GameObject displayerObject;

        [Header("Weapon")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image iconImage;

        [Header("Ammunition")]
        [SerializeField] private LoadCapacityDisplayer magazineDisplayer;
        [SerializeField] private CountDisplayer inventoryAmmoDisplayer;

        private void OnEnable()
        {
            weaponUser.OnWeaponEquiped += DisplayWeapon;
            weaponUser.OnWeaponHolstered += HideWeapon;

            weaponUser.OnMagazineLoadChanged += DisplayMagazineLoad;
            weaponUser.OnAvailbleAmmunitionCountChanged += DisplayAvailableAmmunition;
        }

        private void OnDisable()
        {
            weaponUser.OnWeaponEquiped -= DisplayWeapon;
            weaponUser.OnWeaponHolstered -= HideWeapon;

            weaponUser.OnMagazineLoadChanged -= DisplayMagazineLoad;
            weaponUser.OnAvailbleAmmunitionCountChanged -= DisplayAvailableAmmunition;
        }

        private void DisplayWeapon(WeaponController weapon)
        {
            ShowDisplayer();

            nameText.text = weapon.WeaponName;
            iconImage.sprite = weapon.WeaponSprite;

            magazineDisplayer.DisplayCapacity(weapon.MagazineCapacity);
            DisplayMagazineLoad(weapon.MagazineLoad);
            DisplayAvailableAmmunition(weaponUser.AvailableAmmunition);
        }

        private void HideWeapon()
        {
            HideDisplayer();
        }

        private void DisplayMagazineLoad(int magazineLoad)
        {
            magazineDisplayer.DisplayLoad(magazineLoad);
        }

        private void DisplayAvailableAmmunition(int availableAmmunition)
        {
            inventoryAmmoDisplayer.DisplayCount(availableAmmunition);
        }

        public void ShowDisplayer()
        {
            displayerObject.SetActive(true);
            //gameObject.SetActive(true);
        }

        public void HideDisplayer()
        {
            displayerObject.SetActive(false);
            //gameObject.SetActive(false);
        }
    }
}