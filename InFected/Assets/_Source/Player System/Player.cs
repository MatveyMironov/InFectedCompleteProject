using HealthSystem;
using System;
using UISystem;
using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour, IHitable
    {
        [Header("Hit Effects")]
        [SerializeField] private AudioSource gettingHitSource;

        public CircleCollider2D Collider { get; private set; }

        public event Action<int> OnDamageRecieved;

        private void Awake()
        {
            Collider = GetComponent<CircleCollider2D>();
        }

        public void Hit(int damage, Vector3 from)
        {
            gettingHitSource.Play();
            OnDamageRecieved?.Invoke(damage);
        }
    }
}
