using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewUnlimitedReloadMagazineData", menuName = "Weapons/Magazine Data/Unlimited Reload Magazine")]
    public class UnlimitedReloadMagazineDataSO : WeaponMagazineDataSO
    {
        [SerializeField] private WeaponMagazine.MagazineParameters parameters;

        public override WeaponMagazine WeaponMagazine
        {
            get { return new UnlimitedReloadMagazine(parameters); }
        }
    }
}