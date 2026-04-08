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
            //Debug.Log($"'OnDrop' method called on '{this}'");

            if (eventData.pointerDrag.TryGetComponent(out ItemUI itemUI))
            {
                //Debug.Log($"'{itemUI}' dropped on '{this}'");
                TryPlaceItemUI(itemUI);
            }
        }

        public bool TryPlaceItemUI(ItemUI itemUI)
        {
            //Debug.Log($"Trying to place '{itemUI}' in '{this}'");

            if ((bool)(OnItemPlaceRequested?.Invoke(itemUI)))
            {
                //Debug.Log($"'{itemUI}' successfully placed in '{this}'");
                itemUI.AssignCurrentCellUI(this);
                return true;
            }

            //Debug.Log($"Failed to place '{itemUI}' in '{this}'");
            return false;
        }

        public void RemoveItemUI(ItemUI itemUI)
        {
            OnItemRemoveRequested?.Invoke(itemUI);
        }
    }
}