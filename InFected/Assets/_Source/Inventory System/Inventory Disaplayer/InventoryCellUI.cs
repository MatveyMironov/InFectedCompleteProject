using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class InventoryCellUI : MonoBehaviour, IDropHandler
    {
        public event Func<ItemUI, bool> OnItemPlaceRequested;
        public event Action<ItemUI> OnItemRemoveRequested;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out ItemUI itemUI))
            {
                TryPlaceItemUI(itemUI);
            }
        }

        public bool TryPlaceItemUI(ItemUI itemUI)
        {
            if ((bool)(OnItemPlaceRequested?.Invoke(itemUI)))
            {
                itemUI.AssignCurrentCellUI(this);
                return true;
            }

            return false;
        }

        public void RemoveItemUI(ItemUI itemUI)
        {
            OnItemRemoveRequested?.Invoke(itemUI);
        }
    }
}