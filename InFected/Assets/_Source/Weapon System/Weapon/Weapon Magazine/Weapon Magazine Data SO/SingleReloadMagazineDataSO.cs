using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewSingleReloadMagazineData", menuName = "Weapons/Magazine Data/Single Reload Magazine")]
    public class SingleReloadMagazineDataSO : WeaponMagazineDataSO
    {
        [SerializeField] SingleReloadMagazine.MagazineParameters parameters;

        public override WeaponMagazine WeaponMagazine
        {
            get { return new SingleReloadMagazine(parameters); }
        }
    }
}