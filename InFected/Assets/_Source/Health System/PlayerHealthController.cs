using PlayerSystem;

namespace HealthSystem
{
    public class PlayerHealthController
    {
        private Player _player;
        private Health _health;

        public PlayerHealthController(Player player, Health health)
        {
            _player = player;
            _health = health;

            _player.OnDamageRecieved += DamageHealth;
        }

        public void DamageHealth(int damage)
        {
            _health.CurrentHealth -= damage;
        }
    }
}