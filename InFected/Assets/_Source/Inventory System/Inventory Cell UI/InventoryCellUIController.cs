using System;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryCellUIController
    {
        private InventoryCellUI _cellUI;
        private InventoryGrid _inventoryGrid;
        private Vector2Int _gridPosition;

        public InventoryCellUIController(InventoryCellUI cellUI, InventoryGrid inventoryGrid, Vector2Int gridPosition)
        {
            _cellUI = cellUI;
            _inventoryGrid = inventoryGrid;
            _gridPosition = gridPosition;

            _cellUI.OnTryingPlaceItemUI += TryPlaceItemUI;
            _cellUI.OnRemovingItemUI += RemoveItemUI;
        }

        public event Action<ItemUI> OnItemUIPlaced;
        public event Action<ItemUI> OnItemUIRemoved;

        public bool TryPlaceItemUI(ItemUI itemUI)
        {
            ItemUIController itemUIController = itemUI.GetItemUIController();

            if (itemUIController != null)
            {
                if (_inventoryGrid.TryPlaceItemAt(itemUIController.Item, _gridPosition))
                {
                    itemUIController.AssignCellUI(_cellUI);

                    OnItemUIPlaced?.Invoke(itemUI);

                    return true;
                }
            }

            return false;
        }

        private void RemoveItemUI(ItemUI itemUI)
        {
            ItemUIController itemUIController = itemUI.GetItemUIController();

            if (itemUIController != null)
            {
                _inventoryGrid.RemoveItemAt(_gridPosition);

                OnItemUIRemoved?.Invoke(itemUI);
            };
        }
    }
}