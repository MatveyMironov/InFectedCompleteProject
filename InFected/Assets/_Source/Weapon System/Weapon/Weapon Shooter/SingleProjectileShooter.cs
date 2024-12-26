using System;
using UnityEngine;

namespace WeaponSystem
{
    public class SingleProjectileShooter : WeaponShooter
    {
        public SingleProjectileShooterParameters SingleProjectileParameters { get; }

        public SingleProjectileShooter(SingleProjectileShooterParameters parameters) : base(parameters)
        {
            SingleProjectileParameters = parameters;
        }

        public override void Shoot(WeaponBody body, WeaponSoundEffects soundEffects)
        {
            body.AudioSource.PlayOneShot(soundEffects.ShotSound);
            SpawnProjectile(body);
        }

        protected void SpawnProjectile(WeaponBody body)
        {
            float angleDeviation = UnityEngine.Random.Range(-SingleProjectileParameters.ShootingSpread,
                                                SingleProjectileParameters.ShootingSpread);

            Quaternion relativeBulletRotation = Quaternion.Euler(0, 0, angleDeviation);

            Bullet2D bullet = UnityEngine.Object.Instantiate(SingleProjectileParameters.ProjectilePrefab,
                                                 body.Muzzle.position,
                                                 body.Muzzle.rotation * relativeBulletRotation);

            float bulletDeathTime = SingleProjectileParameters.EffectiveDistance / SingleProjectileParameters.BulletSpeed;

            bullet.SetupBullet(SingleProjectileParameters.BulletSpeed,
                               SingleProjectileParameters.HitableLayers,
                               bulletDeathTime,
                               SingleProjectileParameters.BulletDamage,
                               body.Muzzle.position);
        }

        [Serializable]
        public class SingleProjectileShooterParameters : ShooterParameters
        {
            [field: Tooltip("In degrees")]
            [field: SerializeField, Range(0, 90)] public float ShootingSpread { get; private set; }

            [field: Header("Projectile")]
            [field: SerializeField] public Bullet2D ProjectilePrefab { get; private set; }

            [field: Header("Projectile Parameters")]
            [field: SerializeField] public float BulletSpeed { get; private set; }
            [field: SerializeField] public LayerMask HitableLayers { get; private set; }
            [field: SerializeField] public int BulletDamage { get; private set; }
            [field: SerializeField] public float EffectiveDistance { get; private set; }
        }
    }
}