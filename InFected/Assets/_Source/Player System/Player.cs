using HealthSystem;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerSystem
{
    public class Player : MonoBehaviour, IHitable
    {
        [Header("Hit Effects")]
        [SerializeField] private AudioSource gettingHitSource;

        [Header("Health")]
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent<float> OnHealthChanged;
        [SerializeField] private UnityEvent OnHealthExpired;

        private Health _health;

        public CircleCollider2D Collider { get; private set; }

        private void Awake()
        {
            _health = new(maxHealth);
            _health.OnHealthChanged += InvokeOnHealthChanged;
            _health.OnHealthExpired += OnHealthExpired.Invoke;
            _health.CurrentHealth = maxHealth;

            Collider = GetComponent<CircleCollider2D>();
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= InvokeOnHealthChanged;
            _health.OnHealthExpired -= OnHealthExpired.Invoke;
        }

        public void Hit(int damage, Vector3 from)
        {
            gettingHitSource.Play();

            _health.CurrentHealth -= damage;
        }

        private void InvokeOnHealthChanged()
        {
            float healthValue = (float)_health.CurrentHealth / _health.MaxHealth;
            OnHealthChanged.Invoke(healthValue);
        }
    }
}