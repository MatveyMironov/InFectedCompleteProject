using HealthSystem;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerSystem
{
    public class Player : MonoBehaviour, IHitable
    {
        [Header("Effects")]
        [SerializeField] private AudioSource effectsAudioSource;

        [Header("Hit Effects")]
        [SerializeField] private AudioClip hitAudioClip;
        [SerializeField] private float hitClipVolumeVariation;

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
            PlayHitAudioClip();
            _health.CurrentHealth -= damage;

            void PlayHitAudioClip()
            {
                float clipVolumeScale = Random.value + 1.0f - hitClipVolumeVariation;
                effectsAudioSource.PlayOneShot(hitAudioClip, clipVolumeScale);
            }
        }

        private void InvokeOnHealthChanged()
        {
            float healthValue = (float)_health.CurrentHealth / _health.MaxHealth;
            OnHealthChanged.Invoke(healthValue);
        }
    }
}