using UISystem;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private GameObject weaponUIObject;
        [SerializeField] private WeaponDisplayer weaponDisplayer;
        [SerializeField] private LoadCapacityDisplayer magazineDisplayer;
        [SerializeField] private CountDisplayer inventoryAmmoDisplayer;

        public WeaponDisplayer WeaponDisplayer { get => weaponDisplayer; }
        public LoadCapacityDisplayer MagazineDisplayer { get => magazineDisplayer; }
        public CountDisplayer InventoryAmmoDisplayer { get => inventoryAmmoDisplayer; }

        public void ShowWeaponUI()
        {
            weaponUIObject.SetActive(true);
        }

        public void HideWeaponUI()
        {
            weaponUIObject.SetActive(false);
        }
    }
}
