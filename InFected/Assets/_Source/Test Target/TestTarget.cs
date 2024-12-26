using HealthSystem;
using System.Collections;
using UnityEngine;

namespace TestUtilities
{
    public class TestTarget : MonoBehaviour, IHitable
    {
        [SerializeField] private Health health;
        [SerializeField] private Renderer targetRenderer;
        [SerializeField] private float timeDead;

        public void Hit(int damage, Vector3 from)
        {
            health.CurrentHealth += damage;
        }

        private void OnEnable()
        {
            health.OnHealthExpired += Death;
        }

        private void OnDisable()
        {
            health.OnHealthExpired -= Death;
        }

        private void Death()
        {
            targetRenderer.enabled = false;
            StartCoroutine(DeathCoroutine());
        }

        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(timeDead);
            health.CurrentHealth = health.MaxHealth;
            targetRenderer.enabled = true;
        }
    }
}
