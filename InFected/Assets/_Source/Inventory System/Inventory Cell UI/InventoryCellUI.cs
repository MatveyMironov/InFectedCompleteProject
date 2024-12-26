using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class InventoryCellUI : MonoBehaviour, IDropHandler
    {
        public event Func<ItemUI, bool> OnTryingPlaceItemUI;
        public event Action<ItemUI> OnRemovingItemUI;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out ItemUI itemUI))
            {
                TryPlaceItemUI(itemUI);
            }
        }

        public bool TryPlaceItemUI(ItemUI itemUI)
        {
            return (bool)(OnTryingPlaceItemUI?.Invoke(itemUI));
        }

        public void RemoveItemUI(ItemUI itemUI)
        {
            OnRemovingItemUI?.Invoke(itemUI);
        }
    }
}