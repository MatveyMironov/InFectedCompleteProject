using UnityEngine;

namespace InventorySystem
{
    public class InventoryDisplayerSetuper : MonoBehaviour
    {
        [SerializeField] private InventoryDisplayer displayer;
        [SerializeField] private InventorySO inventorySO;

        private void Start()
        {
            displayer.DisplayInventory(inventorySO.Inventory);
        }
    }
}