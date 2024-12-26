using HealthSystem;
using System;

namespace PlayerSystem
{
    public class PlayerDeathController
    {
        private Health _health;

        public PlayerDeathController(Health health)
        {
            _health = health;

            _health.OnHealthExpired += Death;
        }

        public event Action OnPlayerDeath;

        public void Death()
        {
            OnPlayerDeath?.Invoke();
        }
    }
}