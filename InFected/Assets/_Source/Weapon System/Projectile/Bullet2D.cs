using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    public class Bullet2D : Projectile2D
    {
        private int _damage;
        private Vector3 _shooterPosition;

        public void SetupBullet(float speed, LayerMask hitableLayers, float deathTime, int damage, Vector3 shooterPosition)
        {
            SetupProjectile(speed, hitableLayers, deathTime);
            _damage = damage;
            _shooterPosition = shooterPosition;
        }

        protected override void OnHit(RaycastHit2D hit)
        {
            if (hit.transform.TryGetComponent(out IHitable hitable))
                hitable.Hit(_damage, _shooterPosition);

            _isProjectileActive = false;
            StartCoroutine(DestroyWithDelay());
        }

        private IEnumerator DestroyWithDelay()
        {
            yield return new WaitForSeconds(2);

            Destroy(gameObject);
        }
    }
}