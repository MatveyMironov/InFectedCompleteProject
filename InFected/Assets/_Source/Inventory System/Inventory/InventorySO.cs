using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
    public class InventorySO : ScriptableObject
    {
        [SerializeField] private Vector2Int inventorySize;

        public Inventory Inventory { get; private set; }

        private void OnEnable()
        {
            Inventory = new(inventorySize);
        }
    }
}