using HealthSystem;
using InventorySystem;

namespace HealingSystem
{
    public class Healing
    {
        private Health _health;
        private ItemsOfSameTypeProvider<HealingItem> _itemsFinder;

        public Healing(Health health, ItemsOfSameTypeProvider<HealingItem> itemsFinder)
        {
            _health = health;
            _itemsFinder = itemsFinder;
        }

        public bool TryHeal()
        {
            if (_health.CurrentHealth < _health.MaxHealth)
            {
                if (_itemsFinder.TryGetItemOfType(out HealingItem healingItem))
                {
                    Heal(healingItem);
                    healingItem.Count--;

                    return true;
                }
            }
            
            return false;
        }

        public void Heal(HealingItem healingItem)
        {
            _health.CurrentHealth += healingItem.RestoredHealth;
        }
    }
}