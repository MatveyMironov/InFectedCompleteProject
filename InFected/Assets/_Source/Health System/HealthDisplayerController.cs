using UISystem;

namespace HealthSystem
{
    public class HealthDisplayerController
    {
        private Health _health;
        private LoadCapacityDisplayer _healthDisplayer;

        public HealthDisplayerController(Health health, LoadCapacityDisplayer healthDisplayer)
        {
            _health = health;
            _healthDisplayer = healthDisplayer;

            _healthDisplayer.DisplayCapacity(_health.MaxHealth);
            _healthDisplayer.DisplayLoad(_health.CurrentHealth);

            _health.OnHealthChanged += DisplayHealth;
        }

        public void DisplayHealth(int health)
        {
            _healthDisplayer.DisplayLoad(health);
        }
    }
}