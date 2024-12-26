using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewFanOfProjectilesShooterData", menuName = "Weapons/Shooter Data/Fan Of Projectiles Shooter")]
    public class FanOfProjectilesShooterDataSO : WeaponShooterDataSO
    {
        [SerializeField] private FanOfProjectilesShooter.FanOfProjectilesShooterParameters parameters;

        public override WeaponShooter WeaponShooter
        {
            get { return new FanOfProjectilesShooter(parameters); }
        }
    }
}