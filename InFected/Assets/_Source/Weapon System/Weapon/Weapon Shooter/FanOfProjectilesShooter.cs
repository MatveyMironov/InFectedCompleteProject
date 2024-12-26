using System;
using UnityEngine;

namespace WeaponSystem
{
    public class FanOfProjectilesShooter : WeaponShooter
    {
        public FanOfProjectilesShooterParameters FanOfProjectilesParameters { get; }

        public FanOfProjectilesShooter(FanOfProjectilesShooterParameters parameters) : base(parameters)
        {
            FanOfProjectilesParameters = parameters;
        }

        public override void Shoot(WeaponBody body, WeaponSoundEffects soundEffects)
        {
            body.AudioSource.PlayOneShot(soundEffects.ShotSound);
            SpawnProjectiles(body);
        }

        protected void SpawnProjectiles(WeaponBody body)
        {
            float angleStep = FanOfProjectilesParameters.ShootingSpread * 2 / (FanOfProjectilesParameters.ProjectilesPerShot - 1);

            for (int i = 0; i < FanOfProjectilesParameters.ProjectilesPerShot; i++)
            {
                float angleDeviation = FanOfProjectilesParameters.ShootingSpread - angleStep * i;
                Quaternion relativeBulletRotation = Quaternion.Euler(0, 0, angleDeviation);

                Bullet2D bullet = UnityEngine.Object.Instantiate(FanOfProjectilesParameters.ProjectilePrefab,
                                                 body.Muzzle.position,
                                                 body.Muzzle.rotation * relativeBulletRotation);
                float bulletDeathTime = FanOfProjectilesParameters.EffectiveDistance / FanOfProjectilesParameters.ProjectileSpeed;

                bullet.SetupBullet(FanOfProjectilesParameters.ProjectileSpeed,
                                   FanOfProjectilesParameters.HitableLayers,
                                   bulletDeathTime,
                                   FanOfProjectilesParameters.ProjectileDamage,
                                   body.Muzzle.position);
            }
        }

        [Serializable]
        public class FanOfProjectilesShooterParameters : ShooterParameters
        {
            [field: Tooltip("In degrees")]
            [field: SerializeField, Range(0, 90)] public float ShootingSpread { get; private set; }

            [field: Header("Projectile")]
            [field: SerializeField] public Bullet2D ProjectilePrefab { get; private set; }
            [field: SerializeField] public int ProjectilesPerShot { get; private set; }

            [field: Header("Projectile Parameters")]
            [field: SerializeField] public float ProjectileSpeed { get; private set; }
            [field: SerializeField] public LayerMask HitableLayers { get; private set; }
            [field: SerializeField] public int ProjectileDamage { get; private set; }
            [field: SerializeField] public float EffectiveDistance { get; private set; }
        }
    }
}