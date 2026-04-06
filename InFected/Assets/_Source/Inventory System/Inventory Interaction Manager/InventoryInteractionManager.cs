using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{
    public class InventoryInteractionManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Inventory> OnInventoryOffered;

        public void OfferInventory(Inventory inventory)
        {
            OnInventoryOffered.Invoke(inventory);
        }
    }
}