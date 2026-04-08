using HealthSystem;
using InventorySystem;
using PlayerSystem;
using UnityEngine;

namespace HealingSystem
{
    public class HealingController : MonoBehaviour
    {
        [Header("Healing Item")]
        [SerializeField] private ItemDataSO healingItem;
        [SerializeField] private int restoredHealth;

        [Space]
        [SerializeField] private Player player;

        [Space]
        [SerializeField] private InventorySO inventorySO;

        private Health _health;
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = inventorySO.Inventory;
        }

        private void Start()
        {
            _health = player.Health;
        }

        public void HealIfPossible()
        {
            if (_health.CurrentHealth >= _health.MaxHealth) { return; }

            if (_inventory.TryGetItemOfKind(healingItem, out Item item))
            {
                if (item.Count <= 0) { return; }

                item.Count -= 1;
                _health.CurrentHealth += restoredHealth;
            }
        }
    }
}