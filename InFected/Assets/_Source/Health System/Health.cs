using System;

namespace HealthSystem
{
    public class Health
    {
        private int _maxHealth;
        private int _currentHealth;

        public Health(int maxHealth, int currentHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth;
            OnHealthChanged?.Invoke(CurrentHealth);
        }

        public int MaxHealth { get { return _maxHealth; } }
        public int CurrentHealth { get { return _currentHealth; } set { ChangeHealth(value); } }

        public event Action<int> OnHealthChanged;
        public event Action OnHealthExpired;

        private void ChangeHealth(int newHealth)
        {
            if (newHealth < 0)
            {
                newHealth = 0;
            }

            if (newHealth > _maxHealth)
            {
                newHealth = _maxHealth;
            }

            _currentHealth = newHealth;
            OnHealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth == 0)
            {
                OnHealthExpired?.Invoke();
            }
        }
    }
}