using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewSingleProjectileShooterData", menuName = "Weapons/Shooter Data/Single Projectile Shooter")]
    public class SingleProjectileShooterDataSO : WeaponShooterDataSO
    {
        [SerializeField] private SingleProjectileShooter.SingleProjectileShooterParameters parameters;

        public override WeaponShooter WeaponShooter
        {
            get { return new SingleProjectileShooter(parameters); }
        }
    }
}