using System;

namespace HealthSystem
{
    public class Health
    {
        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
        }

        private int _currentHealth;

        public int MaxHealth { get; }
        public int CurrentHealth { get => _currentHealth; set => ChangeHealth(value); }

        public event Action OnHealthChanged;
        public event Action OnHealthExpired;

        private void ChangeHealth(int newHealth)
        {
            if (newHealth < 0)
            {
                newHealth = 0;
            }

            if (newHealth > MaxHealth)
            {
                newHealth = MaxHealth;
            }

            _currentHealth = newHealth;
            OnHealthChanged?.Invoke();

            if (CurrentHealth == 0)
            {
                OnHealthExpired?.Invoke();
            }
        }
    }
}