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

        public Health Health { get; private set; }
        public CircleCollider2D Collider { get; private set; }

        private void Awake()
        {
            Health = new(maxHealth);
            Health.OnHealthChanged += InvokeOnHealthChanged;
            Health.OnHealthExpired += OnHealthExpired.Invoke;
            Health.CurrentHealth = maxHealth;

            Collider = GetComponent<CircleCollider2D>();
        }

        private void OnDestroy()
        {
            Health.OnHealthChanged -= InvokeOnHealthChanged;
            Health.OnHealthExpired -= OnHealthExpired.Invoke;
        }

        public void Hit(int damage, Vector3 from)
        {
            PlayHitAudioClip();
            Health.CurrentHealth -= damage;

            void PlayHitAudioClip()
            {
                float clipVolumeScale = Random.value + 1.0f - hitClipVolumeVariation;
                effectsAudioSource.PlayOneShot(hitAudioClip, clipVolumeScale);
            }
        }

        private void InvokeOnHealthChanged()
        {
            float healthValue = (float)Health.CurrentHealth / Health.MaxHealth;
            OnHealthChanged.Invoke(healthValue);
        }
    }
}